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
            lblGrandCost = new Label();
            lblGrandRevenue = new Label();
            lblGrandProfit = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).BeginInit();
            gradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.Linen;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(860, 8);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(140, 32);
            btnExport.TabIndex = 4;
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
            panel1.Size = new Size(1105, 66);
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
            gradientPanel1.BackgroundColor = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.ForwardDiagonal, Color.Beige, Color.Bisque);
            gradientPanel1.BorderColor = Color.Transparent;
            gradientPanel1.Controls.Add(btnExport);
            gradientPanel1.Controls.Add(cmbDateRange);
            gradientPanel1.Controls.Add(dtpEndDate);
            gradientPanel1.Controls.Add(lblSeparator);
            gradientPanel1.Controls.Add(dtpStartDate);
            gradientPanel1.Location = new Point(40, 164);
            gradientPanel1.Name = "gradientPanel1";
            gradientPanel1.Size = new Size(1028, 55);
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
            dgvReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReports.Location = new Point(40, 281);
            dgvReports.Name = "dgvReports";
            dgvReports.RowHeadersWidth = 51;
            dgvReports.Size = new Size(673, 281);
            dgvReports.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.Location = new Point(40, 241);
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
            panel2.Location = new Point(40, 559);
            panel2.Name = "panel2";
            panel2.Size = new Size(673, 54);
            panel2.TabIndex = 8;
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
            // ReportsView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            Controls.Add(panel2);
            Controls.Add(label4);
            Controls.Add(dgvReports);
            Controls.Add(gradientPanel1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "ReportsView";
            Size = new Size(1105, 832);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gradientPanel1).EndInit();
            gradientPanel1.ResumeLayout(false);
            gradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReports).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
    }
}
