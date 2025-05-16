using backend_dotnet.DTOs;
using backend_dotnet.DTOs.Brand;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService service)
        {
            _brandService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var (items, totalItems) = await _brandService.GetAllAsync(page, limit);

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
        public async Task<IActionResult> CreateAsync([FromForm] BrandCreate request)
        {
            try
            {
                var brand = await _brandService.CreateAsync(request);
                return ResponseFormatter.Success(brand, "Brand created successfully");
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
                var brand = await _brandService.GetByIdAsync(id);
                return ResponseFormatter.Success(brand, "Brand found successfully");
            }
            catch (KeyNotFoundException)
            {
                return ResponseFormatter.NotFound("Brand not found");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] BrandUpdate request)
        {
            try
            {
                var brand = await _brandService.UpdateAsync(id, request);
                return ResponseFormatter.Success(brand, "Brand updated successfully");
            }
            catch (KeyNotFoundException)
            {
                return ResponseFormatter.NotFound("Brand not found");
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
                var brand = await _brandService.DeleteAsync(id);
                return ResponseFormatter.Success(brand, "Brand deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return ResponseFormatter.NotFound("Brand not found");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error(ex.Message);
            }
        }
    }
}