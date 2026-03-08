using Microsoft.EntityFrameworkCore;
using PFC.App.Forms;
using PFC.Domain.Models;
using PFC.Infrastructure;
using Syncfusion.Windows.Forms.Chart;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PFC.App.Views
{
    public partial class ReportsView : UserControl
    {
        // ==========================================
        // FIELDS
        // ==========================================
        #region Fields
        private Label? lblRevenueValue;
        private Label? lblProfitValue;
        private Label? lblCostValue;
        private Label? lblAvgOrderValue;

        #endregion
        // ==========================================
        // CONSTRUCTOR
        // ==========================================
        #region Constructor

        public ReportsView()
        {
            InitializeComponent();
            InitializeSummaryCards();
            InitializeChartSettings();
            InitializeDateRange();
        }

        private void InitializeSummaryCards()
        {
            // Create value labels for each summary card
            lblRevenueValue = CreateValueLabel(gradientPanel2);
            lblProfitValue = CreateValueLabel(gradientPanel3);
            lblCostValue = CreateValueLabel(gradientPanel4);
            lblAvgOrderValue = CreateValueLabel(gradientPanel5);
        }

        private Label CreateValueLabel(Syncfusion.Windows.Forms.Tools.GradientPanel parentPanel)
        {
            var valueLabel = new Label
            {
                AutoSize = false,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(16, 45),
                Size = new Size(250, 40),
                Text = "₱0.00",
                TextAlign = ContentAlignment.MiddleLeft
            };

            parentPanel.Controls.Add(valueLabel);
            return valueLabel;
        }

        private void InitializeChartSettings()
        {
            // Smooth rendering
            chartRevenueProfitTrends.SmoothingMode = SmoothingMode.AntiAlias;
            chartRevenueProfitTrends.TextRenderingHint = TextRenderingHint.AntiAlias;

            // Visual enhancements
            chartRevenueProfitTrends.ChartArea.PrimaryXAxis.Font = new Font("Segoe UI", 9F);
            chartRevenueProfitTrends.ChartArea.PrimaryYAxis.Font = new Font("Segoe UI", 9F);
            chartRevenueProfitTrends.Legend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Enable tooltips
            chartRevenueProfitTrends.ShowToolTips = true;
        }

        private void InitializeDateRange()
        {
            // Default: Last 7 days
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Today;

            cmbDateRange.SelectedIndex = 0; // "Last 7 Days"

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
                    decimal avgorderValue = orders.Count > 0 ? orders.Average(o => o.TotalAmount) : 0;

                    //  Update Summary Labels (Bottom panel)
                    lblGrandCost.Text = $"Total Cost: ₱{grandCost:N2}";
                    lblGrandRevenue.Text = $"Total Revenue: ₱{grandRevenue:N2}";
                    lblGrandProfit.Text = $"Total Profit: ₱{grandProfit:N2}";

                    //Update Summary Cards (Top panel)
                    UpdateSummaryCards(grandRevenue, grandProfit, grandCost, avgorderValue);

                    // Update Chart
                    UpdateRevenueProfitChart(orders);

                    // 3. Project into a readable format for the Grid
                    var reportData = orders.Select(o => new
                    {
                        OrderID = o.Id,
                        Date = o.OrderDate.ToString("MMM dd, yyyy hh:mm tt"),
                        PaymentMethod = o.PaymentMethod,
                        TotalCost = $"₱{o.TotalCost:N2}",
                        Revenue = $"₱{o.TotalAmount:N2}",
                        Profit = $"₱{o.TotalProfit:N2}"
                    }).ToList();

                    // 4. Bind to DataGridView
                    dgvReports.DataSource = reportData;

                    // Clean up UI look
                    dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                    dgvReports.RowHeadersVisible = false;

                    // Set individual column widths
                    if (dgvReports.Columns["OrderID"] != null) dgvReports.Columns["OrderID"].Width = 75;
                    if (dgvReports.Columns["Date"] != null) dgvReports.Columns["Date"].Width = 175;
                    if (dgvReports.Columns["PaymentMethod"] != null) dgvReports.Columns["PaymentMethod"].Width = 140;
                    if (dgvReports.Columns["TotalCost"] != null) dgvReports.Columns["TotalCost"].Width = 100;
                    if (dgvReports.Columns["Revenue"] != null) dgvReports.Columns["Revenue"].Width = 100;
                    if (dgvReports.Columns["Profit"] != null) dgvReports.Columns["Profit"].Width = 80;

                    if (dgvReports.Columns["DeleteAction"] == null)
                    {
                        var deleteCol = new DataGridViewButtonColumn
                        {
                            Name = "DeleteAction",
                            HeaderText = "Action",
                            Text = "Delete",
                            UseColumnTextForButtonValue = true,
                            Width = 80,
                            FlatStyle = FlatStyle.Flat
                        };
                        deleteCol.DefaultCellStyle.ForeColor = Color.IndianRed;
                        dgvReports.Columns.Add(deleteCol);
                    }

                    // Force the Delete button to stay at the very end of the grid
                    if (dgvReports.Columns["DeleteAction"] != null)
                    {
                        dgvReports.Columns["DeleteAction"].DisplayIndex = dgvReports.Columns.Count - 1;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSummaryCards(decimal revenue, decimal profit, decimal cost, decimal avgOrder)
        {
            if (lblRevenueValue != null)
                lblRevenueValue.Text = $"₱{revenue:N2}";

            if (lblProfitValue != null)
                lblProfitValue.Text = $"₱{profit:N2}";

            if (lblCostValue != null)
                lblCostValue.Text = $"₱{cost:N2}";

            if (lblAvgOrderValue != null)
                lblAvgOrderValue.Text = $"₱{avgOrder:N2}";
        }

        #endregion

        // ==========================================
        // CHART UPDATE LOGIC
        // ==========================================
        #region Chart Updates

        private void UpdateRevenueProfitChart(List<PFC.Domain.Models.Order> orders)
        {
            try
            {
                // Check if series exist
                if (chartRevenueProfitTrends.Series.Count < 2)
                    return;

                // Clear existing data points
                chartRevenueProfitTrends.Series[0].Points.Clear(); // Revenue
                chartRevenueProfitTrends.Series[1].Points.Clear(); // Profit

                if (!orders.Any())
                {
                    // Show empty state
                    chartRevenueProfitTrends.Text = "No data available for the selected date range";
                    chartRevenueProfitTrends.Refresh();
                    return;
                }

                // Clear empty state message
                chartRevenueProfitTrends.Text = "Revenue & Profit Trends";

                // Group by date and sum revenue/profit
                var dailyData = orders
                    .GroupBy(o => o.OrderDate.Date)
                    .OrderBy(g => g.Key)
                    .Select(g => new
                    {
                        Date = g.Key,
                        Revenue = g.Sum(o => o.TotalAmount),
                        Profit = g.Sum(o => o.TotalProfit)
                    })
                    .ToList();

                // Add data points to chart
                foreach (var day in dailyData)
                {
                    string dateLabel = day.Date.ToString("MMM dd");

                    // Add Revenue point
                    chartRevenueProfitTrends.Series[0].Points.Add(dateLabel, (double)day.Revenue);

                    // Add Profit point
                    chartRevenueProfitTrends.Series[1].Points.Add(dateLabel, (double)day.Profit);
                }

                // Configure display
                chartRevenueProfitTrends.Series[0].Style.DisplayText = false;
                chartRevenueProfitTrends.Series[1].Style.DisplayText = false;

                // Enable point markers
                chartRevenueProfitTrends.Series[0].Style.Symbol.Shape = ChartSymbolShape.Circle;
                chartRevenueProfitTrends.Series[0].Style.Symbol.Size = new Size(8, 8);
                chartRevenueProfitTrends.Series[0].Style.Symbol.Color = Color.FromArgb(255, 183, 77);

                chartRevenueProfitTrends.Series[1].Style.Symbol.Shape = ChartSymbolShape.Circle;
                chartRevenueProfitTrends.Series[1].Style.Symbol.Size = new Size(8, 8);
                chartRevenueProfitTrends.Series[1].Style.Symbol.Color = Color.FromArgb(129, 199, 132);

                // Auto-scale Y-axis with proper range
                if (dailyData.Any())
                {
                    var maxValue = Math.Max(
                        dailyData.Max(d => d.Revenue),
                        dailyData.Max(d => d.Profit)
                    );

                    double maxRange = (double)(maxValue * 1.1m); // 10% padding
                    double interval = maxRange / 10; // 10 divisions

                    chartRevenueProfitTrends.PrimaryYAxis.RangeType = ChartAxisRangeType.Set;
                    chartRevenueProfitTrends.PrimaryYAxis.Range = new MinMaxInfo(0, maxRange, interval);
                }

                // Refresh the chart
                chartRevenueProfitTrends.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating chart: {ex.Message}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private bool IsAuthorized()
        {
            using (var auth = new AuthForm())
            {
                // Pops up your PIN pad. Returns true if they get it right.
                return auth.ShowDialog() == DialogResult.OK;
            }
        }

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore clicks on header rows
            if (e.RowIndex < 0) return;

            var col = dgvReports.Columns[e.ColumnIndex];

            // Check if they clicked the Delete button column
            if (col.Name == "DeleteAction")
            {
                // 1. SECURITY CHECK: Pop the AuthForm first!
                if (!IsAuthorized()) return;

                // 2. Grab the OrderID from the clicked row
                int orderId = (int)dgvReports.Rows[e.RowIndex].Cells["OrderID"].Value;

                // 3. Final Warning
                var confirm = MessageBox.Show(
                    $"Are you sure you want to permanently delete Order #{orderId}?\n\nThis will remove it from your revenue charts and cannot be undone.",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using var db = new AppDbContext();

                        // Fetch the order AND its details so EF Core wipes everything clean
                        var orderToDelete = db.Orders
                                              .Include(o => o.Details)
                                              .FirstOrDefault(o => o.Id == orderId);

                        if (orderToDelete != null)
                        {
                            db.Orders.Remove(orderToDelete);
                            db.SaveChanges();

                            MessageBox.Show("Order successfully deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Reload the table and charts to instantly update the dashboard totals
                            LoadReportsTable();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to delete order: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        #endregion

        // ==========================================
        // EXPORT LOGIC
        // ==========================================
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

                    // Add summary section to export
                    sb.AppendLine("=== SUMMARY REPORT ===");
                    sb.AppendLine($"\"Date Range\",\"{dtpStartDate.Value:MMM dd, yyyy} - {dtpEndDate.Value:MMM dd, yyyy}\"");
                    sb.AppendLine($"\"Total Revenue\",\"{lblRevenueValue?.Text}\"");
                    sb.AppendLine($"\"Total Profit\",\"{lblProfitValue?.Text}\"");
                    sb.AppendLine($"\"Total Cost\",\"{lblCostValue?.Text}\"");
                    sb.AppendLine($"\"Average Order Value\",\"{lblAvgOrderValue?.Text}\"");
                    sb.AppendLine();
                    sb.AppendLine("=== TRANSACTION DETAILS ===");

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