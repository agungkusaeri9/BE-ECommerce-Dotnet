using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs.Product;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces.Services
{
    public interface IProductService
    {
        Task<(IEnumerable<Product> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
         Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
         Task<Product> UpdateAsync(int id, ProductUpdate product);
        // Task<bool> DeleteAsync(Product product);
    }
}