using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend_dotnet.Entities
{
    public class Product
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        public string Description { get; set; } = string.Empty;

        [Column("slug")]
        public string Slug { get; set; } = string.Empty;

        [Column("image")]
        public string? Image { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("stock")]
        public int Stock { get; set; } = 0;

        [ForeignKey("Category")]
        [Column("category_id")]
        public int? CategoryId { get; set; }

        public virtual ProductCategory? Category { get; set; }

        [ForeignKey("Brand")]
        [Column("brand_id")]
        public int? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
