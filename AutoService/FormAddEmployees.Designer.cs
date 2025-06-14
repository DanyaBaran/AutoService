namespace AutoService
{
    partial class FormAddEmployees
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
            employmentDateTextBox = new TextBox();
            salaryTextBox = new TextBox();
            nameTextBox = new TextBox();
            phoneTextBox = new TextBox();
            addressTextBox = new TextBox();
            saveButton = new Button();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            panel1 = new Panel();
            label9 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // employmentDateTextBox
            // 
            employmentDateTextBox.Location = new Point(306, 282);
            employmentDateTextBox.Name = "employmentDateTextBox";
            employmentDateTextBox.Size = new Size(159, 23);
            employmentDateTextBox.TabIndex = 52;
            // 
            // salaryTextBox
            // 
            salaryTextBox.ImeMode = ImeMode.Off;
            salaryTextBox.Location = new Point(306, 311);
            salaryTextBox.Name = "salaryTextBox";
            salaryTextBox.Size = new Size(159, 23);
            salaryTextBox.TabIndex = 50;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(306, 195);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(159, 23);
            nameTextBox.TabIndex = 49;
            // 
            // phoneTextBox
            // 
            phoneTextBox.Location = new Point(306, 253);
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(159, 23);
            phoneTextBox.TabIndex = 48;
            // 
            // addressTextBox
            // 
            addressTextBox.Location = new Point(306, 224);
            addressTextBox.Name = "addressTextBox";
            addressTextBox.Size = new Size(159, 23);
            addressTextBox.TabIndex = 47;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(317, 386);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(137, 36);
            saveButton.TabIndex = 46;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(180, 310);
            label12.Name = "label12";
            label12.Size = new Size(52, 20);
            label12.TabIndex = 44;
            label12.Text = "Salary:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(180, 281);
            label13.Name = "label13";
            label13.Size = new Size(128, 20);
            label13.TabIndex = 43;
            label13.Text = "EmploymentDate:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(180, 252);
            label14.Name = "label14";
            label14.Size = new Size(53, 20);
            label14.TabIndex = 42;
            label14.Text = "Phone:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(180, 223);
            label15.Name = "label15";
            label15.Size = new Size(65, 20);
            label15.TabIndex = 41;
            label15.Text = "Address:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(180, 194);
            label16.Name = "label16";
            label16.Size = new Size(52, 20);
            label16.TabIndex = 40;
            label16.Text = "Name:";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(58, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(685, 76);
            panel1.TabIndex = 39;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(287, 41);
            label9.Name = "label9";
            label9.Size = new Size(75, 20);
            label9.TabIndex = 8;
            label9.Text = "Employee";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(258, 9);
            label1.Name = "label1";
            label1.Size = new Size(137, 32);
            label1.TabIndex = 0;
            label1.Text = "Add record:";
            // 
            // FormAddEmployees
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(employmentDateTextBox);
            Controls.Add(salaryTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(phoneTextBox);
            Controls.Add(addressTextBox);
            Controls.Add(saveButton);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(panel1);
            Name = "FormAddEmployees";
            Text = "FormAddEmployees";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox employmentDateTextBox;
        private TextBox salaryTextBox;
        private TextBox nameTextBox;
        private TextBox phoneTextBox;
        private TextBox addressTextBox;
        private Button saveButton;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Panel panel1;
        private Label label9;
        private Label label1;
    }
}