using backend_dotnet.Data;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.ProductCategory;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/product-categories")]

    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;
        private readonly AppDbContext _appDbContext;
        public ProductCategoryController(IProductCategoryService service, AppDbContext appDbContext)
        {

            _appDbContext = appDbContext;
            _productCategoryService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            if (page < 1) page = 1;
            if (limit < 1) limit = 10;
            var baseUrl = $"{Request.Scheme}://{Request.Host}";
            var totalCategory = await _appDbContext.ProductCategories.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCategory / limit);

            var categories = await _appDbContext.ProductCategories
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(category => new
                {
                    category.Id,
                    category.Name,
                    Image = baseUrl + "/" + category.Image,
                    category.CreatedAt,
                    category.UpdatedAt,
                })
                .ToListAsync();

            var paginatedResult = new PaginationMeta<object>
            {
                // Data = users,
                CurrentPage = page,
                ItemsPerPage = limit,
                TotalItems = totalCategory,
                TotalPages = totalPages
            };

            return ResponseFormatter.Success(categories, "Categories found successfully", pagination: paginatedResult);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] ProductCategoryCreate request)
        {
            try
            {
                var category = await _productCategoryService.CreateAsync(request);
                return ResponseFormatter.Success(category, "Category created successfully");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var category = await _productCategoryService.GetByIdAsync(id);
                return ResponseFormatter.Success(category, "Category found successfully");
            }
            catch (KeyNotFoundException)
            {
                return ResponseFormatter.NotFound("Category not found");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] ProductCategoryUpdate request)
        {
            try
            {
                var category = await _productCategoryService.UpdateAsync(id, request);
                return ResponseFormatter.Success(category, "Category updated successfully");
            }
            catch (KeyNotFoundException)
            {
                return ResponseFormatter.NotFound("Category not found");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var category = await _productCategoryService.DeleteAsync(id);
                return ResponseFormatter.Success(category, "Category deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return ResponseFormatter.NotFound("Category not found");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error(ex.Message);
            }
        }
    }
}
