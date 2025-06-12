
using backend_dotnet.Data;
using backend_dotnet.DTOs.Product;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces;
using backend_dotnet.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IFileUploadService _uploadService;

        public ProductRepository(AppDbContext context, IFileUploadService fileUploadService)
        {
            _context = context;
            _uploadService = fileUploadService;
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


        public async Task<Product?> GetByIdAsync(int id)
        {
            var category = await _context.Products.FindAsync(id);
            return category;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(int id, ProductUpdate dto)
        {
            var existing = await _context.Products.FindAsync(id);
            if (existing == null) return null;

            if (dto.Image != null)
            {
                if (!string.IsNullOrEmpty(existing.Image))
                {
                    await _uploadService.DeleteAsync(existing.Image);
                }

                existing.Image = await _uploadService.UploadAsync(dto.Image, "images/products");
            }

            existing.Name = dto.Name;
            existing.Price = dto.Price;
            existing.CategoryId = dto.CategoryId;
            existing.BrandId = dto.BrandId;
            existing.Description = dto.Description;
            existing.Slug = (dto.Name ?? "").ToLower().Replace(" ", "-");

            _context.Products.Update(existing);
            await _context.SaveChangesAsync();

            return existing;
        }


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