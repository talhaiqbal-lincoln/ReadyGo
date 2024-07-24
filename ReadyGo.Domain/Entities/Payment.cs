using ReadyGo.Domain.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class Payment:BaseEntity
    {
        [Required]
        [ForeignKey("SalesPerson")]
        public string SalesPersonId { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        [Required]
        public double PaymentReceived { get; set; }
        public double CurrentBalance { get; set; }
        [Required]
        public double NewBalance { get; set; }
        [Required]
        public DateTime ReceivedAt { get; set; }
        public bool IsMarked { get; set; } = false;
        public string PaymentCode { get; set; }
        public string DeviceName { get; set; }
        public string AXCode { get; set; }
        #region NavigationalProperties
        public virtual ApplicationUser SalesPerson { get; set; }
        public virtual Customer Customer { get; set; }
        [InverseProperty("Payment")]
        public virtual Order Order { get; set; }
        #endregion
    }
}
