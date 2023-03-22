namespace CSDatabaseLabs.Labs.LabTask1
{
    partial class FormView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            fields_listview = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            label1 = new Label();
            type_combobox = new ComboBox();
            notnull_checkbox = new CheckBox();
            field_textbox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            addlist_button = new Button();
            clear_button = new Button();
            label4 = new Label();
            table_textbox = new TextBox();
            addtable_button = new Button();
            droptable_button = new Button();
            deletefield_button = new Button();
            addfield_button = new Button();
            SuspendLayout();
            // 
            // fields_listview
            // 
            fields_listview.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            fields_listview.Location = new Point(26, 27);
            fields_listview.Name = "fields_listview";
            fields_listview.Size = new Size(235, 165);
            fields_listview.TabIndex = 0;
            fields_listview.UseCompatibleStateImageBehavior = false;
            fields_listview.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Название";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Not Null";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Тип данных";
            columnHeader3.Width = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 1;
            label1.Text = "Добавление поля:";
            // 
            // type_combobox
            // 
            type_combobox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            type_combobox.FormattingEnabled = true;
            type_combobox.Location = new Point(26, 224);
            type_combobox.Name = "type_combobox";
            type_combobox.Size = new Size(148, 25);
            type_combobox.TabIndex = 2;
            // 
            // notnull_checkbox
            // 
            notnull_checkbox.AutoSize = true;
            notnull_checkbox.Location = new Point(190, 225);
            notnull_checkbox.Name = "notnull_checkbox";
            notnull_checkbox.Size = new Size(71, 19);
            notnull_checkbox.TabIndex = 3;
            notnull_checkbox.Text = "Not Null";
            notnull_checkbox.UseVisualStyleBackColor = true;
            // 
            // field_textbox
            // 
            field_textbox.BorderStyle = BorderStyle.FixedSingle;
            field_textbox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            field_textbox.Location = new Point(285, 222);
            field_textbox.Name = "field_textbox";
            field_textbox.Size = new Size(210, 25);
            field_textbox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(26, 204);
            label2.Name = "label2";
            label2.Size = new Size(74, 15);
            label2.TabIndex = 5;
            label2.Text = "Тип данных:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(285, 204);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 6;
            label3.Text = "Имя поля:";
            // 
            // addlist_button
            // 
            addlist_button.BackColor = Color.White;
            addlist_button.FlatStyle = FlatStyle.Flat;
            addlist_button.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            addlist_button.Location = new Point(26, 265);
            addlist_button.Name = "addlist_button";
            addlist_button.Size = new Size(107, 30);
            addlist_button.TabIndex = 7;
            addlist_button.Text = "Добавить";
            addlist_button.UseVisualStyleBackColor = false;
            // 
            // clear_button
            // 
            clear_button.BackColor = Color.White;
            clear_button.FlatStyle = FlatStyle.Flat;
            clear_button.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            clear_button.Location = new Point(150, 265);
            clear_button.Name = "clear_button";
            clear_button.Size = new Size(111, 30);
            clear_button.TabIndex = 8;
            clear_button.Text = "Очистить";
            clear_button.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(285, 9);
            label4.Name = "label4";
            label4.Size = new Size(85, 15);
            label4.TabIndex = 10;
            label4.Text = "Имя таблицы:";
            // 
            // table_textbox
            // 
            table_textbox.BorderStyle = BorderStyle.FixedSingle;
            table_textbox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            table_textbox.Location = new Point(285, 27);
            table_textbox.Name = "table_textbox";
            table_textbox.Size = new Size(210, 25);
            table_textbox.TabIndex = 9;
            // 
            // addtable_button
            // 
            addtable_button.BackColor = Color.White;
            addtable_button.FlatStyle = FlatStyle.Flat;
            addtable_button.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            addtable_button.Location = new Point(285, 58);
            addtable_button.Name = "addtable_button";
            addtable_button.Size = new Size(210, 30);
            addtable_button.TabIndex = 11;
            addtable_button.Text = "Добавить таблицу";
            addtable_button.UseVisualStyleBackColor = false;
            // 
            // droptable_button
            // 
            droptable_button.BackColor = Color.White;
            droptable_button.FlatStyle = FlatStyle.Flat;
            droptable_button.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            droptable_button.Location = new Point(285, 161);
            droptable_button.Name = "droptable_button";
            droptable_button.Size = new Size(210, 31);
            droptable_button.TabIndex = 12;
            droptable_button.Text = "Удалить таблицу";
            droptable_button.UseVisualStyleBackColor = false;
            // 
            // deletefield_button
            // 
            deletefield_button.BackColor = Color.White;
            deletefield_button.FlatStyle = FlatStyle.Flat;
            deletefield_button.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            deletefield_button.Location = new Point(386, 265);
            deletefield_button.Name = "deletefield_button";
            deletefield_button.Size = new Size(109, 30);
            deletefield_button.TabIndex = 13;
            deletefield_button.Text = "Удалить поле";
            deletefield_button.UseVisualStyleBackColor = false;
            // 
            // addfield_button
            // 
            addfield_button.BackColor = Color.White;
            addfield_button.FlatStyle = FlatStyle.Flat;
            addfield_button.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            addfield_button.Location = new Point(285, 265);
            addfield_button.Name = "addfield_button";
            addfield_button.Size = new Size(88, 30);
            addfield_button.TabIndex = 14;
            addfield_button.Text = "Отправить";
            addfield_button.UseVisualStyleBackColor = false;
            // 
            // FormView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 321);
            Controls.Add(addfield_button);
            Controls.Add(deletefield_button);
            Controls.Add(droptable_button);
            Controls.Add(addtable_button);
            Controls.Add(label4);
            Controls.Add(table_textbox);
            Controls.Add(clear_button);
            Controls.Add(addlist_button);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(field_textbox);
            Controls.Add(notnull_checkbox);
            Controls.Add(type_combobox);
            Controls.Add(label1);
            Controls.Add(fields_listview);
            MaximumSize = new Size(540, 360);
            MinimumSize = new Size(540, 360);
            Name = "FormView";
            Text = "Лабораторная работа 1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView fields_listview;
        private Label label1;
        private ComboBox type_combobox;
        private CheckBox notnull_checkbox;
        private TextBox field_textbox;
        private Label label2;
        private Label label3;
        private Button addlist_button;
        private Button clear_button;
        private Label label4;
        private TextBox table_textbox;
        private Button addtable_button;
        private Button droptable_button;
        private Button deletefield_button;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button addfield_button;
    }
}