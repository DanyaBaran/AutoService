﻿namespace AutoService
{
    partial class Statistic
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
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // YearButton
            // 
            button1.Location = new Point(334, 85);
            button1.Name = "YearButton";
            button1.Size = new Size(189, 76);
            button1.TabIndex = 0;
            button1.Text = "PerYear";
            button1.UseVisualStyleBackColor = true;
            button1.Click += YearButton_Click;
            // 
            // MonthButton
            // 
            button2.Location = new Point(57, 85);
            button2.Name = "MonthButton";
            button2.Size = new Size(189, 76);
            button2.TabIndex = 1;
            button2.Text = "PerMonths";
            button2.UseVisualStyleBackColor = true;
            button2.Click += MonthButton_Click;
            // 
            // MarksButton
            // 
            button3.Location = new Point(194, 195);
            button3.Name = "MarksButton";
            button3.Size = new Size(189, 76);
            button3.TabIndex = 2;
            button3.Text = "PopularMarks";
            button3.UseVisualStyleBackColor = true;
            button3.Click += MarksButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(164, 9);
            label1.Name = "label1";
            label1.Size = new Size(242, 45);
            label1.TabIndex = 3;
            label1.Text = "Repairs Statistic";
            // 
            // Statistic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 325);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Statistic";
            Text = "Statistic";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
    }
}