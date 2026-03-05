using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PFC.Domain.Models;

namespace PFC.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet <ProductSizeOption> ProductSizeOptions { get; set; }
        public DbSet <Order> Orders { get; set; }
        public DbSet <OrderDetail> OrderDetails { get; set; }

        public DbSet<SystemSetting> SystemSettings { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // This is "Data Seeding"
            modelBuilder.Entity<SystemSetting>().HasData(new SystemSetting
            {
                Id = 1,
                AdminPassword = "1234", // Your initial secret key
                MasterKey = "0000" // Your initial master key
            });
        }
    }
}
