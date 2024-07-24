using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ApiModels
{
    public class SalePersonInfoApiViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; } 
        public string Image { get; set; }
        public Guid? RouteId { get; set; } = null;
        public string RouteName { get; set; }
        public Guid? TemporyRouteId { get; set; } = null;
        public string TemporyRouteName { get; set; }
        public double SaleManagerDiscount { get; set; }
        public string TermsConditions { get; set; }
        public DateTime? LastDeliveryReportData { get; set; } = null;
        public string DriverName { get; set; }
        public string VehicleNo { get; set; }
        public string DeliveryReportRouteName { get; set; }
    }
}
