using Microsoft.EntityFrameworkCore;
using PFC.App.Helper;
using PFC.Domain.Models;
using PFC.Infrastructure;
using PFC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PFC.App
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
            InitializeHourlyPulseChart();
            LoadDashboardData();
        }

        private void InitializeHourlyPulseChart()
        {
            // Configure chart rendering quality
            chartHourlyPulse.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            chartHourlyPulse.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            chartHourlyPulse.ShowToolTips = true;
        }

        public void LoadDashboardData()
        {
            try
            {
                // Checks if the application is currently running inside the Visual Studio Designer
                if (UIHelper.IsDesignMode()) return;

                var orderService = new OrderService();
                var today = DateTime.Today;

                // 1. TOP METRICS (TODAY ONLY)
                var todaysOrders = orderService.GetOrdersByDateRange(today, today.AddDays(1).AddTicks(-1));

                int dailySalesCount = todaysOrders.Count;
                decimal totalRevenue = todaysOrders.Sum(o => o.TotalAmount);
                decimal totalProfit = todaysOrders.Sum(o => o.TotalProfit);

                lblDailySales.Text = dailySalesCount.ToString();
                lblTotalRevenue.Text = $"₱{totalRevenue:N2}";
                lblTotalProfit.Text = $"₱{totalProfit:N2}";

                // 2. RECENT TRANSACTIONS (LAST 20)
                var recentOrders = orderService.GetRecentOrders(20);

                var gridData = recentOrders.Select(o => new
                {
                    OrderID = o.Id,
                    Date = o.OrderDate.ToString("MM/dd/yyyy"),
                    Time = o.OrderDate.ToString("hh:mm tt"),
                    Items = o.Details.Sum(d => d.Quantity),
                    Total = $"₱{o.TotalAmount:N2}"
                }).ToList();

                if (dgvRecentTransactions != null)
                {
                    dgvRecentTransactions.DataSource = gridData;
                    UIHelper.FormatStandardGrid(dgvRecentTransactions);
                }

                // 3. HOURLY PULSE CHART
                LoadHourlyPulseChart(todaysOrders);
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Failed to load dashboard data: {ex.Message}");
            }
        }

        private void LoadHourlyPulseChart(List<Order> todaysOrders)
        {
            try
            {
                if (chartHourlyPulse.Series.Count == 0) return;

                // Clear existing data
                chartHourlyPulse.Series[0].Points.Clear();

                // Group orders by hour (0-23)
                var hourlySales = todaysOrders
                    .GroupBy(o => o.OrderDate.Hour)
                    .Select(g => new
                    {
                        Hour = g.Key,
                        TotalSales = g.Sum(o => o.TotalAmount)
                    })
                    .OrderBy(h => h.Hour)
                    .ToList();

                if (!hourlySales.Any())
                {
                    chartHourlyPulse.Text = "No sales data for today";
                    chartHourlyPulse.Refresh();
                    return;
                }

                // Add data points to chart
                foreach (var hour in hourlySales)
                {
                    // Format hour as "09:00", "10:00", etc.
                    string hourLabel = $"{hour.Hour:D2}:00";
                    chartHourlyPulse.Series[0].Points.Add(hourLabel, (double)hour.TotalSales);
                }

                // Find and display peak hour
                var peakHour = hourlySales.OrderByDescending(h => h.TotalSales).First();
                var peakTime = DateTime.Today.AddHours(peakHour.Hour);
                
                // Update peak hour label if it exists (you'll need to add this label to the Designer)
                // lblPeakHour.Text = peakTime.ToString("hh:00 tt");

                chartHourlyPulse.Text = $"Hourly Sales Pulse - Peak: {peakTime:hh:00 tt}";
                chartHourlyPulse.Refresh();
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Error loading hourly pulse chart: {ex.Message}");
            }
        }

        private void dgvRecentTransactions_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                // Ensure your column name matches "OrderID" as seen in your screenshot
                var cellValue = dgvRecentTransactions.Rows[e.RowIndex].Cells["OrderID"].Value;
                if (cellValue != null && int.TryParse(cellValue.ToString(), out int orderId))
                {
                    var orderService = new OrderService();
                    // Fetch the items for the dashboard tooltip
                    var order = orderService.GetFullOrderData(DateTime.MinValue, DateTime.MaxValue)
                                            .FirstOrDefault(o => o.Id == orderId);

                    if (order != null)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"ORDER #{orderId} ITEMS");
                        sb.AppendLine("--------------------------");
                        foreach (var detail in order.Details)
                        {
                            sb.AppendLine($"{detail.Quantity}x {detail.Product?.Name} ({detail.SelectedSize.ToFriendlyString()})");
                        }

                        // Use SetToolTip for the 700ms delay to work
                        _dashboardToolTip.SetToolTip(dgvRecentTransactions, sb.ToString());
                    }
                }
            }
            catch { _dashboardToolTip.Hide(dgvRecentTransactions); }
        }

        private void dgvRecentTransactions_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            _dashboardToolTip.Hide(dgvRecentTransactions);
        }

        // --- OWNER DRAW PAINTING (Same as Reports View) ---

        private void _dashboardToolTip_Popup(object sender, PopupEventArgs e)
        {
            string text = _dashboardToolTip.GetToolTip(e.AssociatedControl);
            using (Font f = new Font("Segoe UI", 9))
            {
                Size s = TextRenderer.MeasureText(text, f);
                e.ToolTipSize = new Size(s.Width + 20, s.Height + 20);
            }
        }

        private void _dashboardToolTip_Draw(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.Clear(Color.FromArgb(0, 122, 204)); // Cat Brews Blue

            using (Pen p = new Pen(Color.White, 1))
            {
                e.Graphics.DrawRectangle(p, 0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1);
            }

            TextRenderer.DrawText(e.Graphics, e.ToolTipText, e.Font,
                new Rectangle(10, 10, e.Bounds.Width, e.Bounds.Height),
                Color.White, TextFormatFlags.Default);
        }
    }
}

