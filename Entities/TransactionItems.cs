using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace backend_dotnet.Entities
{
    public class TransactionItems
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("transaction_id", TypeName = "int")]
        public int TransactionId { get; set; }
        [ForeignKey(nameof(TransactionId))]
        public Transaction? Transaction { get; set; }
        [Column("product_id", TypeName = "int")]
        public int ProductId { get; set; }
        [ForeignKey(nameof(ProductId))]

        [Column("product_name", TypeName = "varchar(100)")]
        public string ProductName { get; set; } = string.Empty;

        public Product? Product { get; set; }
        [Column("quantity", TypeName = "int")]
        public int Quantity { get; set; }
        [Column("price", TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column("total", TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

    }
}