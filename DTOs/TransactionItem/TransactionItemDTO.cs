﻿namespace backend_dotnet.DTOs.TransactionItem
{
    public class TransactionItemDTO
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
