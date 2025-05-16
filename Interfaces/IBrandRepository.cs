using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs.ProductCategory;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces
{
    public interface IBrandRepository
    {
        Task<(IEnumerable<Brand> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
        Task<Brand?> GetByIdAsync(int id);
        Task<Brand> CreateAsync(Brand brand);
        Task<Brand> UpdateAsync(Brand brand);
        Task<bool> DeleteAsync(int id);
    }
}