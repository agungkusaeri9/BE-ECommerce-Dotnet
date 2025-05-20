using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Image { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; } = 0;
        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public ProductCategory? Category { get; set; } = null!;
        public Brand? Brand { get; set; } = null!;
    }
}