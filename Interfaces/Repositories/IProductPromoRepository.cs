using backend_dotnet.DTOs.ProductPromo;
using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces.Repositories
{
    public interface IProductPromoRepository
    {
        Task<(IEnumerable<ProductPromo> Items, int TotalItems)> GetAllAsync(int page, int limit);
        Task<ProductPromo> CreateAsync(ProductPromoCreateDTO productPromoCreateDTO);
        Task<ProductPromo>GetByIdAsync(int id);
        Task<ProductPromo> UpdateAsync(int id, ProductPromoUpdateDTO dto);
        Task<ProductPromo> DeleteAsync(int id);

    }
}
