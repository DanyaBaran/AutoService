namespace AutoService
{
    partial class FormRepairs
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
            employeeIdTextBox = new TextBox();
            DeleteButton = new Button();
            UpdateButton = new Button();
            contactOwnerTextBox = new TextBox();
            carIdTextBox = new TextBox();
            AddButton = new Button();
            RepairDataGridView = new DataGridView();
            dateBeginTextBox = new TextBox();
            dateEndTextBox = new TextBox();
            carsButton = new Button();
            eployeesButton = new Button();
            repairInfosButton = new Button();
            assemblysButton = new Button();
            repairsButton = new Button();
            panel1 = new Panel();
            label2 = new Label();
            searchTextBox = new TextBox();
            label1 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            panel3 = new Panel();
            label11 = new Label();
            idRepairTextBox = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            refreshLabel = new Label();
            menuStrip1 = new MenuStrip();
            ToolStripMenuItem1 = new ToolStripMenuItem();
            ControlStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            TlsUserStatus = new ToolStripTextBox();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)RepairDataGridView).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // employeeIdTextBox
            // 
            employeeIdTextBox.Location = new Point(175, 43);
            employeeIdTextBox.Name = "employeeIdTextBox";
            employeeIdTextBox.Size = new Size(124, 23);
            employeeIdTextBox.TabIndex = 19;
            // 
            // DeleteButton
            // 
            DeleteButton.Location = new Point(24, 141);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(164, 52);
            DeleteButton.TabIndex = 17;
            DeleteButton.Text = "Delete";
            DeleteButton.UseVisualStyleBackColor = true;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // UpdateButton
            // 
            UpdateButton.Location = new Point(24, 83);
            UpdateButton.Name = "UpdateButton";
            UpdateButton.Size = new Size(164, 52);
            UpdateButton.TabIndex = 16;
            UpdateButton.Text = "Update";
            UpdateButton.UseVisualStyleBackColor = true;
            UpdateButton.Click += UpdateButton_Click;
            // 
            // contactOwnerTextBox
            // 
            contactOwnerTextBox.Location = new Point(175, 101);
            contactOwnerTextBox.Name = "contactOwnerTextBox";
            contactOwnerTextBox.Size = new Size(124, 23);
            contactOwnerTextBox.TabIndex = 15;
            // 
            // carIdTextBox
            // 
            carIdTextBox.Location = new Point(175, 72);
            carIdTextBox.Name = "carIdTextBox";
            carIdTextBox.Size = new Size(124, 23);
            carIdTextBox.TabIndex = 14;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(24, 25);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(164, 52);
            AddButton.TabIndex = 18;
            AddButton.Text = "Add";
            AddButton.Click += AddButton_Click;
            // 
            // RepairDataGridView
            // 
            RepairDataGridView.AllowUserToAddRows = false;
            RepairDataGridView.AllowUserToDeleteRows = false;
            RepairDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RepairDataGridView.Location = new Point(12, 77);
            RepairDataGridView.Name = "RepairDataGridView";
            RepairDataGridView.ReadOnly = true;
            RepairDataGridView.RowTemplate.Height = 25;
            RepairDataGridView.Size = new Size(798, 301);
            RepairDataGridView.TabIndex = 13;
            RepairDataGridView.CellClick += RepairDataGridView_CellClick;
            // 
            // dateBeginTextBox
            // 
            dateBeginTextBox.Location = new Point(175, 130);
            dateBeginTextBox.Name = "dateBeginTextBox";
            dateBeginTextBox.Size = new Size(124, 23);
            dateBeginTextBox.TabIndex = 21;
            // 
            // dateEndTextBox
            // 
            dateEndTextBox.Location = new Point(175, 159);
            dateEndTextBox.Name = "dateEndTextBox";
            dateEndTextBox.Size = new Size(124, 23);
            dateEndTextBox.TabIndex = 22;
            // 
            // carsButton
            // 
            carsButton.Location = new Point(4, 547);
            carsButton.Name = "carsButton";
            carsButton.Size = new Size(194, 37);
            carsButton.TabIndex = 24;
            carsButton.Text = "Cars";
            carsButton.UseVisualStyleBackColor = true;
            carsButton.Click += CarsButton_Click;
            // 
            // eployeesButton
            // 
            eployeesButton.Location = new Point(4, 590);
            eployeesButton.Name = "eployeesButton";
            eployeesButton.Size = new Size(194, 37);
            eployeesButton.TabIndex = 25;
            eployeesButton.Text = "Eployees";
            eployeesButton.UseVisualStyleBackColor = true;
            eployeesButton.Click += EployeesButton_Click;
            // 
            // repairInfosButton
            // 
            repairInfosButton.Location = new Point(4, 460);
            repairInfosButton.Name = "repairInfosButton";
            repairInfosButton.Size = new Size(194, 37);
            repairInfosButton.TabIndex = 26;
            repairInfosButton.Text = "RepairInfos";
            repairInfosButton.UseVisualStyleBackColor = true;
            repairInfosButton.Click += RepairInfosButton_Click;
            // 
            // assemblysButton
            // 
            assemblysButton.Location = new Point(4, 505);
            assemblysButton.Name = "assemblysButton";
            assemblysButton.Size = new Size(194, 37);
            assemblysButton.TabIndex = 27;
            assemblysButton.Text = "Assemblys";
            assemblysButton.UseVisualStyleBackColor = true;
            assemblysButton.Click += AssemblysButton_Click;
            // 
            // repairsButton
            // 
            repairsButton.Location = new Point(4, 417);
            repairsButton.Name = "repairsButton";
            repairsButton.Size = new Size(194, 37);
            repairsButton.TabIndex = 32;
            repairsButton.Text = "Repair";
            repairsButton.UseVisualStyleBackColor = true;
            repairsButton.Click += RepairsButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlDark;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(searchTextBox);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 28);
            panel1.Name = "panel1";
            panel1.Size = new Size(798, 43);
            panel1.TabIndex = 36;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 0;
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(637, 9);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(143, 23);
            searchTextBox.TabIndex = 1;
            searchTextBox.TextChanged += SearchTextBox_TextChanged;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 2;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(DeleteButton);
            panel2.Controls.Add(UpdateButton);
            panel2.Controls.Add(AddButton);
            panel2.Location = new Point(605, 417);
            panel2.Name = "panel2";
            panel2.Size = new Size(207, 216);
            panel2.TabIndex = 37;
            panel2.TabStop = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(605, 381);
            label3.Name = "label3";
            label3.Size = new Size(93, 32);
            label3.TabIndex = 38;
            label3.Text = "Сontrol";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label11);
            panel3.Controls.Add(idRepairTextBox);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label9);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(dateEndTextBox);
            panel3.Controls.Add(dateBeginTextBox);
            panel3.Controls.Add(employeeIdTextBox);
            panel3.Controls.Add(contactOwnerTextBox);
            panel3.Controls.Add(carIdTextBox);
            panel3.Location = new Point(221, 417);
            panel3.Name = "panel3";
            panel3.Size = new Size(313, 216);
            panel3.TabIndex = 39;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(46, 13);
            label11.Name = "label11";
            label11.Size = new Size(68, 20);
            label11.TabIndex = 31;
            label11.Text = "IdRepair:";
            // 
            // idRepairTextBox
            // 
            idRepairTextBox.Location = new Point(175, 14);
            idRepairTextBox.Name = "idRepairTextBox";
            idRepairTextBox.Size = new Size(124, 23);
            idRepairTextBox.TabIndex = 30;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(46, 158);
            label10.Name = "label10";
            label10.Size = new Size(69, 20);
            label10.TabIndex = 29;
            label10.Text = "DateEnd:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(46, 129);
            label9.Name = "label9";
            label9.Size = new Size(82, 20);
            label9.TabIndex = 28;
            label9.Text = "DateBegin:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(46, 100);
            label7.Name = "label7";
            label7.Size = new Size(106, 20);
            label7.TabIndex = 26;
            label7.Text = "ContactOwner:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(46, 71);
            label6.Name = "label6";
            label6.Size = new Size(47, 20);
            label6.TabIndex = 25;
            label6.Text = "CarId:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(46, 42);
            label5.Name = "label5";
            label5.Size = new Size(91, 20);
            label5.TabIndex = 24;
            label5.Text = "EmployeeId:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(221, 381);
            label4.Name = "label4";
            label4.Size = new Size(87, 32);
            label4.TabIndex = 40;
            label4.Text = "Record";
            // 
            // refreshLabel
            // 
            refreshLabel.AutoSize = true;
            refreshLabel.Cursor = Cursors.Hand;
            refreshLabel.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            refreshLabel.Location = new Point(766, 399);
            refreshLabel.Name = "refreshLabel";
            refreshLabel.Size = new Size(46, 15);
            refreshLabel.TabIndex = 3;
            refreshLabel.Text = "Refresh";
            refreshLabel.Click += RefreshLabel_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.Items.AddRange(new ToolStripItem[] { ToolStripMenuItem1, ControlStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(127, 24);
            menuStrip1.TabIndex = 41;
            menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem1
            // 
            ToolStripMenuItem1.Name = "ToolStripMenuItem1";
            ToolStripMenuItem1.Size = new Size(60, 20);
            ToolStripMenuItem1.Text = "Statistic";
            ToolStripMenuItem1.Click += ToolStripMenuItem1_Click;
            // 
            // ControlStripMenuItem
            // 
            ControlStripMenuItem.Name = "ControlStripMenuItem";
            ControlStripMenuItem.Size = new Size(59, 20);
            ControlStripMenuItem.Text = "Сontrol";
            ControlStripMenuItem.Click += ControlStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.None;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { TlsUserStatus });
            toolStrip1.Location = new Point(708, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.RightToLeft = RightToLeft.No;
            toolStrip1.Size = new Size(136, 25);
            toolStrip1.TabIndex = 42;
            toolStrip1.Text = "toolStrip1";
            // 
            // TlsUserStatus
            // 
            TlsUserStatus.Name = "TlsUserStatus";
            TlsUserStatus.ReadOnly = true;
            TlsUserStatus.RightToLeft = RightToLeft.No;
            TlsUserStatus.Size = new Size(100, 25);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(4, 381);
            label8.Name = "label8";
            label8.Size = new Size(130, 32);
            label8.TabIndex = 43;
            label8.Text = "Navigation";
            // 
            // FormRepairs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(816, 636);
            Controls.Add(label8);
            Controls.Add(toolStrip1);
            Controls.Add(refreshLabel);
            Controls.Add(label4);
            Controls.Add(panel3);
            Controls.Add(label3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(repairsButton);
            Controls.Add(assemblysButton);
            Controls.Add(repairInfosButton);
            Controls.Add(eployeesButton);
            Controls.Add(carsButton);
            Controls.Add(RepairDataGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormRepairs";
            Text = "FormRepairs";
            Load += FormRepairs_Load;
            ((System.ComponentModel.ISupportInitialize)RepairDataGridView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox employeeIdTextBox;
        private Button DeleteButton;
        private Button UpdateButton;
        private TextBox contactOwnerTextBox;
        private TextBox carIdTextBox;
        private Button AddButton;
        private DataGridView RepairDataGridView;
        private TextBox dateBeginTextBox;
        private TextBox dateEndTextBox;
        private Button carsButton;
        private Button eployeesButton;
        private Button repairInfosButton;
        private Button assemblysButton;
        private Button repairsButton;
        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox searchTextBox;
        private Panel panel2;
        private Label label3;
        private Panel panel3;
        private Label label4;
        private Label label5;
        private Label label10;
        private Label label9;
        private Label label7;
        private Label label6;
        private Label label11;
        private TextBox idRepairTextBox;
        private Label refreshLabel;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem ToolStripMenuItem1;
        private ToolStripMenuItem ControlStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripTextBox TlsUserStatus;
        private Label label8;
    }
}