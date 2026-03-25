using ClosedXML.Excel;
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
using ClosedXML;

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

            // Format Y-axis to show 2 decimal places
            chartRevenueProfitTrends.PrimaryYAxis.ValueType = ChartValueType.Double;
            chartRevenueProfitTrends.PrimaryYAxis.LabelIntersectAction = ChartLabelIntersectAction.None;
            chartRevenueProfitTrends.PrimaryYAxis.Format = "₱#,##0.00";

            chartRevenueProfitTrends.Legend.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chartRevenueProfitTrends.ShowToolTips = true;

            if (chartRevenueProfitTrends.Series.Count >= 2)
            {
                chartRevenueProfitTrends.Series[0].Text = "Revenue (Blue)";
                chartRevenueProfitTrends.Series[1].Text = "Profit (Green)";
            }
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
                      // USE HELPER: Turns "IcedCoffee" into "Iced Coffee"
                      Category = UIHelper.FormatEnumName(g.Key.Category),
                      UnitsSold = g.Sum(d => d.Quantity),
                      TotalRevenue = $"₱{g.Sum(d => d.TotalLinePrice):N2}"
                  })
                  .OrderByDescending(p => p.UnitsSold)
                  .Take(10)
                  .ToList();

                dgvTopProducts.DataSource = productStats;
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

                // Move legend to top-right, outside the chart area
                chartRevenueProfitTrends.Legend.Position = ChartDock.Right;
                chartRevenueProfitTrends.LegendPosition = ChartDock.Right;
                chartRevenueProfitTrends.Legend.Alignment = ChartAlignment.Near; // Near = Top
                chartRevenueProfitTrends.Legend.Orientation = Syncfusion.Windows.Forms.Chart.ChartOrientation.Vertical;

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

                // Configure Revenue series (Blue) - Lower opacity, renders FIRST (behind)
                chartRevenueProfitTrends.Series[0].Type = ChartSeriesType.SplineArea;
                chartRevenueProfitTrends.Series[0].Style.DisplayText = false;

                // More transparent blue fill (50% opacity) - so green shows on top
                chartRevenueProfitTrends.Series[0].Style.Interior = new Syncfusion.Drawing.BrushInfo(
          Color.FromArgb(130, 174, 217, 224)); // 130 = 50% opacity

                // Solid blue border
                chartRevenueProfitTrends.Series[0].Style.Border.Color = Color.FromArgb(174, 217, 224);
                chartRevenueProfitTrends.Series[0].Style.Border.Width = 3F;

                chartRevenueProfitTrends.Series[0].Style.Symbol.Shape = ChartSymbolShape.Circle;
                chartRevenueProfitTrends.Series[0].Style.Symbol.Size = new Size(8, 8);
                chartRevenueProfitTrends.Series[0].Style.Symbol.Color = Color.FromArgb(174, 217, 224);

                // Set Z-Order: Revenue behind (lower)
                chartRevenueProfitTrends.Series[0].ZOrder = 0;

                // Configure Profit series (Green) - Renders SECOND (in front)
                chartRevenueProfitTrends.Series[1].Type = ChartSeriesType.SplineArea;
                chartRevenueProfitTrends.Series[1].Style.DisplayText = false;

                // Semi-transparent green fill (60% opacity) - shows on top
                chartRevenueProfitTrends.Series[1].Style.Interior = new Syncfusion.Drawing.BrushInfo(
          Color.FromArgb(150, 76, 175, 80)); // 150 = 60% opacity

                // Solid green border
                chartRevenueProfitTrends.Series[1].Style.Border.Color = Color.FromArgb(76, 175, 80);
                chartRevenueProfitTrends.Series[1].Style.Border.Width = 3F;

                chartRevenueProfitTrends.Series[1].Style.Symbol.Shape = ChartSymbolShape.Circle;
                chartRevenueProfitTrends.Series[1].Style.Symbol.Size = new Size(8, 8);
                chartRevenueProfitTrends.Series[1].Style.Symbol.Color = Color.FromArgb(76, 175, 80);

                // Set Z-Order: Profit in front (higher)
                chartRevenueProfitTrends.Series[1].ZOrder = 1;

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
                var category = e.Value.ToString();
                e.CellStyle.Font = new Font("Segoe UI", 8F);
                e.CellStyle.BackColor = category switch
                {
                    // Added spaces to match the newly formatted names!
                    "Iced Coffee" => Color.FromArgb(227, 242, 253),
                    "Hot Coffee" => Color.FromArgb(255, 243, 224),
                    "Flavored Milk" => Color.FromArgb(255, 235, 238),
                    "Matcha" => Color.FromArgb(232, 245, 233),
                    "Soda" => Color.FromArgb(255, 249, 196),
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

        private void _orderDetailToolTip_Popup(object sender, PopupEventArgs e)
        {
            // Tell Windows how big the blue box should be
            string text = _orderDetailToolTip.GetToolTip(e.AssociatedControl);
            using (Font f = new Font("Segoe UI", 9))
            {
                Size s = TextRenderer.MeasureText(text, f);
                e.ToolTipSize = new Size(s.Width + 20, s.Height + 20);
            }
        }

        private void _orderDetailToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            // Draw the Blue Background
            e.Graphics.Clear(Color.FromArgb(0, 122, 204));

            // Draw a thin White Border
            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1);
            }

            // Draw the White Text
            TextRenderer.DrawText(e.Graphics, e.ToolTipText, e.Font,
        new Rectangle(10, 10, e.Bounds.Width, e.Bounds.Height),
        Color.White, TextFormatFlags.Default);
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

        private void dgvReports_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Ignore headers
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                // Get the OrderID from the cell
                var cellValue = dgvReports.Rows[e.RowIndex].Cells["OrderID"].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int orderId))
                {
                    // Check if we are already showing this specific Order ID to stop flickering
                    string currentTitle = $"ORDER #{orderId} ITEMS";
                    if (_orderDetailToolTip.GetToolTip(dgvReports).StartsWith(currentTitle))
                        return;
                    // 1. Fetch the data (Service Layer)
                    var orderService = new OrderService();
                    var order = orderService.GetFullOrderData(DateTime.MinValue, DateTime.MaxValue)
                                .FirstOrDefault(o => o.Id == orderId);

                    if (order != null)
                    {
                        // 2. Build the string
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"ORDER #{orderId} ITEMS");
                        sb.AppendLine("--------------------------");
                        foreach (var detail in order.Details)
                        {
                            sb.AppendLine($"{detail.Quantity}x {detail.Product?.Name} ({detail.SelectedSize.ToFriendlyString()})");
                        }

                        // 3. FORCE it to show immediately at the mouse position
                        Point mousePos = dgvReports.PointToClient(Cursor.Position);
                        mousePos.Offset(35, 15); // Move it slightly so it doesn't flicker under the cursor

                        _orderDetailToolTip.SetToolTip(dgvReports, sb.ToString());
                    }
                }
            }
            catch
            {
                // If anything goes wrong during data fetch or drawing, 
                // hide the tooltip so we don't show incorrect info.
                _orderDetailToolTip.Hide(dgvReports);
            }
        }

        private void dgvReports_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            // Hide it as soon as the mouse leaves the cell
            _orderDetailToolTip.Hide(dgvReports);
        }
        #endregion

        // ==========================================
        // EXPORT LOGIC
        // ==========================================
        #region Export
        private void btnExport_Click(object? sender, EventArgs e)
        {
            // 1. Capture Date Range from UI
            var start = dtpStartDate.Value.Date;
            var end = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);

            // 2. Fetch Data via Service Layer
            var orderService = new OrderService();
            var orders = orderService.GetFullOrderData(start, end);

            if (!orders.Any())
            {
                UIHelper.ShowWarning("No data found for the selected range.");
                return;
            }

            // 3. Setup Save Dialog
            using var saveDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = $"CatBrews_BusinessReport_{DateTime.Now:yyyyMMdd}.xlsx",
                Title = "Export Business Report"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var sheet = workbook.Worksheets.Add("Business Report");
                        var orderRows = new List<int>(); // To track rows for formulas

                        // ==========================================
                        // SECTION 1: SUMMARY REPORT "CARD"
                        // ==========================================
                        sheet.Cell("A1").Value = "=== SUMMARY REPORT ===";
                        sheet.Range("A1:B1").Merge().Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromHtml("#F2F2F2"));

                        sheet.Cell("A2").Value = "Date Range:";
                        sheet.Cell("B2").Value = $"{start:MMM dd, yyyy} - {end:MMM dd, yyyy}";

                        sheet.Cell("A3").Value = "Total Revenue:";
                        sheet.Cell("A4").Value = "Total Profit:";
                        sheet.Cell("A5").Value = "Total Cost:";
                        sheet.Cell("A6").Value = "Average Order:";

                        // Style the Summary Card
                        sheet.Range("A2:A6").Style.Font.SetBold();
                        sheet.Range("A1:B6").Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                        // ==========================================
                        // SECTION 2: TRANSACTION HISTORY & DETAILS
                        // ==========================================
                        int currentRow = 9;
                        sheet.Cell(currentRow, 1).Value = "=== TRANSACTION HISTORY & DETAILS ===";
                        sheet.Range(currentRow, 1, currentRow, 6).Merge().Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromHtml("#F2F2F2"));
                        sheet.Range(currentRow, 1, currentRow, 6).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                        currentRow++;
                        string[] transHeaders = { "OrderID", "Timestamp", "Payment", "Cost", "Revenue", "Profit" };
                        for (int i = 0; i < transHeaders.Length; i++)
                        {
                            var cell = sheet.Cell(currentRow, i + 1);
                            cell.Value = transHeaders[i];
                            cell.Style.Font.SetBold().Border.SetBottomBorder(XLBorderStyleValues.Thin);
                        }

                        currentRow++;
                        foreach (var o in orders)
                        {
                            // Track this specific row index for the Summary Formulas later
                            orderRows.Add(currentRow);

                            sheet.Cell(currentRow, 1).Value = o.Id;
                            sheet.Cell(currentRow, 2).Value = o.OrderDate.ToString("MM/dd HH:mm");
                            sheet.Cell(currentRow, 3).Value = o.PaymentMethod.ToString();
                            sheet.Cell(currentRow, 4).Value = o.TotalCost;
                            sheet.Cell(currentRow, 5).Value = o.TotalAmount;

                            // EXCEL FORMULA: Profit = Revenue - Cost
                            sheet.Cell(currentRow, 6).FormulaA1 = $"E{currentRow}-D{currentRow}";

                            sheet.Range(currentRow, 1, currentRow, 6).Style.Font.SetBold();
                            sheet.Range(currentRow, 4, currentRow, 6).Style.NumberFormat.Format = "₱#,##0.00";
                            currentRow++;

                            // Itemized Details (Indented sub-rows)
                            foreach (var detail in o.Details)
                            {
                                sheet.Cell(currentRow, 2).Value = $"   ↳ {detail.Product?.Name} ({detail.SelectedSize.ToFriendlyString()})";
                                sheet.Cell(currentRow, 2).Style.Font.SetItalic().Font.FontColor = XLColor.SlateGray;

                                var addOns = (detail.AddOns != null && detail.AddOns.Any())
                                      ? " + " + string.Join(", ", detail.AddOns.Select(a => UIHelper.FormatEnumName(a.ToString())))
                                      : "";

                                sheet.Cell(currentRow, 3).Value = addOns;
                                sheet.Cell(currentRow, 5).Value = detail.TotalLinePrice;
                                sheet.Cell(currentRow, 5).Style.NumberFormat.Format = "₱#,##0.00";
                                currentRow++;
                            }
                            currentRow++; // Gap between unique orders
                        }

                        // ==========================================
                        // SECTION 3: TOP SELLING TRENDS
                        // ==========================================
                        currentRow += 1;
                        sheet.Cell(currentRow, 1).Value = "=== TOP SELLING PRODUCTS ===";
                        sheet.Range(currentRow, 1, currentRow, 4).Merge().Style.Font.SetBold().Fill.SetBackgroundColor(XLColor.FromHtml("#F2F2F2"));
                        sheet.Range(currentRow, 1, currentRow, 4).Style.Border.SetOutsideBorder(XLBorderStyleValues.Thin);

                        currentRow++;
                        string[] trendHeaders = { "Product", "Category", "Units Sold", "Total Revenue" };
                        for (int i = 0; i < trendHeaders.Length; i++)
                        {
                            sheet.Cell(currentRow, i + 1).Value = trendHeaders[i];
                            sheet.Cell(currentRow, i + 1).Style.Font.SetBold().Border.SetBottomBorder(XLBorderStyleValues.Thin);
                        }

                        // Compute trends from the list
                        var productStats = orders.SelectMany(o => o.Details)
              .GroupBy(d => new { d.Product.Name, d.Product.Category })
              .Select(g => new
              {
                  Name = g.Key.Name,
                  Cat = g.Key.Category.ToString(),
                  Sold = g.Sum(x => x.Quantity),
                  Rev = g.Sum(x => x.TotalLinePrice)
              })
              .OrderByDescending(x => x.Sold).Take(10);

                        currentRow++;
                        foreach (var stat in productStats)
                        {
                            sheet.Cell(currentRow, 1).Value = stat.Name;
                            sheet.Cell(currentRow, 2).Value = UIHelper.FormatEnumName(stat.Cat);
                            sheet.Cell(currentRow, 3).Value = stat.Sold;
                            sheet.Cell(currentRow, 4).Value = stat.Rev;
                            sheet.Cell(currentRow, 4).Style.NumberFormat.Format = "₱#,##0.00";
                            currentRow++;
                        }

                        // ==========================================
                        // FINAL STEP: CONNECT SUMMARY TO DATA VIA FORMULAS
                        // ==========================================
                        // This creates a formula string like: "E10,E14,E18"
                        string revenueRange = string.Join(",", orderRows.Select(r => $"E{r}"));
                        string profitRange = string.Join(",", orderRows.Select(r => $"F{r}"));
                        string costRange = string.Join(",", orderRows.Select(r => $"D{r}"));

                        sheet.Cell("B3").FormulaA1 = $"SUM({revenueRange})";
                        sheet.Cell("B4").FormulaA1 = $"SUM({profitRange})";
                        sheet.Cell("B5").FormulaA1 = $"SUM({costRange})";
                        sheet.Cell("B6").FormulaA1 = $"AVERAGE({revenueRange})";

                        sheet.Range("B3:B6").Style.NumberFormat.Format = "₱#,##0.00";

                        // Final Polish
                        sheet.Columns().AdjustToContents();
                        workbook.SaveAs(saveDialog.FileName);
                    }

                    MessageBox.Show("Comprehensive Business Report generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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