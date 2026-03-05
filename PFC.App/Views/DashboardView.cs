using Microsoft.EntityFrameworkCore;
using PFC.Infrastructure;
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
                using (var db = new AppDbContext())
                {
                    // ==========================================
                    // 1. TOP METRICS (TODAY ONLY)
                    // ==========================================

                    // Get midnight of today so we only grab today's sales
                    var today = DateTime.Today;

                    // Fetch today's orders, including details so the math works
                    var todaysOrders = db.Orders
                                         .Include(o => o.Details)
                                             .ThenInclude(d => d.Product)
                                                 .ThenInclude(p => p.SizeOptions)
                                         .Where(o => o.OrderDate >= today)
                                         .ToList(); // Bring into memory

                    // Calculate the totals using the math properties you wrote
                    int dailySalesCount = todaysOrders.Count;
                    decimal totalRevenue = todaysOrders.Sum(o => o.TotalAmount);
                    decimal totalProfit = todaysOrders.Sum(o => o.TotalProfit);

                    // Update the UI labels
                    lblDailySales.Text = dailySalesCount.ToString();
                    lblTotalRevenue.Text = $"₱{totalRevenue:N2}";
                    lblTotalProfit.Text = $"₱{totalProfit:N2}";


                    // ==========================================
                    // 2. RECENT TRANSACTIONS (LAST 5 OVERALL)
                    // ==========================================

                    // Grab the last 5 orders from the database
                    var recentOrders = db.Orders
                                         .Include(o => o.Details)
                                         .OrderByDescending(o => o.OrderDate)
                                         .Take(5)
                                         .ToList();

                    // Project the data into a clean, flat format for the DataGridView
                    var gridData = recentOrders.Select(o => new
                    {
                        OrderID = o.Id,
                        Time = o.OrderDate.ToString("hh:mm tt"), // e.g., "02:30 PM"
                        Items = o.Details.Sum(d => d.Quantity),  // Total drinks in that specific order
                        Total = $"₱{o.TotalAmount:N2}"
                    }).ToList();

                    // Bind it to your DataGridView
                    if (dgvRecentTransactions != null)
                    {
                        dgvRecentTransactions.DataSource = gridData;
                        dgvRecentTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                        // Optional: Hide the ugly row header column on the far left
                        dgvRecentTransactions.RowHeadersVisible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load dashboard data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
