using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}