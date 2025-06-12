using System.Text.Json;
using backend_dotnet.Data;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.ProductPromo;
using backend_dotnet.Entities;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [Route("api/product-promos")]
    [ApiController]
    public class ProductPromoController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IProductPromoService _productPromoService;

        public ProductPromoController(AppDbContext context, IProductPromoService productPromoService)
        {
            _context = context;
            _productPromoService = productPromoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int limit = 10)
        {
            try
            {
                var (items, total) = await _productPromoService.GetAllAsync(page, limit);
                var totalPages = (int)Math.Ceiling((double)total / limit);
                var paginatedResult = new PaginationMeta<object>
                {
                    CurrentPage = page,
                    ItemsPerPage = limit,
                    TotalItems = total,
                    TotalPages = totalPages
                };

                return ResponseFormatter.Success(items, "Product Promo found successfully", pagination: paginatedResult);
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error("Internal Server Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductPromoCreateDTO dto)
        {
            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(dto, new JsonSerializerOptions { WriteIndented = true }));

            try
            {
                var item = await _productPromoService.CreateAsync(dto);
                return ResponseFormatter.Success(item);
            }
            catch (Exception ex)
            {
                   return ResponseFormatter.Error($"{ex.Message}", ex);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await _productPromoService.GetByIdAsync(id);
                return ResponseFormatter.Success(item, "Product Promo retrived");
            }
            catch (Exception ex)
            {

                return ResponseFormatter.Error(ex.Message);
            }
        }

    }
}
