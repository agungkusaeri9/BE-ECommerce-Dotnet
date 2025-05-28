using backend_dotnet.Data;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.Brand;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private readonly AppDbContext _appDbContext;

        public BrandController(IBrandService service, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _brandService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrands([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            if (page < 1) page = 1;
            if (limit < 1) limit = 10;

            var totalUsers = await _appDbContext.Brands.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalUsers / limit);
            var baseUrl = $"{Request.Scheme}://{Request.Host}";

            var users = await _appDbContext.Brands
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(brand => new
                {
                    brand.Id,
                    brand.Name,
                    // brand.Image,
                    Image = baseUrl + "/" + brand.Image
                })
                .ToListAsync();

            var paginatedResult = new PaginationMeta<object>
            {
                CurrentPage = page,
                ItemsPerPage = limit,
                TotalItems = totalUsers,
                TotalPages = totalPages
            };

            return ResponseFormatter.Success(users, "Brand found successfully", pagination: paginatedResult);
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
                return ResponseFormatter.Success(request, "Brand updated successfully");
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