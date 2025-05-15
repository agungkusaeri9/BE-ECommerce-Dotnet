using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.DTOs
{
    public class AccessTokenDto
    {
        public string Token { get; set; } = default!;
        public long Expire { get; set; }
    }
}