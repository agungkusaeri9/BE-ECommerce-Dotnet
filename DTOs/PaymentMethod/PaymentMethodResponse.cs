using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.DTOs.ProductCategory
{
    public class PaymentMethodResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string Type { get; set; } = default!;
        public string OwnerName { get; set; } = default!;
        public string IsActive { get; set; } = default!;
        public string Image { get; set; } = default!;
    }
}