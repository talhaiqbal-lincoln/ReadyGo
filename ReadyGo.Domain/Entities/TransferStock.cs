using ReadyGo.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReadyGo.Domain.Entities
{
    public class TransferStock : BaseEntity
    {
        public string AXCode { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public bool Status { get; set; } = true;
        public string DriverName { get; set; }
        public string FromWarehouse { get; set; }
        [Required]
        [ForeignKey("Route")]
        public Guid RouteId { get; set; }
        [Required]
        [ForeignKey("CreatedBy")]
        public string CreatedById { get; set; }
        [Required]
        [ForeignKey("Vehicle")]
        public Guid VehicleId { get; set; }
        public virtual Route Route { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        [InverseProperty("TransferStock")]
        public virtual ICollection<AssignStock> AssignStocks { get; set; }
    }
}
