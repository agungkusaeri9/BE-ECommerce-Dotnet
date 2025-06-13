using backend_dotnet.Entities;

namespace backend_dotnet.DTOs.Transaction
{
    public class TransactionCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string PhoneNumber {  get; set; } = string.Empty;
        public string CourierService {  get; set; } = string.Empty;
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public decimal DiscountTotal { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal ShippingCost { get; set; }
        public int CourierId { get; set; }
        public int? ProductPromoId { get; set; }
        public string PaymentStatus { get;set; } = string.Empty;
        public string? ShippingTrackingNumber { get; set; } = string.Empty;
        public int PaymentMethodId { get; set; }
        public int UserId { get; set; }


        //public List<TransactionItems> TransactionItems { get; set; } = new();

        public List<TransactionItems> Items { get; set; } = new();

    }
}
