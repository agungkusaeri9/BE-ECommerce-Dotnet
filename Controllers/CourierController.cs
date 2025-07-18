using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Data;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.Courier;
using backend_dotnet.Entities;
using backend_dotnet.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/couriers")]
    public class CourierController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        public CourierController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCouriers([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            if (page < 1) page = 1;
            if (limit < 1) limit = 10;

            var totalUsers = await _appDbContext.Couriers.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalUsers / limit);

            var users = await _appDbContext.Couriers
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(user => new
                {
                    user.Id,
                    user.Name,
                    user.Status
                })
                .ToListAsync();

            var paginatedResult = new PaginationMeta<object>
            {
                // Data = users,
                CurrentPage = page,
                ItemsPerPage = limit,
                TotalItems = totalUsers,
                TotalPages = totalPages
            };

            return ResponseFormatter.Success(users, "Couriers found successfully", pagination: paginatedResult);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourier([FromBody] CourierCreateResponse request)
        {
            try
            {
                var courier = new Courier
                {
                    Name = request.Name,
                    Status = request.Status,
                };

                _appDbContext.Couriers.Add(courier);
                await _appDbContext.SaveChangesAsync();

                return ResponseFormatter.Success(courier, "Courier created successfully");
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCourierById(int id)
        {
            try
            {
                var courier = await _appDbContext.Couriers.FirstOrDefaultAsync(c => c.Id == id);
                if (courier == null)
                {
                    return ResponseFormatter.NotFound("Courier not found");
                }
                return ResponseFormatter.Success(courier, "Courier found successfully");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCourerAsync(int id, [FromBody] CourierUpdateRequest request)
        {
            try
            {
                var courier = await _appDbContext.Couriers.FirstOrDefaultAsync(c => c.Id == id);
                if (courier == null)
                {
                    return ResponseFormatter.NotFound("Courier not found");
                }

                courier.Name = request.Name;
                courier.Status = request.Status;

                await _appDbContext.SaveChangesAsync();
                return ResponseFormatter.Success(courier, "Courier updated successfully");
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCourierAsync(int id)
        {
            try
            {
                var courier = await _appDbContext.Couriers.FirstOrDefaultAsync(c => c.Id == id);
                if (courier == null)
                {
                    return ResponseFormatter.NotFound("Courier not found");
                }
                _appDbContext.Couriers.Remove(courier);
                await _appDbContext.SaveChangesAsync();
                return ResponseFormatter.Success(null, "Courier deleted successfully");
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}