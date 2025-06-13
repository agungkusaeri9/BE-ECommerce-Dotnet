namespace backend_dotnet.DTOs.TransactionItem
{
    public class TransactionItemCreateDTO
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = string.Empty;
        public string TransactionId { get;set; } = string.Empty;
        public int Quantity { get;set; }
        public decimal Price { get;set; }
        public decimal Total { get;set; }
    }
}
