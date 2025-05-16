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
        private readonly IFileUploadService _fileUploadService;

        public ProductCategoryService(IProductCategoryRepository repository, IFileUploadService fileUploadService)
        {
            _productCategoryRepository = repository;
            _fileUploadService = fileUploadService;
        }

        public async Task<(IEnumerable<ProductCategory>, int)> GetAllAsync(int page, int limit)
        {
            return await _productCategoryRepository.GetAllAsync(page, limit);
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            var category = await _productCategoryRepository.GetByIdAsync(id);
            if (category == null) throw new KeyNotFoundException("Category not found");
            return category;
        }

        public async Task<ProductCategory> CreateAsync(ProductCategoryCreate request)
        {
            string? imagePath = null;
            if (request.Image != null)
            {
                imagePath = await _fileUploadService.UploadAsync(request.Image, "images/product-categories");
            }
            else
            {
                imagePath = "images/categories/default.jpg";
            }
            var category = new ProductCategory
            {
                Name = request.Name,
                Slug = (request.Name ?? string.Empty).ToLower().Replace(" ", "-"),
                Image = imagePath
            };

            return await _productCategoryRepository.CreateAsync(category);
        }


        public async Task<ProductCategory> UpdateAsync(int id, ProductCategoryUpdate request)
        {
            var existing = await _productCategoryRepository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("Category not found");

            if (request.Image != null)
            {
                if (!string.IsNullOrEmpty(existing.Image))
                {
                    await _fileUploadService.DeleteAsync(existing.Image);
                }
                existing.Image = await _fileUploadService.UploadAsync(request.Image, "images/product-categories");
            }
            existing.Slug = (request.Name ?? string.Empty).ToLower().Replace(" ", "-");
            existing.Name = request.Name;

            return await _productCategoryRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _productCategoryRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Category not found");
            if (!string.IsNullOrEmpty(existing.Image))
            {
                await _fileUploadService.DeleteAsync(existing.Image);
            }
            return await _productCategoryRepository.DeleteAsync(id);
        }
    }

}