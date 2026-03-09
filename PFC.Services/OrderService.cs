using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PFC.Infrastructure;
using PFC.Domain.Models;

namespace PFC.Services
{
    public class OrderService
    {

        // The date range query in ReportsView AND the "Today" query in DashboardView
        public List<Order> GetOrdersByDateRange(DateTime start, DateTime end)
        {
            using var db = new AppDbContext();
            return db.Orders
                     .Include(o => o.Details)
                         .ThenInclude(d => d.Product)
                             .ThenInclude(p => p.SizeOptions)
                     .Where(o => o.OrderDate >= start && o.OrderDate <= end)
                     .OrderByDescending(o => o.OrderDate)
                     .ToList();
        }

        // Recent transactions query in DashboardView
        public List<Order> GetRecentOrders(int count)
        {
            using var db = new AppDbContext();
            return db.Orders
                     .Include(o => o.Details)
                     .OrderByDescending(o => o.OrderDate)
                     .Take(count)
                     .ToList();
        }

        // Delete logic in ReportsView
        public void DeleteOrder(int orderId)
        {
            using var db = new AppDbContext();
            var orderToDelete = db.Orders
                                  .Include(o => o.Details)
                                  .FirstOrDefault(o => o.Id == orderId);

            if (orderToDelete != null)
            {
                db.Orders.Remove(orderToDelete);
                db.SaveChanges();
            }
        }

        // Saves a new order and its details to the database
        public void SaveOrder(Order newOrder)
        {
            using var db = new AppDbContext();

            newOrder.OrderDate = DateTime.Now;

            // EF Core Safety Trick: Unlink the Product reference so it doesn't create duplicate products
            foreach (var detail in newOrder.Details)
            {
                detail.Product = null;
            }

            db.Orders.Add(newOrder);
            db.SaveChanges();
        }
    }
}

