using backend_dotnet.DTOs.Brand;
using backend_dotnet.DTOs.ProductCategory;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces
{
    public interface IBrandService
    {
        Task<(IEnumerable<Brand> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand> CreateAsync(BrandCreate request);
        Task<Brand> UpdateAsync(int id, BrandUpdate request);
        Task<bool> DeleteAsync(int id);
    }
}