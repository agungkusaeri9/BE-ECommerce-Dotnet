using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.Data;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.PaymentMethod;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/payment-methods")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly AppDbContext _appDbContext;

        public PaymentMethodController(IPaymentMethodService service, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _paymentMethodService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetPayments([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            if (page < 1) page = 1;
            if (limit < 1) limit = 10;

            var totalUsers = await _appDbContext.PaymentMethods.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalUsers / limit);

            var users = await _appDbContext.Users
                .Skip((page - 1) * limit)
                .Take(limit)
                .Select(user => new
                {
                    user.Id,
                    user.Name,
                    user.Email,
                    user.Role
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

            return Ok(ResponseFormatter.Success(paginatedResult, "Users found successfully"));
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] PaymentMethodCreate request)
        {
            try
            {
                var paymentMethod = await _paymentMethodService.CreateAsync(request);
                return ResponseFormatter.Success(paymentMethod, "Payment Method created successfully");
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
                var paymentMethod = await _paymentMethodService.GetByIdAsync(id);
                return ResponseFormatter.Success(paymentMethod, "Payment Method found successfully");
            }
            catch (KeyNotFoundException)
            {
                return ResponseFormatter.NotFound("Payment Method not found");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error(ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] PaymentMethodUpdate request)
        {
            try
            {
                var paymentMethod = await _paymentMethodService.UpdateAsync(id, request);
                return ResponseFormatter.Success(paymentMethod, "Payment Method updated successfully");
            }
            catch (KeyNotFoundException)
            {
                return ResponseFormatter.NotFound("Payment Method not found");
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
                var paymentMethod = await _paymentMethodService.DeleteAsync(id);
                return ResponseFormatter.Success(paymentMethod, "Payment Method deleted successfully");
            }
            catch (KeyNotFoundException)
            {
                return ResponseFormatter.NotFound("Payment Method not found");
            }
            catch (Exception ex)
            {
                return ResponseFormatter.Error(ex.Message);
            }
        }
    }
}