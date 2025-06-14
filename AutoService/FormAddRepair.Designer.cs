namespace AutoService
{
    partial class FormAddRepair
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
            panel1 = new Panel();
            label9 = new Label();
            label1 = new Label();
            label10 = new Label();
            label12 = new Label();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            saveButton = new Button();
            dateEndTextBox = new TextBox();
            dateBeginTextBox = new TextBox();
            employeeIdTextBox = new TextBox();
            contactOwnerTextBox = new TextBox();
            carIdTextBox = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(63, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(685, 76);
            panel1.TabIndex = 0;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(296, 41);
            label9.Name = "label9";
            label9.Size = new Size(52, 20);
            label9.TabIndex = 8;
            label9.Text = "Repair";
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
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(185, 309);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 29;
            label10.Text = "DateEnd:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(185, 280);
            label12.Name = "label12";
            label12.Size = new Size(82, 20);
            label12.TabIndex = 28;
            label12.Text = "DateBegin:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(185, 251);
            label14.Name = "label14";
            label14.Size = new Size(106, 20);
            label14.TabIndex = 26;
            label14.Text = "ContactOwner:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(185, 222);
            label15.Name = "label15";
            label15.Size = new Size(47, 20);
            label15.TabIndex = 25;
            label15.Text = "CarId:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(185, 193);
            label16.Name = "label16";
            label16.Size = new Size(91, 20);
            label16.TabIndex = 24;
            label16.Text = "EmployeeId:";
            // 
            // SaveButton
            // 
            saveButton.Location = new Point(322, 385);
            saveButton.Name = "SaveButton";
            saveButton.Size = new Size(137, 36);
            saveButton.TabIndex = 32;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // dateEndTextBox
            // 
            dateEndTextBox.Location = new Point(311, 310);
            dateEndTextBox.Name = "dateEndTextBox";
            dateEndTextBox.Size = new Size(159, 23);
            dateEndTextBox.TabIndex = 37;
            // 
            // dateBeginTextBox
            // 
            dateBeginTextBox.ImeMode = ImeMode.Off;
            dateBeginTextBox.Location = new Point(311, 281);
            dateBeginTextBox.Name = "dateBeginTextBox";
            dateBeginTextBox.Size = new Size(159, 23);
            dateBeginTextBox.TabIndex = 36;
            // 
            // employeeIdTextBox
            // 
            employeeIdTextBox.Location = new Point(311, 194);
            employeeIdTextBox.Name = "employeeIdTextBox";
            employeeIdTextBox.Size = new Size(159, 23);
            employeeIdTextBox.TabIndex = 35;
            // 
            // contactOwnerTextBox
            // 
            contactOwnerTextBox.Location = new Point(311, 252);
            contactOwnerTextBox.Name = "contactOwnerTextBox";
            contactOwnerTextBox.Size = new Size(159, 23);
            contactOwnerTextBox.TabIndex = 34;
            // 
            // carIdTextBox
            // 
            carIdTextBox.Location = new Point(311, 223);
            carIdTextBox.Name = "carIdTextBox";
            carIdTextBox.Size = new Size(159, 23);
            carIdTextBox.TabIndex = 33;
            // 
            // FormAdd
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dateEndTextBox);
            Controls.Add(dateBeginTextBox);
            Controls.Add(employeeIdTextBox);
            Controls.Add(contactOwnerTextBox);
            Controls.Add(carIdTextBox);
            Controls.Add(saveButton);
            Controls.Add(label10);
            Controls.Add(label12);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(panel1);
            Name = "FormAdd";
            Text = "FormAdd";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label9;
        private Label label1;
        private Label label10;
        private Label label12;
        private Label label14;
        private Label label15;
        private Label label16;
        private Button saveButton;
        private TextBox dateEndTextBox;
        private TextBox dateBeginTextBox;
        private TextBox employeeIdTextBox;
        private TextBox contactOwnerTextBox;
        private TextBox carIdTextBox;
    }
}