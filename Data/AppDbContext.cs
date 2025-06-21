using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Courier> Couriers { get; set; }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<ProductPromo> ProductPromo { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionItem> TransactionItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.BrandId);
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany()
            .HasForeignKey(p => p.CategoryId);
        }
    }
}