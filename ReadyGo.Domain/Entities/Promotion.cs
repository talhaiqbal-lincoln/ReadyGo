
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class Promotion : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? SyncedAt { get; set; }
        public string AxCode { get; set; }
        public bool IsActive { get; set; } = true;
        public int BaseProductQuantity { get; set; }
        [MaxLength(10)]
        public string BaseProductCode { get; set; }
        public int PromoProductQuantity { get; set; }
        [MaxLength(10)]
        public string PromoProductCode { get; set; }
        public string RouteCode { get; set; }
        public int? MaxPromoQuantity { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [ForeignKey("BaseProduct")]
        public Guid BaseProductId { get; set; }
        [ForeignKey("PromoProduct")]
        public Guid PromoProductId { get; set; }
        [ForeignKey("Customer")]
        public Guid? CustomerId { get; set; }
        [ForeignKey("Route")]
        public Guid? RouteId { get; set; }
        public virtual Route? Route { get; set; }
        public virtual Product BaseProduct { get; set; }
        public virtual Product PromoProduct { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
