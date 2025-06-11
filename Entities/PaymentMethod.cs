using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Entities
{
    public enum PaymentType
    {
        Bank,
        EWallet
    }

    public class PaymentMethod
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string? Name { get; set; } = string.Empty;

        [Column("number")]
        public string? Number { get; set; } = string.Empty;

        [Column("owner_name")]
        public string? OwnerName { get; set; } = string.Empty;

        [Column("type")]
        public string? Type { get; set; } = string.Empty;

        [Column("is_active")]
        public int? IsActive { get; set; } = 1;

        [Column("image")]
        public string? Image { get; set; } = string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
