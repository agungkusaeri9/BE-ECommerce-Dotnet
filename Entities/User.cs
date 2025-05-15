using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.Entities
{
    public class User
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; } = default!;

        [Column("email")]
        public string Email { get; set; } = default!;

        [Column("password")]
        public string Password { get; set; } = default!;

        [Column("role")]
        public string Role { get; set; } = "user";

    }
}