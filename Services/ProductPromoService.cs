using backend_dotnet.DTOs.ProductPromo;
using backend_dotnet.Entities;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces.Repositories;
using backend_dotnet.Interfaces.Services;

namespace backend_dotnet.Services
{
    public class ProductPromoService : IProductPromoService
    {

       private readonly IProductPromoRepository _productPromoRepository;
        public ProductPromoService(IProductPromoRepository productPromoRepository)
        {
            _productPromoRepository = productPromoRepository;
        }

        public async Task<(IEnumerable<ProductPromo>, int)> GetAllAsync(int page, int limit)
        {
             return await _productPromoRepository.GetAllAsync(page, limit);
        }

        public async Task<ProductPromo> CreateAsync(ProductPromoCreateDTO dto)
        {
            return await _productPromoRepository.CreateAsync(dto);
        }

        public async Task<ProductPromo>GetByIdAsync(int id)
        {
            return await _productPromoRepository.GetByIdAsync(id);
        }

        public async Task<ProductPromo>UpdateAsync(int id, ProductPromoUpdateDTO dto)
        {
            return await _productPromoRepository.UpdateAsync(id, dto);
        }

        public async Task<ProductPromo>DeleteAsync(int id)
        {
            var item = await _productPromoRepository.GetByIdAsync(id);
            if (item == null)
                throw new KeyNotFoundException($"Product Promo with ID {id} not found.");
             await _productPromoRepository.DeleteAsync(id);
            return item;
        }
    }
}
