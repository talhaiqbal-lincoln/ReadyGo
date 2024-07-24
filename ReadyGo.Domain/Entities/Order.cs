using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class Order : BaseEntity
    {
        [ForeignKey("SalesPerson")]
        public string SalesPersonId { get; set; }
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public float Discount { get; set; }
        public bool IsMarked { get; set; } = false;
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string OrderCode { get; set; }
        public double Total { get; set; }
        public string DriverName { get; set; }
        public string AXCode { get; set; }
        public ApprovalStatus Status{ get; set; }
        public ApprovalFor ApprovalFor{ get; set; }
        [ForeignKey("Payment")]
        public Guid? PaymentId { get; set; }

        [ForeignKey("Vehicle")]
        public Guid? VehicleId { get; set; }
        [ForeignKey("ApprovedBy")]
        public string ApprovedById { get; set; }
        public EmptyOrderReasonEnum? Reason { get; set; }
        public string Remarks { get; set; }
        public string DeviceName { get; set; }
        #region NavigationalProperties:
        public virtual Customer Customer { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual ApplicationUser SalesPerson { get; set; }
        public virtual ApplicationUser ApprovedBy { get; set; }
        [InverseProperty("Order")]  
        public virtual ICollection<OrderDetail> Orders { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<ReturnOrder> ReturnOrders { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<WasteOrders> WasteOrders { get; set; }
        #endregion
    }
}
