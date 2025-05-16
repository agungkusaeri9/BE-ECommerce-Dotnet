using backend_dotnet.DTOs;
using backend_dotnet.DTOs.ProductCategory;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/product-categories")]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService service)
        {
            _productCategoryService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var (items, totalItems) = await _productCategoryService.GetAllAsync(page, limit);

            var pagination = new PaginationMeta
            {
                CurrentPage = page,
                PageSize = limit,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / limit)
            };

            return ResponseFormatter.Success(data: items, pagination: pagination);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductCategoryCreate request)
        {
            try
            {
                var category = await _productCategoryService.CreateAsync(request);
                return ResponseFormatter.Success(category, "Category created successfully");
            }
            catch (System.Exception)
            {
                return ResponseFormatter.ServerError();
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var category = await _productCategoryService.GetByIdAsync(id);
                if (category == null)
                {
                    return ResponseFormatter.NotFound("Category not found");
                }
                return ResponseFormatter.Success(category, "Category found successfully");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductCategoryUpdate request)
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
