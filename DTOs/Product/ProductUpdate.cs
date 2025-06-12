
namespace backend_dotnet.DTOs.Product
{
    public class ProductUpdate
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public IFormFile? Image { get; set; }
    }
}