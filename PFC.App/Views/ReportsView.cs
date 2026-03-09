using PFC.App.Helper;
using PFC.App.Helpers;
using PFC.Domain.Models;
using PFC.Services;
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
            InitializeTopProductsGrid();
        }

        private void InitializeSummaryCards()
        {
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
            chartRevenueProfitTrends.SmoothingMode = SmoothingMode.AntiAlias;
            chartRevenueProfitTrends.TextRenderingHint = TextRenderingHint.AntiAlias;
            chartRevenueProfitTrends.ChartArea.PrimaryXAxis.Font = new Font("Segoe UI", 9F);
            chartRevenueProfitTrends.ChartArea.PrimaryYAxis.Font = new Font("Segoe UI", 9F);
            chartRevenueProfitTrends.Legend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chartRevenueProfitTrends.ShowToolTips = true;
        }

        private void InitializeDateRange()
        {
            dtpStartDate.Value = DateTime.Today.AddDays(-7);
            dtpEndDate.Value = DateTime.Today;
            cmbDateRange.SelectedIndex = 0;
            LoadReportsTable();
        }

        private void InitializeTopProductsGrid()
        {
            // Configure the grid
            dgvTopProducts.AutoGenerateColumns = false;
            dgvTopProducts.AllowUserToAddRows = false;
            dgvTopProducts.AllowUserToDeleteRows = false;
            dgvTopProducts.ReadOnly = true;
            dgvTopProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTopProducts.RowHeadersVisible = false;
            dgvTopProducts.BackgroundColor = Color.White;
            dgvTopProducts.BorderStyle = BorderStyle.None;
            dgvTopProducts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 230, 250);
            dgvTopProducts.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTopProducts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvTopProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
            dgvTopProducts.EnableHeadersVisualStyles = false;

            // Clear any existing columns first
            dgvTopProducts.Columns.Clear();

            // Define columns manually
            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Product",
                HeaderText = "Product",
                DataPropertyName = "Product",
                Width = 200,
                DefaultCellStyle = new DataGridViewCellStyle { Padding = new Padding(10, 5, 5, 5) }
            });

            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Category",
                HeaderText = "Category",
                DataPropertyName = "Category",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnitsSold",
                HeaderText = "Units Sold",
                DataPropertyName = "UnitsSold",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvTopProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "TotalRevenue",
                HeaderText = "Total Revenue",
                DataPropertyName = "TotalRevenue",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Add row styling event
            dgvTopProducts.CellFormatting += DgvTopProducts_CellFormatting;
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
                // Checks if the application is currently running inside the Visual Studio Designer
                if (UIHelper.IsDesignMode()) return;

                var orderService = new OrderService();
                DateTime start = dtpStartDate.Value.Date;
                DateTime end = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);

                var orders = orderService.GetOrdersByDateRange(start, end);

                decimal grandCost = orders.Sum(o => o.TotalCost);
                decimal grandRevenue = orders.Sum(o => o.TotalAmount);
                decimal grandProfit = orders.Sum(o => o.TotalProfit);
                decimal avgorderValue = orders.Count > 0 ? orders.Average(o => o.TotalAmount) : 0;

                if (lblGrandCost != null) lblGrandCost.Text = $"Total Cost: ₱{grandCost:N2}";
                if (lblGrandRevenue != null) lblGrandRevenue.Text = $"Total Revenue: ₱{grandRevenue:N2}";
                if (lblGrandProfit != null) lblGrandProfit.Text = $"Total Profit: ₱{grandProfit:N2}";

                UpdateSummaryCards(grandRevenue, grandProfit, grandCost, avgorderValue);
                UpdateRevenueProfitChart(orders);

                var reportData = orders.Select(o => new
                {
                    OrderID = o.Id,
                    Date = o.OrderDate.ToString("MMM dd, yyyy hh:mm tt"),
                    PaymentMethod = o.PaymentMethod,
                    TotalCost = $"₱{o.TotalCost:N2}",
                    Revenue = $"₱{o.TotalAmount:N2}",
                    Profit = $"₱{o.TotalProfit:N2}"
                }).ToList();

                dgvReports.DataSource = reportData;

                // Apply global formatting from our UIHelper
                UIHelper.FormatStandardGrid(dgvReports);
                dgvReports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                if (dgvReports.Columns["OrderID"] != null) dgvReports.Columns["OrderID"].Width = 75;
                if (dgvReports.Columns["Date"] != null) dgvReports.Columns["Date"].Width = 175;
                if (dgvReports.Columns["PaymentMethod"] != null) dgvReports.Columns["PaymentMethod"].Width = 140;
                if (dgvReports.Columns["TotalCost"] != null) dgvReports.Columns["TotalCost"].Width = 100;
                if (dgvReports.Columns["Revenue"] != null) dgvReports.Columns["Revenue"].Width = 100;
                if (dgvReports.Columns["Profit"] != null) dgvReports.Columns["Profit"].Width = 80;

                // Inject dynamic delete column if missing
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

                if (dgvReports.Columns["DeleteAction"] != null)
                {
                    dgvReports.Columns["DeleteAction"].DisplayIndex = dgvReports.Columns.Count - 1;
                }

                // Load top selling products data
                LoadTopSellingProducts(orders);
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Error loading report: {ex.Message}");
            }
        }

        private void LoadTopSellingProducts(List<Order> orders)
        {
            try
            {
                // Flatten all order details from the orders
                var productStats = orders
                    .SelectMany(o => o.Details)
                    .Where(d => d.Product != null)
                    .GroupBy(d => new
                    {
                        ProductId = d.ProductId,
                        ProductName = d.Product!.Name,
                        Category = d.Product.Category.ToString()
                    })
                    .Select(g => new
                    {
                        Product = g.Key.ProductName,
                        Category = g.Key.Category,
                        UnitsSold = g.Sum(d => d.Quantity),
                        TotalRevenue = $"₱{g.Sum(d => d.TotalLinePrice):N2}"
                    })
                    .OrderByDescending(p => p.UnitsSold)
                    .Take(10) // Top 10 products
                    .ToList();

                dgvTopProducts.DataSource = productStats;

                // Refresh to apply formatting
                dgvTopProducts.Refresh();
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Error loading top products: {ex.Message}");
            }
        }

        private void UpdateSummaryCards(decimal revenue, decimal profit, decimal cost, decimal avgOrder)
        {
            if (lblRevenueValue != null) lblRevenueValue.Text = $"₱{revenue:N2}";
            if (lblProfitValue != null) lblProfitValue.Text = $"₱{profit:N2}";
            if (lblCostValue != null) lblCostValue.Text = $"₱{cost:N2}";
            if (lblAvgOrderValue != null) lblAvgOrderValue.Text = $"₱{avgOrder:N2}";
        }
        #endregion

        // ==========================================
        // CHART UPDATE LOGIC
        // ==========================================
        #region Chart Updates
        private void UpdateRevenueProfitChart(List<Order> orders)
        {
            try
            {
                if (chartRevenueProfitTrends.Series.Count < 2) return;

                chartRevenueProfitTrends.Series[0].Points.Clear();
                chartRevenueProfitTrends.Series[1].Points.Clear();

                if (!orders.Any())
                {
                    chartRevenueProfitTrends.Text = "No data available for the selected date range";
                    chartRevenueProfitTrends.Refresh();
                    return;
                }

                chartRevenueProfitTrends.Text = "Revenue & Profit Trends";

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

                foreach (var day in dailyData)
                {
                    string dateLabel = day.Date.ToString("MMM dd");
                    chartRevenueProfitTrends.Series[0].Points.Add(dateLabel, (double)day.Revenue);
                    chartRevenueProfitTrends.Series[1].Points.Add(dateLabel, (double)day.Profit);
                }

                chartRevenueProfitTrends.Series[0].Style.DisplayText = false;
                chartRevenueProfitTrends.Series[1].Style.DisplayText = false;

                chartRevenueProfitTrends.Series[0].Style.Symbol.Shape = ChartSymbolShape.Circle;
                chartRevenueProfitTrends.Series[0].Style.Symbol.Size = new Size(8, 8);
                chartRevenueProfitTrends.Series[0].Style.Symbol.Color = Color.FromArgb(255, 183, 77);

                chartRevenueProfitTrends.Series[1].Style.Symbol.Shape = ChartSymbolShape.Circle;
                chartRevenueProfitTrends.Series[1].Style.Symbol.Size = new Size(8, 8);
                chartRevenueProfitTrends.Series[1].Style.Symbol.Color = Color.FromArgb(129, 199, 132);

                if (dailyData.Any())
                {
                    var maxValue = Math.Max(
                        dailyData.Max(d => d.Revenue),
                        dailyData.Max(d => d.Profit)
                    );

                    double maxRange = (double)(maxValue * 1.1m);
                    double interval = maxRange / 10;

                    chartRevenueProfitTrends.PrimaryYAxis.RangeType = ChartAxisRangeType.Set;
                    chartRevenueProfitTrends.PrimaryYAxis.Range = new MinMaxInfo(0, maxRange, interval);
                }

                chartRevenueProfitTrends.Refresh();
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Error updating chart: {ex.Message}");
            }
        }
        #endregion

        // ==========================================
        // GRID FORMATTING
        // ==========================================
        #region Grid Formatting
        private void DgvTopProducts_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTopProducts.Columns[e.ColumnIndex].Name == "Category" && e.Value != null)
            {
                // Add styled category badges with colors matching your ProductView categories
                var category = e.Value.ToString();
                e.CellStyle.Font = new Font("Segoe UI", 8F);
                e.CellStyle.BackColor = category switch
                {
                    "IcedCoffee" => Color.FromArgb(227, 242, 253),      // Light Blue
                    "HotCoffee" => Color.FromArgb(255, 243, 224),       // Light Orange
                    "FlavoredMilk" => Color.FromArgb(255, 235, 238),    // Light Pink
                    "Matcha" => Color.FromArgb(232, 245, 233),          // Light Green
                    "Soda" => Color.FromArgb(255, 249, 196),            // Light Yellow
                    _ => Color.FromArgb(245, 245, 245)
                };
            }

            // Highlight the #1 top product row with a gold background
            if (e.RowIndex == 0)
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 249, 196); // Gold
                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
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

            dtpStartDate.ValueChanged += DatePickers_ValueChanged;
            dtpEndDate.ValueChanged += DatePickers_ValueChanged;

            UpdateDateRangeDisplay();
            LoadReportsTable();
        }

        private void DatePickers_ValueChanged(object? sender, EventArgs e)
        {
            if (cmbDateRange.SelectedItem?.ToString() != "Custom Range")
            {
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

        private void dgvReports_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var col = dgvReports.Columns[e.ColumnIndex];

            if (col.Name == "DeleteAction")
            {
                // Calls our centralized security helper
                if (!SecurityHelper.IsAuthorized()) return;

                int orderId = (int)dgvReports.Rows[e.RowIndex].Cells["OrderID"].Value;

                // Calls our centralized confirmation popup
                if (UIHelper.Confirm($"Are you sure you want to permanently delete Order #{orderId}?\n\nThis will remove it from your revenue charts and cannot be undone."))
                {
                    try
                    {
                        var orderService = new OrderService();
                        orderService.DeleteOrder(orderId);

                        MessageBox.Show("Order successfully deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadReportsTable();
                    }
                    catch (Exception ex)
                    {
                        UIHelper.ShowError($"Failed to delete order: {ex.Message}");
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

                    sb.AppendLine("=== SUMMARY REPORT ===");
                    sb.AppendLine($"\"Date Range\",\"{dtpStartDate.Value:MMM dd, yyyy} - {dtpEndDate.Value:MMM dd, yyyy}\"");
                    sb.AppendLine($"\"Total Revenue\",\"{lblRevenueValue?.Text}\"");
                    sb.AppendLine($"\"Total Profit\",\"{lblProfitValue?.Text}\"");
                    sb.AppendLine($"\"Total Cost\",\"{lblCostValue?.Text}\"");
                    sb.AppendLine($"\"Average Order Value\",\"{lblAvgOrderValue?.Text}\"");
                    sb.AppendLine();
                    sb.AppendLine("=== TRANSACTION DETAILS ===");

                    var headers = dgvReports.Columns.Cast<DataGridViewColumn>();
                    sb.AppendLine(string.Join(",", headers.Select(c => $"\"{c.HeaderText}\"")));

                    foreach (DataGridViewRow row in dgvReports.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>();
                            // Uses FormattedValue so enums display correctly
                            sb.AppendLine(string.Join(",", cells.Select(c => $"\"{c.FormattedValue?.ToString()}\"")));
                        }
                    }

                    // Add Top Selling Products section
                    sb.AppendLine();
                    sb.AppendLine("=== TOP SELLING PRODUCTS ===");

                    var topHeaders = dgvTopProducts.Columns.Cast<DataGridViewColumn>();
                    sb.AppendLine(string.Join(",", topHeaders.Select(c => $"\"{c.HeaderText}\"")));

                    foreach (DataGridViewRow row in dgvTopProducts.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>();
                            sb.AppendLine(string.Join(",", cells.Select(c => $"\"{c.FormattedValue?.ToString()}\"")));
                        }
                    }

                    File.WriteAllText(saveDialog.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Export Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    UIHelper.ShowError($"Export failed: {ex.Message}");
                }
            }
        }

        #endregion
    }
}