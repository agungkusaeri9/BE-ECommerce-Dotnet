using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs.ProductCategory;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces
{
    public interface IProductCategoryService
    {
        Task<(IEnumerable<ProductCategory> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
        Task<ProductCategory?> GetByIdAsync(int id);
        Task<ProductCategory> CreateAsync(ProductCategoryCreate request);
        Task<ProductCategory> UpdateAsync(int id, ProductCategoryUpdate request);
        Task<bool> DeleteAsync(int id);
    }
}
