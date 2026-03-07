namespace PFC.App
{
    partial class DashboardView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            pnlDailySales = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            lblDailySales = new Label();
            label4 = new Label();
            gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            lblTotalRevenue = new Label();
            pnlTotalRevenue = new Label();
            pnlTotalProfit = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            lblTotalProfit = new Label();
            label6 = new Label();
            gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            dgvRecentTransactions = new DataGridView();
            label5 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlDailySales).BeginInit();
            pnlDailySales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel2).BeginInit();
            gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlTotalProfit).BeginInit();
            pnlTotalProfit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).BeginInit();
            gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentTransactions).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Beige;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1105, 66);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 16);
            label1.Name = "label1";
            label1.Size = new Size(236, 31);
            label1.TabIndex = 0;
            label1.Text = "Dashboard Overview";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(52, 58);
            label3.Name = "label3";
            label3.Size = new Size(283, 25);
            label3.TabIndex = 2;
            label3.Text = "Here is what is happening today....";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 20);
            label2.Name = "label2";
            label2.Size = new Size(311, 38);
            label2.TabIndex = 1;
            label2.Text = "Welcome to Cat Brews";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            tableLayoutPanel1.Controls.Add(panel2, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlDailySales, 0, 1);
            tableLayoutPanel1.Controls.Add(gradientPanel2, 1, 1);
            tableLayoutPanel1.Controls.Add(pnlTotalProfit, 2, 1);
            tableLayoutPanel1.Controls.Add(gradientPanel1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 66);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 0, 10, 5);
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 435F));
            tableLayoutPanel1.Size = new Size(1105, 687);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            tableLayoutPanel1.SetColumnSpan(panel2, 3);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(13, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1079, 114);
            panel2.TabIndex = 0;
            // 
            // pnlDailySales
            // 
            pnlDailySales.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Color.Snow);
            pnlDailySales.BorderColor = Color.White;
            pnlDailySales.Controls.Add(lblDailySales);
            pnlDailySales.Controls.Add(label4);
            pnlDailySales.Dock = DockStyle.Fill;
            pnlDailySales.Location = new Point(13, 123);
            pnlDailySales.Name = "pnlDailySales";
            pnlDailySales.Size = new Size(355, 114);
            pnlDailySales.TabIndex = 1;
            // 
            // lblDailySales
            // 
            lblDailySales.AutoSize = true;
            lblDailySales.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDailySales.Location = new Point(50, 48);
            lblDailySales.Name = "lblDailySales";
            lblDailySales.Size = new Size(33, 38);
            lblDailySales.TabIndex = 3;
            lblDailySales.Text = "0";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 13);
            label4.Name = "label4";
            label4.Size = new Size(96, 25);
            label4.TabIndex = 3;
            label4.Text = "Daily Sales";
            // 
            // gradientPanel2
            // 
            gradientPanel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, Color.WhiteSmoke, Color.Beige);
            gradientPanel2.BorderColor = Color.White;
            gradientPanel2.Controls.Add(lblTotalRevenue);
            gradientPanel2.Controls.Add(pnlTotalRevenue);
            gradientPanel2.Dock = DockStyle.Fill;
            gradientPanel2.Location = new Point(374, 123);
            gradientPanel2.Name = "gradientPanel2";
            gradientPanel2.Size = new Size(355, 114);
            gradientPanel2.TabIndex = 2;
            // 
            // lblTotalRevenue
            // 
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.BackColor = Color.Transparent;
            lblTotalRevenue.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRevenue.Location = new Point(53, 48);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new Size(33, 38);
            lblTotalRevenue.TabIndex = 4;
            lblTotalRevenue.Text = "0";
            // 
            // pnlTotalRevenue
            // 
            pnlTotalRevenue.AutoSize = true;
            pnlTotalRevenue.BackColor = Color.Transparent;
            pnlTotalRevenue.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlTotalRevenue.Location = new Point(28, 13);
            pnlTotalRevenue.Name = "pnlTotalRevenue";
            pnlTotalRevenue.Size = new Size(120, 25);
            pnlTotalRevenue.TabIndex = 4;
            pnlTotalRevenue.Text = "Total Revenue";
            // 
            // pnlTotalProfit
            // 
            pnlTotalProfit.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, Color.Bisque, Color.FromArgb(75, 54, 33));
            pnlTotalProfit.BorderColor = Color.White;
            pnlTotalProfit.Controls.Add(lblTotalProfit);
            pnlTotalProfit.Controls.Add(label6);
            pnlTotalProfit.Dock = DockStyle.Fill;
            pnlTotalProfit.Location = new Point(735, 123);
            pnlTotalProfit.Name = "pnlTotalProfit";
            pnlTotalProfit.Size = new Size(357, 114);
            pnlTotalProfit.TabIndex = 3;
            // 
            // lblTotalProfit
            // 
            lblTotalProfit.AutoSize = true;
            lblTotalProfit.BackColor = Color.Transparent;
            lblTotalProfit.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalProfit.Location = new Point(52, 48);
            lblTotalProfit.Name = "lblTotalProfit";
            lblTotalProfit.Size = new Size(33, 38);
            lblTotalProfit.TabIndex = 5;
            lblTotalProfit.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(36, 13);
            label6.Name = "label6";
            label6.Size = new Size(97, 25);
            label6.TabIndex = 5;
            label6.Text = "Total Profit";
            // 
            // gradientPanel1
            // 
            gradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, Color.WhiteSmoke, Color.Beige);
            tableLayoutPanel1.SetColumnSpan(gradientPanel1, 2);
            gradientPanel1.Controls.Add(dgvRecentTransactions);
            gradientPanel1.Controls.Add(label5);
            gradientPanel1.Controls.Add(label7);
            gradientPanel1.Dock = DockStyle.Fill;
            gradientPanel1.Location = new Point(13, 243);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.Size = new Size(716, 436);
            gradientPanel1.TabIndex = 4;
            // 
            // dgvRecentTransactions
            // 
            dgvRecentTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRecentTransactions.BackgroundColor = SystemColors.ControlLightLight;
            dgvRecentTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentTransactions.Location = new Point(22, 87);
            dgvRecentTransactions.Name = "dgvRecentTransactions";
            dgvRecentTransactions.RowHeadersWidth = 51;
            dgvRecentTransactions.Size = new Size(657, 324);
            dgvRecentTransactions.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(33, 37);
            label5.Name = "label5";
            label5.Size = new Size(186, 23);
            label5.TabIndex = 4;
            label5.Text = "Last orders processed...";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(22, 9);
            label7.Name = "label7";
            label7.Size = new Size(201, 28);
            label7.TabIndex = 3;
            label7.Text = "Recent Transactions";
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Name = "DashboardView";
            Size = new Size(1105, 753);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlDailySales).EndInit();
            pnlDailySales.ResumeLayout(false);
            pnlDailySales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel2).EndInit();
            gradientPanel2.ResumeLayout(false);
            gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlTotalProfit).EndInit();
            pnlTotalProfit.ResumeLayout(false);
            pnlTotalProfit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).EndInit();
            gradientPanel1.ResumeLayout(false);
            gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        private Syncfusion.Windows.Forms.Tools.GradientPanel pnlDailySales;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.GradientPanel pnlTotalProfit;
        private Label label4;
        private Label pnlTotalRevenue;
        private Label label6;
        private Label lblDailySales;
        private Label lblTotalRevenue;
        private Label lblTotalProfit;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private Label label5;
        private Label label7;
        private DataGridView dgvRecentTransactions;
    }
}
