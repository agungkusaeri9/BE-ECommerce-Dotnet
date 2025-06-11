namespace backend_dotnet.DTOs.Stock
{
    public class StockUpdate
    {
        public string Type { get; set; } = string.Empty;

        public int Qty { get; set; }

        public int ProductId { get; set; }
    }
}
