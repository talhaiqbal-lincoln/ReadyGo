using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ApiModels
{
   public class PromotionApiViewModel
    {
        public Guid? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string AxCode { get; set; }
        public bool IsActive { get; set; }
        public int BaseProductQuantity { get; set; }
        public string BaseProductCode { get; set; }
        public int PromoProductQuantity { get; set; }
        public string PromoProductCode { get; set; }
        public string RouteCode { get; set; }
        public int? MaxPromoQuantity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid BaseProductId { get; set; }
        public Guid PromoProductId { get; set; }
        public Guid? RouteId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}
