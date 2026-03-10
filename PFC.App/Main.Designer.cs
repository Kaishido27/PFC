namespace PFC.App
{
    partial class Main
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
            pnlSideBar = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            ProductTab = new Syncfusion.WinForms.Controls.SfButton();
            DashboardTab = new Syncfusion.WinForms.Controls.SfButton();
            Report = new Syncfusion.WinForms.Controls.SfButton();
            pictureBox1 = new PictureBox();
            pnlMainContent = new Panel();
            pnlSideBar.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlSideBar
            // 
            pnlSideBar.BackColor = SystemColors.ControlLight;
            pnlSideBar.Controls.Add(tableLayoutPanel1);
            pnlSideBar.Dock = DockStyle.Right;
            pnlSideBar.Location = new Point(1363, 0);
            pnlSideBar.Name = "pnlSideBar";
            pnlSideBar.Size = new Size(346, 753);
            pnlSideBar.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(ProductTab, 0, 3);
            tableLayoutPanel1.Controls.Add(DashboardTab, 0, 2);
            tableLayoutPanel1.Controls.Add(Report, 0, 4);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.ForeColor = SystemColors.ButtonHighlight;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 127F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(346, 753);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // ProductTab
            // 
            ProductTab.Dock = DockStyle.Fill;
            ProductTab.FlatStyle = FlatStyle.Flat;
            ProductTab.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProductTab.ForeColor = Color.Black;
            ProductTab.ImageAlign = ContentAlignment.MiddleLeft;
            ProductTab.ImageSize = new Size(50, 50);
            ProductTab.Location = new Point(3, 225);
            ProductTab.Name = "ProductTab";
            ProductTab.Padding = new Padding(10, 0, 0, 0);
            ProductTab.Size = new Size(340, 69);
            ProductTab.Style.ForeColor = Color.Black;
            ProductTab.Style.Image = Properties.Resources.edc;
            ProductTab.TabIndex = 2;
            ProductTab.Text = "Products";
            ProductTab.TextAlign = ContentAlignment.MiddleLeft;
            ProductTab.Click += ProductTab_Click;
            // 
            // DashboardTab
            // 
            DashboardTab.Dock = DockStyle.Fill;
            DashboardTab.FlatStyle = FlatStyle.Flat;
            DashboardTab.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DashboardTab.ForeColor = Color.Black;
            DashboardTab.ImageAlign = ContentAlignment.MiddleLeft;
            DashboardTab.ImageSize = new Size(35, 35);
            DashboardTab.Location = new Point(3, 150);
            DashboardTab.Name = "DashboardTab";
            DashboardTab.Padding = new Padding(10, 0, 0, 0);
            DashboardTab.Size = new Size(340, 69);
            DashboardTab.Style.ForeColor = Color.Black;
            DashboardTab.Style.Image = Properties.Resources.layout;
            DashboardTab.TabIndex = 1;
            DashboardTab.Text = "Dashboard";
            DashboardTab.TextAlign = ContentAlignment.MiddleLeft;
            DashboardTab.TextMargin = new Padding(10, 3, 3, 3);
            DashboardTab.Click += DashboardTab_Click;
            // 
            // Report
            // 
            Report.Dock = DockStyle.Fill;
            Report.FlatStyle = FlatStyle.Flat;
            Report.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Report.ForeColor = Color.Black;
            Report.ImageAlign = ContentAlignment.MiddleLeft;
            Report.ImageSize = new Size(40, 40);
            Report.Location = new Point(3, 300);
            Report.Name = "Report";
            Report.Padding = new Padding(10, 0, 0, 0);
            Report.Size = new Size(340, 69);
            Report.Style.FocusedForeColor = Color.Black;
            Report.Style.ForeColor = Color.Black;
            Report.Style.Image = Properties.Resources.Reports;
            Report.Style.PressedForeColor = Color.Black;
            Report.TabIndex = 3;
            Report.Text = "Reports";
            Report.TextAlign = ContentAlignment.MiddleLeft;
            Report.TextMargin = new Padding(10, 3, 3, 3);
            Report.Click += Report_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.logo_main;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(340, 121);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // pnlMainContent
            // 
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new Point(0, 0);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new Size(1363, 753);
            pnlMainContent.TabIndex = 3;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1709, 753);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlSideBar);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main";
            pnlSideBar.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlSideBar;
        private Syncfusion.WinForms.Controls.SfButton DashboardTab;
        private Syncfusion.WinForms.Controls.SfButton ProductTab;
        private TableLayoutPanel tableLayoutPanel1;
        private Syncfusion.WinForms.Controls.SfButton Report;
        private Panel pnlMainContent;
        private PictureBox pictureBox1;
    }
}