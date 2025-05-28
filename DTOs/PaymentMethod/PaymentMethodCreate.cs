using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.DTOs.PaymentMethod
{
    public class PaymentMethodCreate
    {
        public string? Name { get; set; } = default!;
        public string? Number { get; set; } = default!;
        public string? OwnerName { get; set; } = default!;
        public string? Type { get; set; } = default!;
        public int? IsActive { get; set; } = default!;
        public IFormFile? Image { get; set; } = default!;
    }
}