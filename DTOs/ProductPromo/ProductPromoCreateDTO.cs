namespace backend_dotnet.DTOs.ProductPromo
{
    public class ProductPromoCreateDTO
    {
        public int ProductId { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal DiscountNominal { get; set; }

    }
}
