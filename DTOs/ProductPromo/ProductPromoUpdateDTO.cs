namespace backend_dotnet.DTOs.ProductPromo
{
    public class ProductPromoUpdateDTO
    {
        public int ProductId { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal DiscountNominal { get; set; }
    }
}
