using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.PaymentMethod;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService service)
        {
            _paymentMethodService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            var (items, totalItems) = await _paymentMethodService.GetAllAsync(page, limit);

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