using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace backend_dotnet.Entities
{
    public class Transaction
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("uuid")]
        public Guid Uuid { get; set; } = Guid.NewGuid();

        [Column("code")]
        public string Code { get; set; } = string.Empty;
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Column("address")]
        public string Address { get; set; } = string.Empty;

        [Column("province_id")]
        public int? ProvinceId { get; set; }
        [ForeignKey(nameof(ProvinceId))]
        public Province? Province { get; set; }

        [Column("city_id")]
        public int? CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public City? City { get; set; }

        [Column("district_id")]
        public int? DistrictId { get; set; }
        [ForeignKey(nameof(DistrictId))]
        public District? District { get; set; }

        [Column("village_id")]
        public int? VillageId { get; set; }
        [ForeignKey(nameof(VillageId))]
        public Village? Village { get; set; }

        [Column("postal_code")]
        public string PostalCode { get; set; } = string.Empty;

        [Column("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column("courier_id")]
        public int? CourierId { get; set; }
        [ForeignKey(nameof(CourierId))]
        public Courier? Courier { get; set; }

        [Column("courier_service")]
        public string CourierService { get; set; } = string.Empty;

        [Column("shipping_cost")]
        [Precision(18,2)]
        public decimal ShippingCost { get; set; } 

        [Column("shipping_tracking_number")]
        public string? ShippingTrackingNumber { get; set; } = string.Empty;

        [Column("payment_method_id")]
        public int? PaymentMethodId { get; set; }
        [ForeignKey(nameof(PaymentMethodId))]
        public PaymentMethod? PaymentMethod { get; set; }

        [Column("payment_status")]
        public string PaymentStatus { get; set; } = string.Empty;

        [Column("paid_at")]
        public DateTime? PaidAt { get; set; } = null;

        [Column("user_id")]
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User? User { get; set; }

        [Column("product_promo_id")]
        public int? ProductPromoId { get; set; }
        [ForeignKey(nameof(ProductPromoId))]
        public ProductPromo? ProductPromo { get; set; }

        [Column("sub_total")]
        [Precision(18,2)]
        public decimal SubTotal { get; set; }

        [Column("discount_total")]
        [Precision(18, 2)]
        public decimal DiscountTotal { get; set; }

        [Column("total")]
        [Precision(18, 2)]
        public decimal Total { get; set; }

        [Column("status")]
        public string Status { get; set; } = string.Empty;

        [Column("shipped_at")]
        public DateTime? ShippedAt { get; set; }

        [Column("delivered_at")]
        public DateTime? DeliveredAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public List<TransactionItem> Items { get; set; } = new();
    }
}