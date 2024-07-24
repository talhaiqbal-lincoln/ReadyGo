using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ApiModels
{
   public class PaymentApiViewModel
    {
        public Guid? Id { get; set; }
        public string SalesPersonId { get; set; }
        public Guid CustomerId { get; set; }
        public double PaymentReceived { get; set; }
        public double CurrentBalance { get; set; }
        public double NewBalance { get; set; }
        public DateTime ReceivedAt { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsMarked { get; set; }
        public string PaymentCode { get; set; }
        public string DeviceName { get; set; }
    }

    public class OrderPaymentApiViewModel
    {
        public Guid? Id { get; set; }
        public string SalesPersonId { get; set; }
        public Guid? CustomerId { get; set; }
        public double PaymentReceived { get; set; }
        public double CurrentBalance { get; set; }
        public double NewBalance { get; set; }
        public DateTime ReceivedAt { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsMarked { get; set; }
        public string PaymentCode { get; set; }
        public string DeviceName { get; set; }
    }
}
