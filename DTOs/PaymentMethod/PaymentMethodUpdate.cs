
namespace backend_dotnet.DTOs.PaymentMethod
{
    public class PaymentMethodUpdate
    {
        public string? Name { get; set; } = default!;
        public string? Number { get; set; } = default!;
        public string? OwnerName { get; set; } = default!;
        public string? Type { get; set; } = default!;
        public bool? IsActive { get; set; } = default!;
        public IFormFile? Image { get; set; } = default!;
    }
}