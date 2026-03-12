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
            Syncfusion.Windows.Forms.Chart.ChartSeries chartSeries1 = new Syncfusion.Windows.Forms.Chart.ChartSeries();
            Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo chartCustomShapeInfo1 = new Syncfusion.Windows.Forms.Chart.ChartCustomShapeInfo();
            Syncfusion.Windows.Forms.Chart.ChartLineInfo chartLineInfo1 = new Syncfusion.Windows.Forms.Chart.ChartLineInfo();
            panel1 = new Panel();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            pnlDailySales = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            lblDailySales = new Label();
            label4 = new Label();
            gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            lblTotalRevenue = new Label();
            pnlTotalRevenue = new Label();
            pnlTotalProfit = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            lblTotalProfit = new Label();
            label6 = new Label();
            panel3 = new Panel();
            dgvRecentTransactions = new DataGridView();
            gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            label5 = new Label();
            label7 = new Label();
            chartHourlyPulse = new Syncfusion.Windows.Forms.Chart.ChartControl();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pnlDailySales).BeginInit();
            pnlDailySales.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel2).BeginInit();
            gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnlTotalProfit).BeginInit();
            pnlTotalProfit.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentTransactions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).BeginInit();
            gradientPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(2, 132, 199);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1363, 66);
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
            label3.Location = new Point(212, 64);
            label3.Name = "label3";
            label3.Size = new Size(283, 25);
            label3.TabIndex = 2;
            label3.Text = "Here is what is happening today....";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(140, 18);
            label2.Name = "label2";
            label2.Size = new Size(376, 46);
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
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 66);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(10, 0, 10, 5);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            tableLayoutPanel1.Size = new Size(1363, 260);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel2
            // 
            tableLayoutPanel1.SetColumnSpan(panel2, 3);
            panel2.Controls.Add(pictureBox1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(13, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1337, 114);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logo_goldIcon;
            pictureBox1.Location = new Point(35, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(103, 108);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // pnlDailySales
            // 
            pnlDailySales.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Horizontal, Color.FromArgb(219, 234, 254), Color.FromArgb(191, 219, 254));
            pnlDailySales.BorderColor = Color.White;
            pnlDailySales.Controls.Add(lblDailySales);
            pnlDailySales.Controls.Add(label4);
            pnlDailySales.Dock = DockStyle.Fill;
            pnlDailySales.Location = new Point(13, 123);
            pnlDailySales.Name = "pnlDailySales";
            pnlDailySales.Size = new Size(441, 129);
            pnlDailySales.TabIndex = 1;
            // 
            // lblDailySales
            // 
            lblDailySales.AutoSize = true;
            lblDailySales.BackColor = Color.Transparent;
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
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 13);
            label4.Name = "label4";
            label4.Size = new Size(96, 25);
            label4.TabIndex = 3;
            label4.Text = "Daily Sales";
            // 
            // gradientPanel2
            // 
            gradientPanel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Horizontal, Color.FromArgb(147, 197, 253), Color.FromArgb(96, 165, 250));
            gradientPanel2.BorderColor = Color.White;
            gradientPanel2.Controls.Add(lblTotalRevenue);
            gradientPanel2.Controls.Add(pnlTotalRevenue);
            gradientPanel2.Dock = DockStyle.Fill;
            gradientPanel2.Location = new Point(460, 123);
            gradientPanel2.Name = "gradientPanel2";
            gradientPanel2.Size = new Size(441, 129);
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
            pnlTotalProfit.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Horizontal, Color.FromArgb(59, 130, 246), Color.FromArgb(37, 99, 235));
            pnlTotalProfit.BorderColor = Color.White;
            pnlTotalProfit.Controls.Add(lblTotalProfit);
            pnlTotalProfit.Controls.Add(label6);
            pnlTotalProfit.Dock = DockStyle.Fill;
            pnlTotalProfit.Location = new Point(907, 123);
            pnlTotalProfit.Name = "pnlTotalProfit";
            pnlTotalProfit.Size = new Size(443, 129);
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
            // panel3
            // 
            panel3.Controls.Add(gradientPanel1);
            panel3.Controls.Add(chartHourlyPulse);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 326);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10, 0, 10, 10);
            panel3.Size = new Size(1363, 427);
            panel3.TabIndex = 2;
            // 
            // dgvRecentTransactions
            // 
            dgvRecentTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvRecentTransactions.BackgroundColor = SystemColors.ControlLightLight;
            dgvRecentTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentTransactions.Location = new Point(22, 63);
            dgvRecentTransactions.Name = "dgvRecentTransactions";
            dgvRecentTransactions.RowHeadersWidth = 51;
            dgvRecentTransactions.Size = new Size(537, 317);
            dgvRecentTransactions.TabIndex = 5;
            // 
            // gradientPanel1
            // 
            gradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, Color.FromArgb(224, 242, 254), Color.FromArgb(248, 250, 252));
            gradientPanel1.Controls.Add(dgvRecentTransactions);
            gradientPanel1.Controls.Add(label5);
            gradientPanel1.Controls.Add(label7);
            gradientPanel1.Dock = DockStyle.Fill;
            gradientPanel1.Location = new Point(10, 0);
            gradientPanel1.Margin = new Padding(3, 3, 10, 3);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.Size = new Size(590, 417);
            gradientPanel1.TabIndex = 8;
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
            // chartHourlyPulse
            // 
            chartHourlyPulse.BackInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, Color.Transparent, Color.White);
            chartHourlyPulse.ChartArea.AutoScale = true;
            chartHourlyPulse.ChartArea.BackInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, Color.Transparent, Color.Transparent);
            chartHourlyPulse.ChartArea.CursorLocation = new Point(0, 0);
            chartHourlyPulse.ChartArea.CursorReDraw = false;
            chartHourlyPulse.ChartInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, Color.Transparent, Color.Transparent);
            chartHourlyPulse.Dock = DockStyle.Right;
            // 
            // 
            // 
            chartHourlyPulse.Legend.Location = new Point(0, 0);
            chartHourlyPulse.Legend.Visible = false;
            chartHourlyPulse.Location = new Point(600, 0);
            chartHourlyPulse.Name = "chartHourlyPulse";
            chartHourlyPulse.PrimaryXAxis.Font = new Font("Segoe UI", 8F);
            chartHourlyPulse.PrimaryXAxis.GridLineType.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartHourlyPulse.PrimaryXAxis.GridLineType.ForeColor = Color.FromArgb(147, 197, 253);
            chartHourlyPulse.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            chartHourlyPulse.PrimaryXAxis.Margin = true;
            chartHourlyPulse.PrimaryXAxis.Title = "Time (Hour)";
            chartHourlyPulse.PrimaryXAxis.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            chartHourlyPulse.PrimaryXAxis.ValueType = Syncfusion.Windows.Forms.Chart.ChartValueType.Category;
            chartHourlyPulse.PrimaryYAxis.Font = new Font("Segoe UI", 8F);
            chartHourlyPulse.PrimaryYAxis.Format = "₱#,##0.00";
            chartHourlyPulse.PrimaryYAxis.GridLineType.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            chartHourlyPulse.PrimaryYAxis.GridLineType.ForeColor = Color.FromArgb(147, 197, 253);
            chartHourlyPulse.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            chartHourlyPulse.PrimaryYAxis.Margin = true;
            chartHourlyPulse.PrimaryYAxis.Title = "Sales (₱)";
            chartHourlyPulse.PrimaryYAxis.TitleFont = new Font("Segoe UI", 9F, FontStyle.Bold);
            chartSeries1.FancyToolTip.ResizeInsideSymbol = true;
            chartSeries1.Name = "HourlySales";
            chartSeries1.Resolution = 0D;
            chartSeries1.StackingGroup = "Default Group";
            chartSeries1.Style.AltTagFormat = "";
            chartSeries1.Style.Border.Color = Color.FromArgb(59, 130, 246);
            chartSeries1.Style.Border.Width = 3F;
            chartSeries1.Style.DisplayText = false;
            chartSeries1.Style.DrawTextShape = false;
            chartSeries1.Style.Interior = new Syncfusion.Drawing.BrushInfo(Color.FromArgb(150, 96, 165, 250));
            chartLineInfo1.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
            chartLineInfo1.Color = SystemColors.ControlText;
            chartLineInfo1.DashPattern = null;
            chartLineInfo1.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            chartLineInfo1.Width = 1F;
            chartCustomShapeInfo1.Border = chartLineInfo1;
            chartCustomShapeInfo1.Color = SystemColors.HighlightText;
            chartCustomShapeInfo1.Type = Syncfusion.Windows.Forms.Chart.ChartCustomShape.Square;
            chartSeries1.Style.TextShape = chartCustomShapeInfo1;
            chartSeries1.Text = "Hourly Sales";
            chartSeries1.Type = Syncfusion.Windows.Forms.Chart.ChartSeriesType.SplineArea;
            chartHourlyPulse.Series.Add(chartSeries1);
            chartHourlyPulse.ShowLegend = false;
            chartHourlyPulse.Size = new Size(753, 417);
            chartHourlyPulse.TabIndex = 9;
            chartHourlyPulse.Text = "Hourly Sales Pulse";
            chartHourlyPulse.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            // 
            // 
            // 
            chartHourlyPulse.Title.Name = "Default";
            chartHourlyPulse.Titles.Add(chartHourlyPulse.Title);
            // 
            // DashboardView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            Controls.Add(panel3);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Name = "DashboardView";
            Size = new Size(1363, 753);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pnlDailySales).EndInit();
            pnlDailySales.ResumeLayout(false);
            pnlDailySales.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel2).EndInit();
            gradientPanel2.ResumeLayout(false);
            gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pnlTotalProfit).EndInit();
            pnlTotalProfit.ResumeLayout(false);
            pnlTotalProfit.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRecentTransactions).EndInit();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).EndInit();
            gradientPanel1.ResumeLayout(false);
            gradientPanel1.PerformLayout();
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
        private PictureBox pictureBox1;
        private Panel panel3;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private DataGridView dgvRecentTransactions;
        private Label label5;
        private Label label7;
        private Syncfusion.Windows.Forms.Chart.ChartControl chartHourlyPulse;
    }
}
