namespace AutoService
{
    partial class FormAddAssemblys
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
            nameAssemblyTextBox = new TextBox();
            descriptionTextBox = new TextBox();
            priceAssemblyTextBox = new TextBox();
            saveButton = new Button();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            panel1 = new Panel();
            label9 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // nameAssemblyTextBox
            // 
            nameAssemblyTextBox.Location = new Point(306, 195);
            nameAssemblyTextBox.Name = "nameAssemblyTextBox";
            nameAssemblyTextBox.Size = new Size(159, 23);
            nameAssemblyTextBox.TabIndex = 49;
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Location = new Point(306, 253);
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(159, 23);
            descriptionTextBox.TabIndex = 48;
            // 
            // priceAssemblyTextBox
            // 
            priceAssemblyTextBox.Location = new Point(306, 224);
            priceAssemblyTextBox.Name = "priceAssemblyTextBox";
            priceAssemblyTextBox.Size = new Size(159, 23);
            priceAssemblyTextBox.TabIndex = 47;
            // 
            // SaveButton
            // 
            saveButton.Location = new Point(317, 386);
            saveButton.Name = "SaveButton";
            saveButton.Size = new Size(137, 36);
            saveButton.TabIndex = 46;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += SaveButton_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(180, 252);
            label14.Name = "label14";
            label14.Size = new Size(88, 20);
            label14.TabIndex = 42;
            label14.Text = "Description:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(180, 223);
            label15.Name = "label15";
            label15.Size = new Size(107, 20);
            label15.TabIndex = 41;
            label15.Text = "PriceAssembly:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(180, 194);
            label16.Name = "label16";
            label16.Size = new Size(115, 20);
            label16.TabIndex = 40;
            label16.Text = "NameAssembly:";
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
            label9.Location = new Point(296, 41);
            label9.Name = "label9";
            label9.Size = new Size(72, 20);
            label9.TabIndex = 8;
            label9.Text = "Assembly";
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
            // FormAddAssemblys
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(nameAssemblyTextBox);
            Controls.Add(descriptionTextBox);
            Controls.Add(priceAssemblyTextBox);
            Controls.Add(saveButton);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(label16);
            Controls.Add(panel1);
            Name = "FormAddAssemblys";
            Text = "FormAddAssemblys";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox nameAssemblyTextBox;
        private TextBox descriptionTextBox;
        private TextBox priceAssemblyTextBox;
        private Button saveButton;
        private Label label14;
        private Label label15;
        private Label label16;
        private Panel panel1;
        private Label label9;
        private Label label1;
    }
}