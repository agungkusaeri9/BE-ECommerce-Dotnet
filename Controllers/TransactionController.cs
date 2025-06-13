using backend_dotnet.DTOs.Transaction;
using backend_dotnet.DTOs.TransactionItem;
using backend_dotnet.Entities;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces.Repositories;
using backend_dotnet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_dotnet.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        public TransactionController(ITransactionRepository transactionRepository) {
            _transactionRepository = transactionRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionCreateDTO dto)
        {
            try
            {
                var transaction = new Transaction
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    PostalCode = dto.PostalCode,
                    PhoneNumber = dto.PhoneNumber,
                    CourierId = dto.CourierId,
                    CourierService = dto.CourierService,
                    ShippingCost = Convert.ToDecimal(dto.ShippingCost),
                    ShippingTrackingNumber = dto.ShippingTrackingNumber,
                    PaymentMethodId = dto.PaymentMethodId,
                    PaymentStatus = dto.PaymentStatus,
                    PaidAt = null,
                    ProductPromoId = dto.ProductPromoId,
                    SubTotal = Convert.ToDecimal(dto.SubTotal),
                    DiscountTotal = Convert.ToDecimal(dto.DiscountTotal),
                    UserId = dto.UserId,
                    Total = Convert.ToDecimal(100000),
                    Status = "pending",
                    ShippedAt = null,
                    DeliveredAt = null,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                transaction.Items = dto.Items.Select(i => new TransactionItems
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    Price = Convert.ToDecimal(i.Price),
                    Total = Convert.ToDecimal(i.Price * i.Quantity),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                }).ToList();

                var item = await _transactionRepository.CreateAsync(transaction);
                return ResponseFormatter.Success(item, "Transaction has been created successfully");
            }
            catch (Exception ex)
            {
                //Logger.Log(ex);
                return ResponseFormatter.Error(ex.Message);
            }
        }
    }
}
