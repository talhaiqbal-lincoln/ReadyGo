using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ApiModels
{
   public class DiscountApiViewModel
    {
        public Guid? Id { get; set; }
        public bool IsApproved { get; set; }
        public double DiscountValue { get; set; }
        public bool IsPercentage { get; set; }
        public Guid? ProductID { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
