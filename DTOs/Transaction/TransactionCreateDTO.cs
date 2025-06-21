using backend_dotnet.DTOs.TransactionItem;
using backend_dotnet.Entities;

namespace backend_dotnet.DTOs.Transaction
{
    public class TransactionCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public int? VillageId { get; set; }
        public string PostalCode { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int? CourierId { get; set; }
        public string CourierService { get; set; } = string.Empty;
        public decimal? ShippingCost { get; set; }
        public int? PaymentMethodId { get; set; }
        public int UserId { get; set; }
        public int? ProductPromoId { get; set; }

        public List<TransactionItemCreateDTO> Items { get; set; } = new();

    }
}
