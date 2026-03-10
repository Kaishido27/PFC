using Microsoft.EntityFrameworkCore;
using PFC.App.Helper;
using PFC.Infrastructure;
using PFC.Services;
using PFC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}

