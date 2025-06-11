using backend_dotnet.DTOs.Product;

namespace backend_dotnet.DTOs.Stock
{
    public class StockDTO
    {
       public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
        public ProductResponse Product { get; set; } = new ProductResponse();
        public int Qty { get; set; }
    }
}
