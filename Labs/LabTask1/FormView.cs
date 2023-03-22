using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDatabaseLabs.Labs.LabTask1
{
    public partial class FormView : Form
    {
        protected AccessLogic AccessLogic { get; private set; } = default!;
        protected ObservableCollection<AccessLogic.TableFieldOptions> FieldsList = new();

        public FormView() : base()
        {
            this.InitializeComponent();
            this.AccessLogic = new(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            this.FieldsList.CollectionChanged += new NotifyCollectionChangedEventHandler(FieldsListChange);

            this.clear_button.Click += new EventHandler(Clear_button_Click);
            this.addlist_button.Click += new EventHandler(Addlist_button_Click);

            this.addfield_button.Click += new EventHandler(Addfield_button_Click);
            this.addtable_button.Click += new EventHandler(Addtable_button_Click);

            this.deletefield_button.Click += new EventHandler(Deletefield_button_Click);
            this.droptable_button.Click += new EventHandler(Droptable_button_Click);

            var sql_types = new string[]
            {
                "VARCHAR(10)", "VARCHAR(20)", "VARCHAR(30)", "INTEGER", "DATE"
            };
            foreach (var item in sql_types) this.type_combobox.Items.Add(item);
            this.Clear_button_Click(this, EventArgs.Empty);
        }

        protected virtual void FieldsListChange(object? sender, NotifyCollectionChangedEventArgs args)
        {
            if (args.Action != NotifyCollectionChangedAction.Add) return;
            AccessLogic.TableFieldOptions? @new = default!;
            if ((@new = args.NewItems?[0] as AccessLogic.TableFieldOptions) != null)
            {
                var listview_item = new string[] { @new.Name, @new.NotNull.ToString(), @new.FieldType };
                this.fields_listview.Items.Add(new ListViewItem(listview_item));
            }
        }

        private void Addlist_button_Click(object? sender, EventArgs e)
        {
            var (field_name, field_type) = (this.field_textbox.Text, this.type_combobox.Text);
            var notnull_param = this.notnull_checkbox.Checked;

            this.FieldsList.Add(new AccessLogic.TableFieldOptions(field_name, notnull_param, field_type));
        }

        private void Droptable_button_Click(object? sender, EventArgs args)
        {
            Task<string> result = default!;
            try {
                if((result = this.AccessLogic.DropTable(this.table_textbox.Text)).Wait(2000))
                { MessageBox.Show(result.GetAwaiter().GetResult(), "Операция выполнена"); }
            }
            catch (AggregateException error) when (error.InnerException is AccessLogic.AccessLogicException)
            {
                var query_error = (AccessLogic.AccessLogicException)error.InnerException;

                var (message, operation) = (error.Message, query_error.OperationType.ToString());
                MessageBox.Show(message, operation, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Clear_button_Click(sender, args);
        }

        private void Deletefield_button_Click(object? sender, EventArgs args)
        {
            Task<string> result = default!;
            var (table_name, field_name) = (this.table_textbox.Text, this.field_textbox.Text);
            try {
                if((result = this.AccessLogic.DeleteTableField(table_name, field_name)).Wait(2000))
                { MessageBox.Show(result.GetAwaiter().GetResult(), "Операция выполнена"); }
                
            }
            catch (AggregateException error) when (error.InnerException is AccessLogic.AccessLogicException)
            {
                var query_error = (AccessLogic.AccessLogicException)error.InnerException;

                var (message, operation) = (error.Message, query_error.OperationType.ToString());
                MessageBox.Show(message, operation, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Clear_button_Click(sender, args);
        }

        private void Clear_button_Click(object? sender, EventArgs args)
        {
            this.notnull_checkbox.Checked = default;
            this.table_textbox.Text = this.field_textbox.Text = string.Empty;

            this.type_combobox.SelectedIndex = 0;
            this.FieldsList.Clear();
            this.fields_listview.Items.Clear();
        }

        private void Addtable_button_Click(object? sender, EventArgs args)
        {
            Task<string> result = default!;
            try {
                if((result = this.AccessLogic.CreateTable(this.table_textbox.Text)).Wait(2000))
                { MessageBox.Show(result.Result, "Операция выполнена"); }
            }
            catch (AggregateException error) when (error.InnerException is AccessLogic.AccessLogicException)
            {
                var query_error = (AccessLogic.AccessLogicException)error.InnerException;

                var (message, operation) = (error.Message, query_error.OperationType.ToString());
                MessageBox.Show(message, operation, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Clear_button_Click(sender, args);
        }

        private void Addfield_button_Click(object? sender, EventArgs args)
        {
            Task<string[]> result = default!;
            var (table_name, field_list) = (this.table_textbox.Text, this.FieldsList.ToList());
            try {
                var @string = string.Empty;
                if((result = this.AccessLogic.AddTableField(table_name, field_list)).Wait(2000))
                {
                    foreach (var item in result.Result) @string += $"{item}\n";
                    MessageBox.Show(@string, "Операция выполнена");
                }
            }
            catch (AggregateException error) when (error.InnerException is AccessLogic.AccessLogicException)
            {
                var query_error = (AccessLogic.AccessLogicException)error.InnerException;

                var (message, operation) = (error.Message, query_error.OperationType.ToString());
                MessageBox.Show(message, operation, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Clear_button_Click(sender, args);
        }
    }
}
