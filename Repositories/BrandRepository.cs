using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Data;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context;

        public BrandRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Brand> Items, int TotalItems)> GetAllAsync(int page, int limit)
        {
            var totalItems = await _context.Brands.CountAsync();

            var items = await _context.Brands
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return (items, totalItems);
        }


        public async Task<Brand?> GetByIdAsync(int id)
        {
            var category = await _context.Brands.FindAsync(id);
            return category;
        }

        public async Task<Brand> CreateAsync(Brand category)
        {
            _context.Brands.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Brand> UpdateAsync(Brand category)
        {
            _context.Brands.Update(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Brands.FindAsync(id);
            if (category == null) return false;

            _context.Brands.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}