using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<(IEnumerable<Product> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
        // Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        // Task<Product> UpdateAsync(Product product);
        // Task<bool> DeleteAsync(int id);
    }
}