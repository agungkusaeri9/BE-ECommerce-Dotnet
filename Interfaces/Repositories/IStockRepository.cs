using backend_dotnet.Entities;

namespace backend_dotnet.Interfaces.Repositories
{
    public interface IStockRepository
    {
       Task<(IEnumerable<Stock> Items, int TotalItems)> GetAllAsync(int page, int limit);
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stock);
    }
}
