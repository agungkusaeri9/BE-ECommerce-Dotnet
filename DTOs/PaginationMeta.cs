using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace backend_dotnet.DTOs
{
    public class PaginationMeta<T>
    {
        // [JsonPropertyName("data")]
        // public IEnumerable<T> Data { get; set; } = Enumerable.Empty<T>();

        [JsonPropertyName("curr_page")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("limit")]
        public int ItemsPerPage { get; set; }

        [JsonPropertyName("total")]
        public int TotalItems { get; set; }

        [JsonPropertyName("total_page")]
        public int TotalPages { get; set; }
    }
}