using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PFC.Domain.Models;
using PFC.Infrastructure;

namespace PFC.Services
{
    public class ProductService
    {
        // Replaces the LoadProducts database query in ProductView
        public List<Product> GetProducts(bool includeArchived = false)
        {
            using var db = new AppDbContext();
            return db.Products
                     .Include(p => p.SizeOptions)
                     .Where(p => p.IsArchived == includeArchived)
                     .ToList();
        }
    }
}