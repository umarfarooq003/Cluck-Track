namespace Poultry_Management_System
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainpanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExpenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addSalesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.addExpensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poultryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chicksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deathPoultryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.expensesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deathPoultryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.poultryToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delUsersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.initialReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finalReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainpanel
            // 
            this.mainpanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.mainpanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainpanel.Location = new System.Drawing.Point(0, 40);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1366, 700);
            this.mainpanel.TabIndex = 3;
            this.mainpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainpanel_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dashboardToolStripMenuItem,
            this.addExpenseToolStripMenuItem,
            this.deathPoultryToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.usersToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1366, 40);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dashboardToolStripMenuItem
            // 
            this.dashboardToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dashboardToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dashboardToolStripMenuItem.Image")));
            this.dashboardToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
            this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(137, 36);
            this.dashboardToolStripMenuItem.Text = "Dashboard";
            this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
            // 
            // addExpenseToolStripMenuItem
            // 
            this.addExpenseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addSalesToolStripMenuItem1,
            this.addExpensesToolStripMenuItem,
            this.poultryToolStripMenuItem,
            this.chicksToolStripMenuItem});
            this.addExpenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addExpenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addExpenseToolStripMenuItem.Image")));
            this.addExpenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addExpenseToolStripMenuItem.Name = "addExpenseToolStripMenuItem";
            this.addExpenseToolStripMenuItem.Size = new System.Drawing.Size(85, 36);
            this.addExpenseToolStripMenuItem.Text = "Add";
            this.addExpenseToolStripMenuItem.Click += new System.EventHandler(this.addExpenseToolStripMenuItem_Click);
            // 
            // addSalesToolStripMenuItem1
            // 
            this.addSalesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("addSalesToolStripMenuItem1.Image")));
            this.addSalesToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addSalesToolStripMenuItem1.Name = "addSalesToolStripMenuItem1";
            this.addSalesToolStripMenuItem1.Size = new System.Drawing.Size(166, 38);
            this.addSalesToolStripMenuItem1.Text = " Sales";
            this.addSalesToolStripMenuItem1.Click += new System.EventHandler(this.addSalesToolStripMenuItem1_Click);
            // 
            // addExpensesToolStripMenuItem
            // 
            this.addExpensesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addExpensesToolStripMenuItem.Image")));
            this.addExpensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addExpensesToolStripMenuItem.Name = "addExpensesToolStripMenuItem";
            this.addExpensesToolStripMenuItem.Size = new System.Drawing.Size(166, 38);
            this.addExpensesToolStripMenuItem.Text = "Expenses";
            this.addExpensesToolStripMenuItem.Click += new System.EventHandler(this.addExpensesToolStripMenuItem_Click);
            // 
            // poultryToolStripMenuItem
            // 
            this.poultryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("poultryToolStripMenuItem.Image")));
            this.poultryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.poultryToolStripMenuItem.Name = "poultryToolStripMenuItem";
            this.poultryToolStripMenuItem.Size = new System.Drawing.Size(166, 38);
            this.poultryToolStripMenuItem.Text = "Poultry";
            this.poultryToolStripMenuItem.Click += new System.EventHandler(this.poultryToolStripMenuItem_Click);
            // 
            // chicksToolStripMenuItem
            // 
            this.chicksToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chicksToolStripMenuItem.Image")));
            this.chicksToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.chicksToolStripMenuItem.Name = "chicksToolStripMenuItem";
            this.chicksToolStripMenuItem.Size = new System.Drawing.Size(166, 38);
            this.chicksToolStripMenuItem.Text = "Chicks";
            this.chicksToolStripMenuItem.Click += new System.EventHandler(this.chicksToolStripMenuItem_Click);
            // 
            // deathPoultryToolStripMenuItem
            // 
            this.deathPoultryToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathPoultryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deathPoultryToolStripMenuItem.Image")));
            this.deathPoultryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deathPoultryToolStripMenuItem.Name = "deathPoultryToolStripMenuItem";
            this.deathPoultryToolStripMenuItem.Size = new System.Drawing.Size(161, 36);
            this.deathPoultryToolStripMenuItem.Text = "Death Poultry";
            this.deathPoultryToolStripMenuItem.Click += new System.EventHandler(this.deathPoultryToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem1,
            this.expensesToolStripMenuItem1});
            this.categoriesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("categoriesToolStripMenuItem.Image")));
            this.categoriesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(135, 36);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem1
            // 
            this.salesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("salesToolStripMenuItem1.Image")));
            this.salesToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salesToolStripMenuItem1.Name = "salesToolStripMenuItem1";
            this.salesToolStripMenuItem1.Size = new System.Drawing.Size(166, 38);
            this.salesToolStripMenuItem1.Text = "Sales";
            this.salesToolStripMenuItem1.Click += new System.EventHandler(this.salesToolStripMenuItem1_Click);
            // 
            // expensesToolStripMenuItem1
            // 
            this.expensesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("expensesToolStripMenuItem1.Image")));
            this.expensesToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.expensesToolStripMenuItem1.Name = "expensesToolStripMenuItem1";
            this.expensesToolStripMenuItem1.Size = new System.Drawing.Size(166, 38);
            this.expensesToolStripMenuItem1.Text = "Expenses";
            this.expensesToolStripMenuItem1.Click += new System.EventHandler(this.expensesToolStripMenuItem1_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salesToolStripMenuItem,
            this.expensesToolStripMenuItem,
            this.deathPoultryToolStripMenuItem1,
            this.poultryToolStripMenuItem1});
            this.viewToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewToolStripMenuItem.Image")));
            this.viewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(92, 36);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // salesToolStripMenuItem
            // 
            this.salesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("salesToolStripMenuItem.Image")));
            this.salesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.salesToolStripMenuItem.Name = "salesToolStripMenuItem";
            this.salesToolStripMenuItem.Size = new System.Drawing.Size(199, 38);
            this.salesToolStripMenuItem.Text = "Sales";
            this.salesToolStripMenuItem.Click += new System.EventHandler(this.salesToolStripMenuItem_Click);
            // 
            // expensesToolStripMenuItem
            // 
            this.expensesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("expensesToolStripMenuItem.Image")));
            this.expensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.expensesToolStripMenuItem.Name = "expensesToolStripMenuItem";
            this.expensesToolStripMenuItem.Size = new System.Drawing.Size(199, 38);
            this.expensesToolStripMenuItem.Text = "Expenses";
            this.expensesToolStripMenuItem.Click += new System.EventHandler(this.expensesToolStripMenuItem_Click);
            // 
            // deathPoultryToolStripMenuItem1
            // 
            this.deathPoultryToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("deathPoultryToolStripMenuItem1.Image")));
            this.deathPoultryToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deathPoultryToolStripMenuItem1.Name = "deathPoultryToolStripMenuItem1";
            this.deathPoultryToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.deathPoultryToolStripMenuItem1.Text = "DeathPoultry";
            this.deathPoultryToolStripMenuItem1.Click += new System.EventHandler(this.deathPoultryToolStripMenuItem1_Click);
            // 
            // poultryToolStripMenuItem1
            // 
            this.poultryToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("poultryToolStripMenuItem1.Image")));
            this.poultryToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.poultryToolStripMenuItem1.Name = "poultryToolStripMenuItem1";
            this.poultryToolStripMenuItem1.Size = new System.Drawing.Size(199, 38);
            this.poultryToolStripMenuItem1.Text = "Poultry";
            this.poultryToolStripMenuItem1.Click += new System.EventHandler(this.poultryToolStripMenuItem1_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUsersToolStripMenuItem,
            this.delUsersToolStripMenuItem});
            this.usersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.usersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("usersToolStripMenuItem.Image")));
            this.usersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(95, 36);
            this.usersToolStripMenuItem.Text = "Users";
            // 
            // addUsersToolStripMenuItem
            // 
            this.addUsersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addUsersToolStripMenuItem.Image")));
            this.addUsersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.addUsersToolStripMenuItem.Name = "addUsersToolStripMenuItem";
            this.addUsersToolStripMenuItem.Size = new System.Drawing.Size(172, 38);
            this.addUsersToolStripMenuItem.Text = "Add Users";
            this.addUsersToolStripMenuItem.Click += new System.EventHandler(this.addUsersToolStripMenuItem_Click);
            // 
            // delUsersToolStripMenuItem
            // 
            this.delUsersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("delUsersToolStripMenuItem.Image")));
            this.delUsersToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.delUsersToolStripMenuItem.Name = "delUsersToolStripMenuItem";
            this.delUsersToolStripMenuItem.Size = new System.Drawing.Size(172, 38);
            this.delUsersToolStripMenuItem.Text = "Del Users";
            this.delUsersToolStripMenuItem.Click += new System.EventHandler(this.delUsersToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.initialReportToolStripMenuItem,
            this.finalReportToolStripMenuItem});
            this.reportToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportToolStripMenuItem.Image")));
            this.reportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(105, 36);
            this.reportToolStripMenuItem.Text = "Report";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // initialReportToolStripMenuItem
            // 
            this.initialReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("initialReportToolStripMenuItem.Image")));
            this.initialReportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.initialReportToolStripMenuItem.Name = "initialReportToolStripMenuItem";
            this.initialReportToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.initialReportToolStripMenuItem.Text = "Initial Report";
            this.initialReportToolStripMenuItem.Click += new System.EventHandler(this.initialReportToolStripMenuItem_Click);
            // 
            // finalReportToolStripMenuItem
            // 
            this.finalReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("finalReportToolStripMenuItem.Image")));
            this.finalReportToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.finalReportToolStripMenuItem.Name = "finalReportToolStripMenuItem";
            this.finalReportToolStripMenuItem.Size = new System.Drawing.Size(196, 38);
            this.finalReportToolStripMenuItem.Text = "Final Report";
            this.finalReportToolStripMenuItem.Click += new System.EventHandler(this.finalReportToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.resetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("resetToolStripMenuItem.Image")));
            this.resetToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(95, 36);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(83, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 740);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainpanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExpenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deathPoultryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem expensesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deathPoultryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addSalesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addExpensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poultryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem delUsersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poultryToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chicksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem initialReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finalReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
    }
}