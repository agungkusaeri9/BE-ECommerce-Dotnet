using backend_dotnet.Data;
using backend_dotnet.DTOs.PaymentMethod;
using backend_dotnet.DTOs.Stock;
using backend_dotnet.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Services
{
    public class StockService
    {

        private readonly AppDbContext _context;

        public StockService (AppDbContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Stock>, int)> GetAllAsync(int page, int limit)
        {
            var itemTotal = await _context.Stocks.CountAsync();

            var stocks = await _context.Stocks
                .Skip((page - 1) * limit)
                .Take(limit)
                .Include(p => p.Product)
                .ToListAsync();

            return (stocks, itemTotal);
        }

        public async Task<Stock> CreateAsync(StockCreate request)
        {
            var stock = new Stock{
                Type = request.Type,
                ProductId = request.ProductId,
                Qty = request.Qty
            };

            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();

            return stock;

        }

    }
}
