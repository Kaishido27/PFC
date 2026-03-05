using Microsoft.EntityFrameworkCore;
using PFC.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PFC.App.Views
{
    public partial class ReportsView : UserControl
    {
        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        #region Constructor

        public ReportsView()
        {
            InitializeComponent();
            InitializeDateRange();
        }

        private void InitializeDateRange()
        {
            // Default: Last 7 days
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Today;

            cmbDateRange.SelectedIndex = 0; // "Last 7 Days

            // Initial load
            LoadReportsTable();
        }

        #endregion

        // ==========================================
        // DATA LOADING LOGIC
        // ==========================================
        #region Data Loading

        public void LoadReportsTable()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    // 1. Get the dates from the pickers
                    // Set start to midnight and end to 11:59:59 PM to catch the full day
                    DateTime start = dtpStartDate.Value.Date;
                    DateTime end = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);

                    // 2. Fetch orders within the range
                    // Must include details/products/sizes for math properties to work
                    var orders = db.Orders
                                   .Include(o => o.Details)
                                       .ThenInclude(d => d.Product)
                                           .ThenInclude(p => p.SizeOptions)
                                   .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                                   .OrderByDescending(o => o.OrderDate)
                                   .ToList(); // Move to memory for C# math

                    //Calculate for Summary Row
                    decimal grandCost = orders.Sum(o => o.TotalCost);
                    decimal grandRevenue = orders.Sum(o => o.TotalAmount);
                    decimal grandProfit = orders.Sum(o => o.TotalProfit);

                    //  Update Summary Labels
                    lblGrandCost.Text = $"Total Cost: ₱{grandCost:N2}";
                    lblGrandRevenue.Text = $"Total Revenue: ₱{grandRevenue:N2}";
                    lblGrandProfit.Text = $"Total Profit: ₱{grandProfit:N2}";

                    // 3. Project into a readable format for the Grid
                    var reportData = orders.Select(o => new
                    {
                        OrderID = o.Id,
                        Date = o.OrderDate.ToString("MMM dd, yyyy hh:mm tt"),
                        TotalCost = $"₱{o.TotalCost:N2}",
                        Revenue = $"₱{o.TotalAmount:N2}",
                        Profit = $"₱{o.TotalProfit:N2}"
                    }).ToList();

                    // 4. Bind to DataGridView
                    dgvReports.DataSource = reportData;

                    // Clean up UI look
                    dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    // Set individual column widths
                    if (dgvReports.Columns["OrderID"] != null) dgvReports.Columns["OrderID"].Width = 80;
                    if (dgvReports.Columns["Date"] != null) dgvReports.Columns["Date"].Width = 180;
                    if (dgvReports.Columns["TotalCost"] != null) dgvReports.Columns["TotalCost"].Width = 120;
                    if (dgvReports.Columns["Revenue"] != null) dgvReports.Columns["Revenue"].Width = 120;
                    if (dgvReports.Columns["Profit"] != null) dgvReports.Columns["Profit"].Width = 120;

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        // ==========================================
        // FILTERING & UI LOGIC
        // ==========================================
        #region Filter Handlers

        private void CmbDateRange_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var selectedRange = cmbDateRange.SelectedItem?.ToString();

            // Prevent event loop while setting picker values
            dtpStartDate.ValueChanged -= DatePickers_ValueChanged;
            dtpEndDate.ValueChanged -= DatePickers_ValueChanged;

            switch (selectedRange)
            {
                case "Last 7 Days":
                    dtpStartDate.Value = DateTime.Today.AddDays(-7);
                    dtpEndDate.Value = DateTime.Today;
                    break;
                case "Last 30 Days":
                    dtpStartDate.Value = DateTime.Today.AddDays(-30);
                    dtpEndDate.Value = DateTime.Today;
                    break;
                case "This Month":
                    dtpStartDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    dtpEndDate.Value = DateTime.Today;
                    break;
                case "Last Month":
                    var lastMonth = DateTime.Today.AddMonths(-1);
                    dtpStartDate.Value = new DateTime(lastMonth.Year, lastMonth.Month, 1);
                    dtpEndDate.Value = new DateTime(lastMonth.Year, lastMonth.Month, DateTime.DaysInMonth(lastMonth.Year, lastMonth.Month));
                    break;
            }

            // Re-wire events and refresh
            dtpStartDate.ValueChanged += DatePickers_ValueChanged;
            dtpEndDate.ValueChanged += DatePickers_ValueChanged;

            UpdateDateRangeDisplay();
            LoadReportsTable();
        }

        private void DatePickers_ValueChanged(object? sender, EventArgs e)
        {
            // If they manually change the date, switch combo to "Custom Range" if it exists
            if (cmbDateRange.SelectedItem?.ToString() != "Custom Range")
            {
                // Note: Only works if "Custom Range" is an item in your ComboBox
                int index = cmbDateRange.FindStringExact("Custom Range");
                if (index != -1) cmbDateRange.SelectedIndex = index;
            }

            UpdateDateRangeDisplay();
            LoadReportsTable();
        }

        private void UpdateDateRangeDisplay()
        {
            var dateRange = $"{dtpStartDate.Value:MMM dd, yyyy} - {dtpEndDate.Value:MMM dd, yyyy}";
            label3.Text = $"Track your coffee shop's revenue, profit and growth metrics | {dateRange}";
        }

        #endregion

        // ==========================================
        // EXPORT LOGIC
        #region Export

        private void btnExport_Click(object? sender, EventArgs e)
        {
            if (dgvReports.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var saveDialog = new SaveFileDialog
            {
                Filter = "CSV File (*.csv)|*.csv",
                Title = "Export Report",
                FileName = $"CatBrews_Report_{DateTime.Now:yyyyMMdd_HHmmss}.csv"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Headers
                    var headers = dgvReports.Columns.Cast<DataGridViewColumn>();
                    sb.AppendLine(string.Join(",", headers.Select(c => $"\"{c.HeaderText}\"")));

                    // Rows
                    foreach (DataGridViewRow row in dgvReports.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>();
                            sb.AppendLine(string.Join(",", cells.Select(c => $"\"{c.Value?.ToString()}\"")));
                        }
                    }

                    File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Export Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Export failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion
    }
}