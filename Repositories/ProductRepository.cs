
using backend_dotnet.Data;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Product> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize)
        {
            var query = _context.Products.AsQueryable();

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalItems);
        }


        // public async Task<Brand?> GetByIdAsync(int id)
        // {
        //     var category = await _context.Brands.FindAsync(id);
        //     return category;
        // }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        // public async Task<Brand> UpdateAsync(Brand category)
        // {
        //     _context.Brands.Update(category);
        //     await _context.SaveChangesAsync();
        //     return category;
        // }

        // public async Task<bool> DeleteAsync(int id)
        // {
        //     var category = await _context.Brands.FindAsync(id);
        //     if (category == null) return false;

        //     _context.Brands.Remove(category);
        //     await _context.SaveChangesAsync();
        //     return true;
        // }
    }
}