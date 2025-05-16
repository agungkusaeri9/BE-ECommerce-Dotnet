
namespace backend_dotnet.DTOs.Brand
{
    public class BrandUpdate
    {
        public string? Name { get; set; } = default!;
        public IFormFile? Image { get; set; } = default!;
    }
}