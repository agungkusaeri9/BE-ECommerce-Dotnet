using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Data;
using backend_dotnet.DTOs.Brand;
using backend_dotnet.DTOs.Product;
using backend_dotnet.Entities;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces.Services;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int page, int limit)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .Select(p => new
                {
                    p.Id,
                    p.Name,
                    p.Price,
                    p.Description,
                    p.Stock,
                    p.Category,
                    p.Brand,
                    p.Image
                })
                .ToListAsync();

            return ResponseFormatter.Success(products, "Products found successfully");
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductCreate request)
        {
            try
            {
                var product = new Product
                {
                    Name = request.Name,
                    Price = request.Price,
                    Description = request.Description,
                    Stock = request.Stock,
                    CategoryId = request.CategoryId,
                    BrandId = request.BrandId,
                };
                product.Slug = (product.Name ?? string.Empty).ToLower().Replace(" ", "-");

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return ResponseFormatter.Success(product, "Product created successfully");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var product = await _context.Products.Select(p => new { p.Id, p.Name, p.Price, p.Description, p.Stock, p.Category, p.Brand, p.Image }).FirstOrDefaultAsync(p => p.Id == id);
                if (product == null)
                    return ResponseFormatter.NotFound("Product not found");
                return ResponseFormatter.Success(product, "Product found successfully");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] ProductUpdate request)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                    return ResponseFormatter.NotFound("Product not found");

                product.Name = request.Name;
                product.Price = request.Price;
                product.Description = request.Description;
                product.Stock = request.Stock ?? 0;
                product.CategoryId = request.CategoryId;
                product.BrandId = request.BrandId;

                product.Slug = (product.Name ?? string.Empty).ToLower().Replace(" ", "-");
                await _context.SaveChangesAsync();
                return ResponseFormatter.Success(product, "Product updated successfully");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var product = _context.Products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                    return ResponseFormatter.NotFound("Product not found");
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return ResponseFormatter.Success(null, "Product deleted successfully");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}