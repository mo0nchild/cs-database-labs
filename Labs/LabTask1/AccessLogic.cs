using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CSDatabaseLabs.Labs.LabTask1
{
    public class AccessLogic : System.Object
    {
        public enum OperationType : System.Byte { Create, Alter, Drop }
        public sealed class AccessLogicException : System.Exception
        {
            public AccessLogic.OperationType OperationType { get; init; } = default!;
            public AccessLogicException(string message, OperationType type) : base(message) 
            { this.OperationType = type; }
        }

        public System.String ConnectionString { get; private set; } = default!;
        public AccessLogic(string connection_string) : base() { this.ConnectionString = connection_string; }

        protected async Task<TResult> UseConnection<TResult>(Func<Npgsql.NpgsqlConnection, 
            Task<TResult>> connection_action)
        {
            using (var database_connection = new Npgsql.NpgsqlConnection(this.ConnectionString))
            {
                database_connection.Open();
                return await connection_action.Invoke(database_connection);
            }
        }

        public record TableFieldOptions(System.String Name, System.Boolean NotNull, System.String FieldType);
        public virtual Task<string[]> AddTableField(string table_name, List<TableFieldOptions> fields)
        {
            List<string> commands_string = new();
            return this.UseConnection<string[]>(async delegate (Npgsql.NpgsqlConnection connection)
            {
                await using var connection_transaction = connection.BeginTransaction();
                foreach(var item in fields)
                {
                    commands_string.Add(String.Format("ALTER TABLE {0} ADD COLUMN {1} {2} {3};", table_name, 
                        item.Name, item.FieldType, item.NotNull ? "NOT NULL" : ""));
                }
                await using var database_command = new Npgsql.NpgsqlCommand(string.Empty, connection)
                { Transaction = connection_transaction };
                try {
                    foreach (string command in commands_string)
                    {
                        database_command.CommandText = command;
                        database_command.ExecuteNonQuery();
                    }
                    connection_transaction.Commit();
                }
                catch(System.Exception error) 
                {
                    await Console.Out.WriteLineAsync(error.Message);
                    connection_transaction.Rollback();
                    throw new AccessLogicException(error.Message, OperationType.Alter);
                }
                return commands_string.ToArray();
            });
        }

        public virtual Task<string> DeleteTableField(string table_name, string field_name)
        {
            return this.UseConnection(async delegate (Npgsql.NpgsqlConnection connection) 
            {
                var command_string = String.Format("ALTER TABLE {0} DROP COLUMN {1}", table_name, field_name);
                await using var database_command = new Npgsql.NpgsqlCommand(command_string, connection);

                try { database_command.ExecuteNonQuery(); }
                catch (System.Exception error)
                {
                    throw new AccessLogicException(error.Message, OperationType.Create);
                }
                return command_string;
            });
        } 

        public virtual Task<string> CreateTable(string table_name)
        {
            return this.UseConnection(async delegate (Npgsql.NpgsqlConnection connection) 
            { 
                var command_string = String.Format("CREATE TABLE {0} (ID serial NOT NULL PRIMARY KEY);", table_name);
                await using var database_command = new Npgsql.NpgsqlCommand(command_string, connection);

                try { database_command.ExecuteNonQuery(); }
                catch(System.Exception error)
                {
                    throw new AccessLogicException(error.Message, OperationType.Create);
                }
                return command_string;
            });
        }

        public virtual Task<string> DropTable(string table_name)
        {
            return this.UseConnection(async delegate (Npgsql.NpgsqlConnection connection) 
            {
                var command_string = String.Format("DROP TABLE {0} RESTRICT", table_name);
                await using var database_command = new Npgsql.NpgsqlCommand(command_string, connection);

                try { database_command.ExecuteNonQuery(); }
                catch (System.Exception error)
                {
                    throw new AccessLogicException(error.Message, OperationType.Drop);
                }
                return command_string;
            });
        }
    }
}
