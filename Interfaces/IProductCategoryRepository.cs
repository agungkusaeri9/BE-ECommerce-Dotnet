using backend_dotnet.Entities;


namespace backend_dotnet.Interfaces
{
    public interface IProductCategoryRepository
    {
        Task<(IEnumerable<ProductCategory> Items, int TotalItems)> GetAllAsync(int pageNumber, int pageSize);
        Task<ProductCategory?> GetByIdAsync(int id);
        Task<ProductCategory> CreateAsync(ProductCategory productCategory);
        Task<ProductCategory> UpdateAsync(ProductCategory productCategory);
        Task<bool> DeleteAsync(int id);
    }
}