using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.Entities
{
    public class Village
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("code", TypeName = "varchar(10)")]
        public string Code { get; set; }
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;
        [Column("district_id", TypeName = "int")]
        public int DistrictId { get; set; }
        [ForeignKey(nameof(DistrictId))]
        public District? District { get; set; }

    }
}