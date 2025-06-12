using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Entities
{
    public class ProductPromo
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("product_id")]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product? Product { get; set; }

        [Column("valid_until")]
        public DateTime ValidUntil { get; set; }

        [Column("discount_nominal", TypeName ="decimal(18,2)")]
        public decimal DiscountNominal { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } 

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }
}
