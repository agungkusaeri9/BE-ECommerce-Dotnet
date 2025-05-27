using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.DTOs.Courier
{
    public class CourierUpdateRequest
    {
        public string Name { get; set; } = string.Empty;
        public int Status { get; set; } = 0;
    }
}