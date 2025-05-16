using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs.ProductCategory;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces;

namespace backend_dotnet.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository repository)
        {
            _productCategoryRepository = repository;
        }

        public async Task<(IEnumerable<ProductCategory>, int)> GetAllAsync(int page, int limit)
        {
            return await _productCategoryRepository.GetAllAsync(page, limit);
        }

        public Task<ProductCategory?> GetByIdAsync(int id)
        {
            return _productCategoryRepository.GetByIdAsync(id);
        }

        public async Task<ProductCategory> CreateAsync(ProductCategoryCreate request)
        {
            var category = new ProductCategory
            {
                Name = request.Name,
                Image = request.Image
            };
            return await _productCategoryRepository.CreateAsync(category);
        }

        public async Task<ProductCategory> UpdateAsync(int id, ProductCategoryUpdate request)
        {
            var existing = await _productCategoryRepository.GetByIdAsync(id);
            if (existing == null) throw new Exception("Category not found");

            existing.Name = request.Name;
            existing.Image = request.Image;

            return await _productCategoryRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _productCategoryRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Category not found");
            return await _productCategoryRepository.DeleteAsync(id);
        }
    }

}