using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces.Repositories;
using backend_dotnet.Interfaces.Services;

namespace backend_dotnet.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<(IEnumerable<Product>, int)> GetAllAsync(int page, int limit)
        {
            return await _productRepository.GetAllAsync(page, limit);
        }
        // public async Task<Product> GetByIdAsync(int id)
        // {
        //     return await _productRepository.GetByIdAsync(id);
        // }

        public async Task<Product> CreateAsync(Product product)
        {
            product.Slug = (product.Name ?? string.Empty).ToLower().Replace(" ", "-");
            return await _productRepository.CreateAsync(product);
        }

        // public async Task<Product> UpdateAsync(int id, Product product)
        // {
        //     return await _productRepository.UpdateAsync(id, product);
        // }

        // public async Task<bool> DeleteAsync(int id)
        // {
        //     return await _productRepository.DeleteAsync(id);
        // }
    }
}