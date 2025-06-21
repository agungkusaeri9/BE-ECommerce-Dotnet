using backend_dotnet.DTOs.TransactionItem;

namespace backend_dotnet.DTOs.Transaction
{
    public class TransactionDTO
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty ;
        public string? PostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public int? CourierId { get; set; }
        public string? CourierService { get; set; }
        public decimal ShippingCost { get; set; }
        public string? ShippingTrackingNumber { get; set; }
        public int? PaymentMethodId { get; set; }
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime? PaidAt { get; set; }
        public int? ProductPromoId { get; set; }
        public decimal SubTotal { get; set; }
        public decimal DiscountTotal { get; set; }
        public decimal Total { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime? ShippedAt { get; set; }
        public DateTime? DeliveredAt { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }

        //public List<TransactionItemDTO> Items { get; set; } = new();
    }
}
