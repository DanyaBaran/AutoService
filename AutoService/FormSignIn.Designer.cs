namespace AutoService
{
    partial class FormSignIn
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
            SignInButton = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            passwordTextBox = new TextBox();
            logInTextBox = new TextBox();
            SuspendLayout();
            // 
            // SignInButton
            // 
            SignInButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SignInButton.Location = new Point(314, 304);
            SignInButton.Name = "SignInButton";
            SignInButton.Size = new Size(165, 39);
            SignInButton.TabIndex = 11;
            SignInButton.Text = "Sign In";
            SignInButton.UseVisualStyleBackColor = true;
            SignInButton.Click += SignInButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(332, 81);
            label3.Name = "label3";
            label3.Size = new Size(127, 30);
            label3.TabIndex = 10;
            label3.Text = "Registration";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(246, 206);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 9;
            label2.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(257, 152);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 8;
            label1.Text = "Login";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Location = new Point(332, 207);
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.Size = new Size(132, 23);
            passwordTextBox.TabIndex = 7;
            // 
            // logInTextBox
            // 
            logInTextBox.Location = new Point(332, 153);
            logInTextBox.Name = "logInTextBox";
            logInTextBox.Size = new Size(132, 23);
            logInTextBox.TabIndex = 6;
            // 
            // FormSignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SignInButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(passwordTextBox);
            Controls.Add(logInTextBox);
            Name = "FormSignIn";
            Text = "FormSignIn";
            Load += FormSignIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SignInButton;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox passwordTextBox;
        private TextBox logInTextBox;
    }
}