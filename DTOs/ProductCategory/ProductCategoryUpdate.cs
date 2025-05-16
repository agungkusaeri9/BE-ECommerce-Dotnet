using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.DTOs.ProductCategory
{
    public class ProductCategoryUpdate
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = default!;
        public IFormFile? Image { get; set; } = default!;
    }
}