using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Data;
using backend_dotnet.DTOs.ProductCategory;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace backend_dotnet.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<ProductCategory> Items, int TotalItems)> GetAllAsync(int page, int limit)
        {
            var totalItems = await _context.ProductCategories.CountAsync();

            var items = await _context.ProductCategories
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return (items, totalItems);
        }


        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            return category;
        }

        public async Task<ProductCategory> CreateAsync(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<ProductCategory> UpdateAsync(ProductCategory category)
        {
            _context.ProductCategories.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.ProductCategories.FindAsync(id);
            if (category == null) return false;

            _context.ProductCategories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}