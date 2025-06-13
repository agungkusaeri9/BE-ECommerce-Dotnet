using backend_dotnet.Data;
using backend_dotnet.DTOs.ProductPromo;
using backend_dotnet.Entities;
using backend_dotnet.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Repositories
{
    public class ProductPromoRepository : IProductPromoRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductPromoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<(IEnumerable<ProductPromo>Items, int TotalItems)> GetAllAsync(int page, int limit)
        {
            var totalItems = await _appDbContext.ProductPromo.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / limit);
            var items = await _appDbContext.ProductPromo.Skip((page - 1) * limit).Include(
                P => P.Product)
                .Take(limit).ToListAsync();
            return (items, totalItems);
        }

        public async Task<ProductPromo> CreateAsync(ProductPromoCreateDTO dto)
        {
            var productPromo = new ProductPromo
            {
                ProductId = dto.ProductId,
                ValidUntil = dto.ValidUntil,
                DiscountNominal = dto.DiscountNominal
            };


            await _appDbContext.ProductPromo.AddAsync(productPromo);
            await _appDbContext.SaveChangesAsync();

            return productPromo;
        }

        public async Task<ProductPromo> GetByIdAsync(int id)
        {
            var item = await _appDbContext.ProductPromo.Include(
                P => P.Product
                ).FirstOrDefaultAsync(x => x.Id == id);
            return item;
        }

        public async Task<ProductPromo> UpdateAsync(int id, ProductPromoUpdateDTO dto)
        {
            var item = await _appDbContext.ProductPromo.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null) {
                throw new Exception("ProductPromo not found");
            }

            item.ValidUntil = dto.ValidUntil;
            item.DiscountNominal = dto.DiscountNominal;

            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task<ProductPromo> DeleteAsync(int id)
        {
            var item = await _appDbContext.ProductPromo.FindAsync(id);
             _appDbContext.ProductPromo.Remove(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }
    }
}
