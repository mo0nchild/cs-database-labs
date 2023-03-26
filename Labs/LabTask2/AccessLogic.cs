using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSDatabaseLabs.Labs.LabTask1.AccessLogic;

namespace CSDatabaseLabs.Labs.LabTask2
{
    public class AccessLogic : System.Object
    {
        public enum OperationType : System.Byte { Update, Insert, Delete }
        public sealed class AccessLogicException : System.Exception
        {
            public AccessLogic.OperationType OperationType { get; init; } = default!;
            public AccessLogicException(string message, OperationType type) : base(message)
            { this.OperationType = type; }
        }


        public event EventHandler<System.Data.DataTable> TableDataLoad = delegate { };
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

        public Task<System.Data.DataTable> DisplayTableData(string table_name)
        {
            var query_result = this.UseConnection(delegate (Npgsql.NpgsqlConnection connection)
            {
                var command_string = String.Format("SELECT * FROM {0}", table_name);
                var result_datatable = new DataTable();

                using (var database_adapter = new Npgsql.NpgsqlDataAdapter(command_string, connection)) 
                {
                    database_adapter.Fill(result_datatable);
                }
                return Task.FromResult(result_datatable);
            });
            this.TableDataLoad(this, query_result.Result); return query_result;
        }

        public Task<string> AddTableRecord(string table_name, Dictionary<string, string> data)
        {
            var query_result = this.UseConnection<string>(delegate (Npgsql.NpgsqlConnection connection)
            {
                var table_field = string.Format("INSERT INTO {0} (", table_name);
                var table_values = "VALUES (";

                using var command_instance = new Npgsql.NpgsqlCommand("", connection);
                int index = 1;
                foreach(var data_item in data)
                {
                    table_field += $"{data_item.Key},";
                    table_values += $"${index},";
                    command_instance.Parameters.Add(new Npgsql.NpgsqlParameter() { Value = data_item.Value });
                    index++;
                }
                table_field = table_field.Remove(table_field.Length - 1).Insert(table_field.Length - 1, ")");
                table_values = table_values.Remove(table_values.Length - 1).Insert(table_values.Length - 1, ")");

                command_instance.CommandText = string.Format("{0} {1}", table_field, table_values);
                try { command_instance.ExecuteNonQuery(); }
                catch (System.Exception error)
                {
                    throw new AccessLogicException(error.Message, OperationType.Insert);
                }
                return Task.FromResult(command_instance.CommandText);
            });
            this.DisplayTableData(table_name).Wait(); return query_result;
        }

        public Task<string> UpdateTableRecord(string table_name, int id, Dictionary<string, string> data)
        {
            var query_result = this.UseConnection<string>(delegate (Npgsql.NpgsqlConnection connection)
            {
                var command_string = string.Format("UPDATE {0} SET ", table_name);
                using var command_instance = new Npgsql.NpgsqlCommand(string.Empty, connection);

                for(var index = 0; index < data.Count; index++)
                {
                    KeyValuePair<string, string> current_record = data.ElementAt(index);
                    command_string += $"{current_record.Key}=${index + 1},";

                    command_instance.Parameters.Add(new Npgsql.NpgsqlParameter() { Value = current_record.Value });
                }
                command_string = command_string.Remove(command_string.Length - 1) + string.Format(" WHERE id={0}", id);
                command_instance.CommandText = command_string;

                try { command_instance.ExecuteNonQuery(); }
                catch (System.Exception error)
                {
                    throw new AccessLogicException(error.Message, OperationType.Update);
                }
                return Task.FromResult(command_instance.CommandText);
            });
            this.DisplayTableData(table_name).Wait(); return query_result;
        }

        public Task<string> DeleteTableRecord(string table_name, int id)
        {
            var query_result = this.UseConnection<string>(delegate (Npgsql.NpgsqlConnection connection)
            {
                var command_string = string.Format("DELETE FROM {0} WHERE id={1}", table_name, id);
                using var command_instance = new Npgsql.NpgsqlCommand(command_string, connection);

                try { command_instance.ExecuteNonQuery(); }
                catch (System.Exception error)
                {
                    throw new AccessLogicException(error.Message, OperationType.Update);
                }
                return Task.FromResult(command_instance.CommandText);
            });
            this.DisplayTableData(table_name).Wait(); return query_result;
        }
    }
}
