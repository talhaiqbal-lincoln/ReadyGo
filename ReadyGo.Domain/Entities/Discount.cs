using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public double DiscountValue { get; set; }
        public bool IsPercentage { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; }
        [ForeignKey("Product")]
        public Guid? ProductID { get; set; }
        [ForeignKey("Customer")]
        public Guid? CustomerId { get; set; }
        [ForeignKey("Route")]
        public Guid? RouteId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Route Route { get; set; }
    }
}
