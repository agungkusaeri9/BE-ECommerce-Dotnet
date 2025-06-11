using backend_dotnet.DTOs;
using backend_dotnet.DTOs.Stock;
using backend_dotnet.Helpers;
using backend_dotnet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockService _stockService;
        public StockController(StockService stockService) {
            _stockService = stockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStocks([FromQuery] int page = 1, int limit = 10)
        {
            var (data, totalItems) = await _stockService.GetAllAsync(page, limit);

            var pagination = new PaginationMeta<object>
            {
                CurrentPage = page,
                ItemsPerPage = limit,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / limit)
            };

            return ResponseFormatter.Success(data, "Stocks retrieved", pagination:pagination);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] StockCreate request)
        {
            try
            {
                var response = await _stockService.CreateAsync(request);
                return ResponseFormatter.Success(response, "Stock has been created successfully.");
            }
            catch (Exception ex)
            {
                    return ResponseFormatter.Error(ex.Message, ex);
            }
        }


    }
}
