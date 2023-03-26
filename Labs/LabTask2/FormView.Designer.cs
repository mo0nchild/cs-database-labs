namespace CSDatabaseLabs.Labs.LabTask2
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
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            removeButton = new Button();
            updateButton = new Button();
            addButton = new Button();
            birthdayTextbox = new TextBox();
            emailTextbox = new TextBox();
            phoneTextbox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            genderTextbox = new TextBox();
            nameTextbox = new TextBox();
            dataGridView = new DataGridView();
            clearButton = new Button();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Location = new Point(12, 12);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(500, 357);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(clearButton);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(removeButton);
            tabPage1.Controls.Add(updateButton);
            tabPage1.Controls.Add(addButton);
            tabPage1.Controls.Add(birthdayTextbox);
            tabPage1.Controls.Add(emailTextbox);
            tabPage1.Controls.Add(phoneTextbox);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(genderTextbox);
            tabPage1.Controls.Add(nameTextbox);
            tabPage1.Controls.Add(dataGridView);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(492, 329);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Контакты";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(180, 221);
            label5.Name = "label5";
            label5.Size = new Size(93, 15);
            label5.TabIndex = 13;
            label5.Text = "Дата рождения:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(351, 169);
            label4.Name = "label4";
            label4.Size = new Size(116, 15);
            label4.TabIndex = 12;
            label4.Text = "Электронная почта:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(180, 169);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 11;
            label3.Text = "Телефон:";
            // 
            // removeButton
            // 
            removeButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            removeButton.Location = new Point(351, 282);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(135, 32);
            removeButton.TabIndex = 10;
            removeButton.Text = "Удалить";
            removeButton.UseVisualStyleBackColor = true;
            // 
            // updateButton
            // 
            updateButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            updateButton.Location = new Point(180, 282);
            updateButton.Name = "updateButton";
            updateButton.Size = new Size(135, 32);
            updateButton.TabIndex = 9;
            updateButton.Text = "Изменить запись";
            updateButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            addButton.Location = new Point(6, 282);
            addButton.Name = "addButton";
            addButton.Size = new Size(135, 32);
            addButton.TabIndex = 8;
            addButton.Text = "Добавить запись";
            addButton.UseVisualStyleBackColor = true;
            // 
            // birthdayTextbox
            // 
            birthdayTextbox.BorderStyle = BorderStyle.FixedSingle;
            birthdayTextbox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            birthdayTextbox.Location = new Point(180, 239);
            birthdayTextbox.MaxLength = 20;
            birthdayTextbox.Name = "birthdayTextbox";
            birthdayTextbox.Size = new Size(135, 25);
            birthdayTextbox.TabIndex = 7;
            // 
            // emailTextbox
            // 
            emailTextbox.BorderStyle = BorderStyle.FixedSingle;
            emailTextbox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            emailTextbox.Location = new Point(351, 187);
            emailTextbox.MaxLength = 30;
            emailTextbox.Name = "emailTextbox";
            emailTextbox.Size = new Size(135, 25);
            emailTextbox.TabIndex = 6;
            // 
            // phoneTextbox
            // 
            phoneTextbox.BorderStyle = BorderStyle.FixedSingle;
            phoneTextbox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            phoneTextbox.Location = new Point(180, 187);
            phoneTextbox.MaxLength = 20;
            phoneTextbox.Name = "phoneTextbox";
            phoneTextbox.Size = new Size(135, 25);
            phoneTextbox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 221);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 4;
            label2.Text = "Пол:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 169);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 3;
            label1.Text = "Имя контакта:";
            // 
            // genderTextbox
            // 
            genderTextbox.BorderStyle = BorderStyle.FixedSingle;
            genderTextbox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            genderTextbox.Location = new Point(6, 239);
            genderTextbox.MaxLength = 10;
            genderTextbox.Name = "genderTextbox";
            genderTextbox.Size = new Size(135, 25);
            genderTextbox.TabIndex = 2;
            // 
            // nameTextbox
            // 
            nameTextbox.BorderStyle = BorderStyle.FixedSingle;
            nameTextbox.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            nameTextbox.Location = new Point(6, 187);
            nameTextbox.MaxLength = 20;
            nameTextbox.Name = "nameTextbox";
            nameTextbox.Size = new Size(135, 25);
            nameTextbox.TabIndex = 1;
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(6, 6);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(480, 157);
            dataGridView.TabIndex = 0;
            // 
            // clearButton
            // 
            clearButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            clearButton.Location = new Point(351, 232);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(135, 32);
            clearButton.TabIndex = 14;
            clearButton.Text = "Очистить поля";
            clearButton.UseVisualStyleBackColor = true;
            // 
            // FormView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(524, 381);
            Controls.Add(tabControl);
            MaximumSize = new Size(540, 420);
            MinimumSize = new Size(540, 420);
            Name = "FormView";
            Text = "Лабораторная работа 2";
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage1;
        private DataGridView dataGridView;
        private Button removeButton;
        private Button updateButton;
        private Button addButton;
        private TextBox birthdayTextbox;
        private TextBox emailTextbox;
        private TextBox phoneTextbox;
        private Label label2;
        private Label label1;
        private TextBox genderTextbox;
        private TextBox nameTextbox;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button clearButton;
    }
}