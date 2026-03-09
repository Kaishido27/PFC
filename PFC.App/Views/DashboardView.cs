using Microsoft.EntityFrameworkCore;
using PFC.App.Helper;
using PFC.Infrastructure;
using PFC.Services;
using System;
using System.Linq;
using System.Windows.Forms;

namespace PFC.App
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();

            // Call the load method as soon as the dashboard is created
            LoadDashboardData();
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

                    // Apply global grid formatting
                    UIHelper.FormatStandardGrid(dgvRecentTransactions);
                }
            }
            catch (Exception ex)
            {
                UIHelper.ShowError($"Failed to load dashboard data: {ex.Message}");
            }
        }
    }
}

