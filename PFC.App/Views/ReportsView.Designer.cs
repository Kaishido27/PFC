namespace PFC.App.Views
{
    partial class ReportsView
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
            btnExport = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            cmbDateRange = new ComboBox();
            dtpEndDate = new DateTimePicker();
            lblSeparator = new Label();
            dtpStartDate = new DateTimePicker();
            dgvReports = new DataGridView();
            label4 = new Label();
            panel2 = new Panel();
            lblGrandProfit = new Label();
            lblGrandRevenue = new Label();
            lblGrandCost = new Label();
            groupBox1 = new GroupBox();
            gradientPanel2 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            label5 = new Label();
            gradientPanel3 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            label6 = new Label();
            gradientPanel4 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            label7 = new Label();
            gradientPanel5 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            label8 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).BeginInit();
            gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            panel2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel2).BeginInit();
            gradientPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel3).BeginInit();
            gradientPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel4).BeginInit();
            gradientPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel5).BeginInit();
            gradientPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.Linen;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.Black;
            btnExport.Location = new Point(1115, 7);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 32);
            btnExport.TabIndex = 4;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Beige;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1363, 66);
            panel1.Size = new Size(1345, 66);
            panel1.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 16);
            label1.Name = "label1";
            label1.Size = new Size(247, 31);
            label1.TabIndex = 0;
            label1.Text = "Reports and Analytics";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.Location = new Point(35, 84);
            label2.Name = "label2";
            label2.Size = new Size(281, 37);
            label2.TabIndex = 3;
            label2.Text = "Business Preformace";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.Location = new Point(40, 126);
            label3.Name = "label3";
            label3.Size = new Size(403, 20);
            label3.TabIndex = 4;
            label3.Text = "Track your coffee shop's revenue, profit and growth metrics ";
            // 
            // gradientPanel1
            // 
            gradientPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, Color.Beige, Color.Bisque);
            gradientPanel1.Border3DStyle = Border3DStyle.Flat;
            gradientPanel1.BorderColor = Color.Transparent;
            gradientPanel1.Controls.Add(btnExport);
            gradientPanel1.Controls.Add(cmbDateRange);
            gradientPanel1.Controls.Add(dtpEndDate);
            gradientPanel1.Controls.Add(lblSeparator);
            gradientPanel1.Controls.Add(dtpStartDate);
            gradientPanel1.Location = new Point(40, 164);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.Size = new Size(1274, 55);
            gradientPanel1.TabIndex = 5;
            // 
            // cmbDateRange
            // 
            cmbDateRange.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDateRange.FormattingEnabled = true;
            cmbDateRange.Items.AddRange(new object[] { "Last 7 Days", "Last 14 Days", "Last 30 Days", "Last 3 Months", "This Month", "Last Month", "This Year", "Custom Range" });
            cmbDateRange.Location = new Point(360, 10);
            cmbDateRange.Name = "cmbDateRange";
            cmbDateRange.Size = new Size(150, 28);
            cmbDateRange.TabIndex = 3;
            cmbDateRange.SelectedIndexChanged += CmbDateRange_SelectedIndexChanged;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(215, 10);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(130, 27);
            dtpEndDate.TabIndex = 2;
            dtpEndDate.ValueChanged += DatePickers_ValueChanged;
            // 
            // lblSeparator
            // 
            lblSeparator.AutoSize = true;
            lblSeparator.BackColor = Color.Transparent;
            lblSeparator.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSeparator.Location = new Point(190, 12);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new Size(17, 23);
            lblSeparator.TabIndex = 1;
            lblSeparator.Text = "-";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(50, 10);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(130, 27);
            dtpStartDate.TabIndex = 0;
            dtpStartDate.ValueChanged += DatePickers_ValueChanged;
            // 
            // dgvReports
            // 
            dgvReports.BackgroundColor = SystemColors.ControlLightLight;
            dgvReports.BorderStyle = BorderStyle.None;
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(2, 26);
            dgvReports.Location = new Point(35, 453);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersWidth = 51;
            dgvReports.Size = new Size(673, 278);
            dgvReports.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.Location = new Point(25, 413);
            label4.Name = "label4";
            label4.Size = new Size(268, 37);
            label4.TabIndex = 7;
            label4.Text = "Transaction History";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Bisque;
            panel2.Controls.Add(lblGrandProfit);
            panel2.Controls.Add(lblGrandRevenue);
            panel2.Controls.Add(lblGrandCost);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(3, 303);
            panel2.Location = new Point(35, 731);
            panel2.Name = "panel2";
            panel2.Size = new Size(672, 54);
            panel2.TabIndex = 8;
            // 
            // lblGrandProfit
            // 
            lblGrandProfit.AutoSize = true;
            lblGrandProfit.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGrandProfit.Location = new Point(457, 20);
            lblGrandProfit.Name = "lblGrandProfit";
            lblGrandProfit.Size = new Size(84, 20);
            lblGrandProfit.TabIndex = 2;
            lblGrandProfit.Text = "Total Profit";
            // 
            // lblGrandRevenue
            // 
            lblGrandRevenue.AutoSize = true;
            lblGrandRevenue.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGrandRevenue.Location = new Point(242, 20);
            lblGrandRevenue.Name = "lblGrandRevenue";
            lblGrandRevenue.Size = new Size(105, 20);
            lblGrandRevenue.TabIndex = 1;
            lblGrandRevenue.Text = "Total Revenue";
            // 
            // lblGrandCost
            // 
            lblGrandCost.AutoSize = true;
            lblGrandCost.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGrandCost.Location = new Point(52, 20);
            lblGrandCost.Name = "lblGrandCost";
            lblGrandCost.Size = new Size(75, 20);
            lblGrandCost.TabIndex = 0;
            lblGrandCost.Text = "Total Cost";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvReports);
            groupBox1.Controls.Add(panel2);
            groupBox1.Location = new Point(40, 301);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(678, 360);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            // 
            // gradientPanel2
            // 
            gradientPanel2.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, SystemColors.WindowText, SystemColors.Window);
            gradientPanel2.Border3DStyle = Border3DStyle.Flat;
            gradientPanel2.BorderColor = Color.Transparent;
            gradientPanel2.Controls.Add(label5);
            gradientPanel2.Location = new Point(40, 244);
            gradientPanel2.Name = "gradientPanel2";
            gradientPanel2.Size = new Size(280, 100);
            gradientPanel2.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(16, 13);
            label5.Name = "label5";
            label5.Size = new Size(118, 23);
            label5.TabIndex = 11;
            label5.Text = "Total Revenue";
            // 
            // gradientPanel3
            // 
            gradientPanel3.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, SystemColors.WindowText, SystemColors.Window);
            gradientPanel3.Border3DStyle = Border3DStyle.Flat;
            gradientPanel3.BorderColor = Color.Transparent;
            gradientPanel3.Controls.Add(label6);
            gradientPanel3.Location = new Point(338, 244);
            gradientPanel3.Name = "gradientPanel3";
            gradientPanel3.Size = new Size(280, 100);
            gradientPanel3.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(22, 13);
            label6.Name = "label6";
            label6.Size = new Size(93, 23);
            label6.TabIndex = 12;
            label6.Text = "Total Profit";
            // 
            // gradientPanel4
            // 
            gradientPanel4.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, SystemColors.WindowText, SystemColors.Window);
            gradientPanel4.Border3DStyle = Border3DStyle.Flat;
            gradientPanel4.BorderColor = Color.Transparent;
            gradientPanel4.Controls.Add(label7);
            gradientPanel4.Location = new Point(636, 244);
            gradientPanel4.Name = "gradientPanel4";
            gradientPanel4.Size = new Size(280, 100);
            gradientPanel4.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(13, 13);
            label7.Name = "label7";
            label7.Size = new Size(85, 23);
            label7.TabIndex = 13;
            label7.Text = "Total Cost";
            // 
            // gradientPanel5
            // 
            gradientPanel5.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.None, SystemColors.WindowText, SystemColors.Window);
            gradientPanel5.Border3DStyle = Border3DStyle.Flat;
            gradientPanel5.BorderColor = Color.Transparent;
            gradientPanel5.Controls.Add(label8);
            gradientPanel5.Location = new Point(936, 244);
            gradientPanel5.Name = "gradientPanel5";
            gradientPanel5.Size = new Size(280, 100);
            gradientPanel5.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(18, 13);
            label8.Name = "label8";
            label8.Size = new Size(145, 23);
            label8.TabIndex = 13;
            label8.Text = " Avg. Order Value";
            // 
            // ReportsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(groupBox1);
            BackColor = Color.White;
            Controls.Add(gradientPanel5);
            Controls.Add(gradientPanel4);
            Controls.Add(gradientPanel3);
            Controls.Add(gradientPanel2);
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(gradientPanel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "ReportsView";
            Size = new Size(1363, 832);
            Size = new Size(1345, 905);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).EndInit();
            gradientPanel1.ResumeLayout(false);
            gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gradientPanel2).EndInit();
            gradientPanel2.ResumeLayout(false);
            gradientPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel3).EndInit();
            gradientPanel3.ResumeLayout(false);
            gradientPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel4).EndInit();
            gradientPanel4.ResumeLayout(false);
            gradientPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel5).EndInit();
            gradientPanel5.ResumeLayout(false);
            gradientPanel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private DateTimePicker dtpStartDate;
        private Label lblSeparator;
        private DateTimePicker dtpEndDate;
        private ComboBox cmbDateRange;
        private Button btnExport;
        private DataGridView dgvReports;
        private Label label4;
        private Panel panel2;
        private Label lblGrandCost;
        private Label lblGrandProfit;
        private Label lblGrandRevenue;
        private GroupBox groupBox1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel2;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel3;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel4;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel5;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}
