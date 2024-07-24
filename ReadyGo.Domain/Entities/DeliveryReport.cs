using ReadyGo.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReadyGo.Domain.Entities
{
    public class DeliveryReport : BaseEntity
    {
        public string DriverName { get; set; }
        public bool IsMarked { get; set; } = false;
        public double CashShort { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
        [ForeignKey("SalesPerson")]
        public string SalesPersonId { get; set; }
        [ForeignKey("Route")]
        public Guid? RouteId { get; set; }
        [ForeignKey("Vehicle")]
        public Guid? VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ApplicationUser SalesPerson { get; set; }
        public virtual Route Route { get; set; }
    }
}
