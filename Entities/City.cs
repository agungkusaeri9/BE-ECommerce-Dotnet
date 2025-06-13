using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.Entities
{
    public class City
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("code", TypeName = "varchar(10)")]
        public string Code { get; set; } = string.Empty;

        [Column("name", TypeName = "varchar(100)")]
        public string Name { get; set; } = string.Empty;

        [Column("province_id", TypeName = "int")]
        public int ProvinceId { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        public Province? Province { get; set; }

    }
}