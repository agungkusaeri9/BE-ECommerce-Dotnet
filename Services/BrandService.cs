using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs.Brand;
using backend_dotnet.DTOs.ProductCategory;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces;

namespace backend_dotnet.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _iBrandRepository;
        private readonly IFileUploadService _fileUploadService;

        public BrandService(IBrandRepository repository, IFileUploadService fileUploadService)
        {
            _iBrandRepository = repository;
            _fileUploadService = fileUploadService;
        }

        public async Task<(IEnumerable<Brand>, int)> GetAllAsync(int page, int limit)
        {
            return await _iBrandRepository.GetAllAsync(page, limit);
        }

        public async Task<Brand?> GetByIdAsync(int id)
        {
            var brand = await _iBrandRepository.GetByIdAsync(id);
            if (brand == null) throw new KeyNotFoundException("Brand not found");
            return brand;
        }

        public async Task<Brand> CreateAsync(BrandCreate request)
        {
            string? imagePath = null;
            if (request.Image != null)
            {
                imagePath = await _fileUploadService.UploadAsync(request.Image, "images/brands");
            }
            var brand = new Brand
            {
                Name = request.Name,
                Slug = (request.Name ?? string.Empty).ToLower().Replace(" ", "-"),
                Image = imagePath
            };

            return await _iBrandRepository.CreateAsync(brand);
        }


        public async Task<Brand> UpdateAsync(int id, BrandUpdate request)
        {
            var existing = await _iBrandRepository.GetByIdAsync(id);
            if (existing == null) throw new KeyNotFoundException("Brand not found");

            Console.WriteLine($"Updating brand with ID: {id}");
            Console.WriteLine($"Request Name: {request.Name}");
            Console.WriteLine($"Request Image: {request.Image?.FileName}");

            if (request.Image != null && request.Image.Length > 0)
            {
                if (!string.IsNullOrEmpty(existing.Image))
                {
                    await _fileUploadService.DeleteAsync(existing.Image);
                }
                existing.Image = await _fileUploadService.UploadAsync(request.Image, "images/brands");
            }
            existing.Slug = (request.Name ?? string.Empty).ToLower().Replace(" ", "-");
            existing.Name = request.Name ?? existing.Name;

            return await _iBrandRepository.UpdateAsync(existing);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existing = await _iBrandRepository.GetByIdAsync(id);
            if (existing == null)
                throw new KeyNotFoundException("Brand not found");
            if (!string.IsNullOrEmpty(existing.Image))
            {
                await _fileUploadService.DeleteAsync(existing.Image);
            }
            return await _iBrandRepository.DeleteAsync(id);
        }
    }
}