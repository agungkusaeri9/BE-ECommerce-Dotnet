using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.Entities
{
    public class District
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("code", TypeName = "varchar(10)")]
        public string Code { get; set; } = string.Empty;
        [Column("name", TypeName = "varchar(50)")]
        public string Name { get; set; } = string.Empty;
        [Column("city_id", TypeName = "int")]
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City? City { get; set; }
    }
}