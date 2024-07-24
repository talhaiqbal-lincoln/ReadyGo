using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class PaymentViewModel : BaseEntity
    {
        public string SalesPersonId { get; set; }
        public string SpName { get; set; }
        public Guid CustomerId { get; set; }
        [Required]
        [Display(Name = "Payment Received")]
        public double PaymentReceived { get; set; }
        public double CurrentBalance { get; set; }
        [Required]
        public double NewBalance { get; set; }
        [Required]
        public DateTime ReceivedAt { get; set; }
        public bool IsMarked { get; set; } = false;
        public string PaymentCode { get; set; }
        public string DeviceName { get; set; }
    }

    public class UpdateViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string AxCode { get; set; }
    }
}
