using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.DTOs.User
{
    public class UserUpdateRequest
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string? Password { get; set; } = default!;
    }
}