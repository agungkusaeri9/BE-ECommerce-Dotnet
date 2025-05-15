using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.DTOs.Authentication
{
    public class LoginResponseDto
    {
        public string Token { get; set; } = default!;
        public UserDTO User { get; set; } = default!;
    }
}