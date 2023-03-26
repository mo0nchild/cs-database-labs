using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSDatabaseLabs.Labs.LabTask2
{
    using LabTask = CSDatabaseLabs.Labs.LabTask2;
    public partial class FormView : Form
    {
        private static readonly System.String tableName = "cs_test";
        protected LabTask::AccessLogic AccessLogic { get; private set; } = default!;

        private System.Int32 currentRecordId = default!;

        public FormView() : base()
        {
            this.InitializeComponent();
            this.AccessLogic = new(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            this.AccessLogic.TableDataLoad += new EventHandler<DataTable>(this.AccessLogic_TableDataLoad);

            this.addButton.Click += new EventHandler(this.AddButton_Click);
            this.removeButton.Click += new EventHandler(this.RemoveButton_Click);
            this.updateButton.Click += new EventHandler(this.UpdateButton_Click);
            this.clearButton.Click += (sender, args) => this.ClearUserInputForm();

            this.dataGridView.SelectionChanged += new EventHandler(this.DataGridView_SelectionChanged);
            this.AccessLogic.DisplayTableData(FormView.tableName);
        }

        private void DataGridView_SelectionChanged(object? sender, EventArgs args)
        {
            if (this.dataGridView.SelectedCells.Count <= 0) return;
            var row_index = this.dataGridView.SelectedCells[0].RowIndex;

            var record_data = this.dataGridView.Rows[row_index].Cells;
            if (record_data.Count > 0 && record_data["id"].Value.ToString() != string.Empty)
            {
                this.phoneTextbox.Text = Convert.ToString(record_data["phone"].Value)!;
                this.nameTextbox.Text = Convert.ToString(record_data["name"].Value)!;
                this.birthdayTextbox.Text = Convert.ToString(record_data["birthday"].Value)!;

                this.genderTextbox.Text = Convert.ToString(record_data["gender"].Value);
                this.emailTextbox.Text = Convert.ToString(record_data["email"].Value);
                this.currentRecordId = Convert.ToInt32(record_data["id"].Value);
            }
            else this.ClearUserInputForm();
        }

        private void ClearUserInputForm()
        {
            this.birthdayTextbox.Text = this.emailTextbox.Text = this.genderTextbox.Text
                = this.nameTextbox.Text = this.phoneTextbox.Text = string.Empty;
            this.currentRecordId = default(int);
        }

        private void AccessLogic_TableDataLoad(object? sender, DataTable data_table)
        {
            this.dataGridView.DataSource = data_table;
            this.dataGridView.Invalidate();
        }

        private void UpdateButton_Click(object? sender, EventArgs args)
        {
            var table_values = new Dictionary<string, string>()
            {
                { "phone", this.phoneTextbox.Text }, { "name", this.nameTextbox.Text },
                { "email", this.emailTextbox.Text }, { "birthday", this.birthdayTextbox.Text },
                { "gender", this.genderTextbox.Text },
            };
            try
            {
                MessageBox.Show(this.AccessLogic.UpdateTableRecord(FormView.tableName, this.currentRecordId,
                    table_values).Result);
            }
            catch (AggregateException error) when (error.InnerException is AccessLogic.AccessLogicException)
            {
                var query_error = (AccessLogic.AccessLogicException)error.InnerException;
                MessageBox.Show(error.Message, query_error.OperationType.ToString());
            }
        }

        private void RemoveButton_Click(object? sender, EventArgs args)
        {
            try { MessageBox.Show(this.AccessLogic.DeleteTableRecord(FormView.tableName, this.currentRecordId).Result); }
            catch (AggregateException error) when (error.InnerException is AccessLogic.AccessLogicException)
            {
                var query_error = (AccessLogic.AccessLogicException)error.InnerException;
                MessageBox.Show(error.Message, query_error.OperationType.ToString());
            }
            this.ClearUserInputForm();
        }

        private void AddButton_Click(object? sender, EventArgs args)
        {
            var table_values = new Dictionary<string, string>()
            {
                { "phone", this.phoneTextbox.Text }, { "name", this.nameTextbox.Text },
                { "email", this.emailTextbox.Text }, { "birthday", this.birthdayTextbox.Text },
                { "gender", this.genderTextbox.Text },
            };
            try { MessageBox.Show(this.AccessLogic.AddTableRecord(FormView.tableName, table_values).Result); }
            catch (AggregateException error) when (error.InnerException is AccessLogic.AccessLogicException)
            {
                var query_error = (AccessLogic.AccessLogicException)error.InnerException;
                MessageBox.Show(error.Message, query_error.OperationType.ToString());
            }
            this.ClearUserInputForm();
        }
    }
}
