using backend_dotnet.Data;
using backend_dotnet.DTOs;
using backend_dotnet.DTOs.Transaction;
using backend_dotnet.DTOs.TransactionItem;
using backend_dotnet.Entities;
using backend_dotnet.Helpers;
using backend_dotnet.Interfaces.Repositories;
using backend_dotnet.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sprache;

namespace backend_dotnet.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;
        private readonly ITransactionRepository _transactionRepository;
        public TransactionController(ITransactionRepository transactionRepository, AppDbContext appDbContext) {
            _transactionRepository = transactionRepository;
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactions([FromQuery] int page = 1, [FromQuery] int limit = 10)
        {
            if (page < 1) page = 1;
            if (limit < 1) limit = 10;

            var totalItems = await _appDbContext.Transactions.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalItems / limit);

            var transactions = await _appDbContext.Transactions
                .Skip((page - 1) * limit)
                .Take(limit)
                .Include(x => x.PaymentMethod)
                .Select(x => new { 
                    x.Id,
                    x.Uuid,
                    x.Code,
                    x.Name,
                    x.Address,
                    x.PostalCode,
                    x.PaymentMethod,
                    x.SubTotal,
                    x.DiscountTotal,
                    x.Total,
                    x.Status
                })
                .ToListAsync();
            Logger.Log(transactions);

            var paginatedResult = new PaginationMeta<object>
            {
                // Data = users,
                CurrentPage = page,
                ItemsPerPage = limit,
                TotalItems = totalItems,
                TotalPages = totalPages
            };

            return ResponseFormatter.Success(transactions, "Transactions found successfully", pagination: paginatedResult);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionCreateDTO dto)
        {
            using var trx = await _appDbContext.Database.BeginTransactionAsync();
            try
            {
                var newTransaction = new Transaction
                {
                    Name = dto.Name,
                    Address = dto.Address,
                    ProvinceId= dto.ProvinceId,
                    CityId = dto.CityId,
                    DistrictId = dto.DistrictId,
                    VillageId = dto.VillageId,
                    PostalCode = dto.PostalCode,
                    PhoneNumber = dto.PhoneNumber,
                    CourierId = dto.CourierId,
                    CourierService = dto.CourierService,
                    ShippingCost = Convert.ToDecimal(dto.ShippingCost),
                    PaymentMethodId = dto.PaymentMethodId,
                    PaidAt = null,
                    ProductPromoId = dto.ProductPromoId,
                    UserId = dto.UserId,
                };
                decimal ShipingCost = 0;

                var latestTransaction = await _appDbContext.Transactions.OrderByDescending(t => t.Id).FirstOrDefaultAsync();
                string nextCode = "TRX001";

                if (latestTransaction != null && !string.IsNullOrEmpty(latestTransaction.Code))
                {
                    var lastCode = latestTransaction.Code;
                    var numberPart = lastCode.Substring(3);
                    if (int.TryParse(numberPart, out int number))
                    {
                        nextCode = $"TRX{(number + 1).ToString("D3")}";
                    }
                }

                newTransaction.Code = nextCode;
                newTransaction.ShippingCost = 0;
                newTransaction.Status = "pending";
                newTransaction.PaymentStatus = "unpaid";

                await _appDbContext.Transactions.AddAsync(newTransaction);
                await _appDbContext.SaveChangesAsync();
                decimal Total = 0;
                decimal SubTotal = 0;
                decimal TotalDiscount = 0;

                foreach (var detail in dto.Items)
                {
                    var product = await _appDbContext.Products.FindAsync(detail.ProductId);
                    if (product == null)
                        return NotFound();

                    var productDiscount = await _appDbContext.ProductPromo.FindAsync(dto.ProductPromoId);

                    decimal priceProductAfterDiscount = Convert.ToDecimal(product.Price) - (productDiscount?.DiscountNominal ?? 0);

                    var totalPriceDetail = Convert.ToDecimal(priceProductAfterDiscount != 0 ? priceProductAfterDiscount : product.Price) * Convert.ToDecimal(detail.Quantity);
                    Total = Total + totalPriceDetail;
                    SubTotal = SubTotal + Convert.ToDecimal(product.Price) * detail.Quantity;
                    TotalDiscount += Convert.ToDecimal(productDiscount);
                    var itemDetail = new TransactionItem
                    {
                        TransactionId = newTransaction.Id,
                        ProductId = detail.ProductId,
                        ProductName = product.Name,
                        Price = Convert.ToDecimal(product.Price),
                        Quantity = detail.Quantity,
                        Discount = productDiscount != null ? Convert.ToDecimal(productDiscount.DiscountNominal) : 0,
                        SubTotal = SubTotal,
                        Total = totalPriceDetail
                    };

                    await _appDbContext.TransactionItem.AddAsync(itemDetail);
                    await _appDbContext.SaveChangesAsync();
                }
                newTransaction.SubTotal = SubTotal;
                newTransaction.DiscountTotal = Convert.ToDecimal(TotalDiscount);
                newTransaction.ShippingCost = ShipingCost;
                newTransaction.Total = Total + ShipingCost;
                await _appDbContext.SaveChangesAsync();
                await trx.CommitAsync();
                return ResponseFormatter.Success(newTransaction, "Transaction has been created successfully");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                await trx.RollbackAsync();
                return ResponseFormatter.Error(
                       ex.ToString() // bisa kasih seluruh stack trace, termasuk inner exception
                   );
            }
        }

        [HttpGet("{uuid}")]
        public async Task<IActionResult> GetTransactionByUuid(Guid uuid)
        {
            try
            {
                var item = await _appDbContext.Transactions.Include(x => x.Items).FirstOrDefaultAsync(x => x.Uuid == uuid);
                if (item == null)
                    return NotFound();
                return ResponseFormatter.Success(item, "Transaction Retrived Successfully");
            }
            catch(Exception ex)
            {
                Logger.Log(ex);
                return ResponseFormatter.Error(ex.Message);
            }
        }

    }
}
