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

        public void AddProduct(Product product)
        {
            using var db = new AppDbContext();
            db.Products.Add(product);
            db.SaveChanges();
        }

        // Fetches a single product and its sizes for editing
        public Product GetProductById(int id)
        {
            using var db = new AppDbContext();
            return db.Products
                     .Include(p => p.SizeOptions)
                     .FirstOrDefault(p => p.Id == id);
        }

        // Updates an existing product's details and completely replaces its sizes
        public void UpdateProduct(Product updatedProduct)
        {
            using var db = new AppDbContext();
            var existingProduct = db.Products
                                    .Include(p => p.SizeOptions)
                                    .FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (existingProduct != null)
            {
                existingProduct.Name = updatedProduct.Name;
                existingProduct.Category = updatedProduct.Category;

                // Remove old sizes and apply the new ones safely
                db.RemoveRange(existingProduct.SizeOptions);
                existingProduct.SizeOptions = updatedProduct.SizeOptions;

                db.SaveChanges();
            }
        }

        // Toggles a product between active and archived
        public void ToggleArchiveStatus(int id, bool archiveStatus)
        {
            using var db = new AppDbContext();
            var product = db.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                product.IsArchived = archiveStatus;
                db.SaveChanges();
            }
        }
    }



}