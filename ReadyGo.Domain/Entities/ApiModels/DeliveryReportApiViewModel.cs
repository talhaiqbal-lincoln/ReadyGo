using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ApiModels
{
    public class DeliveryReportApiViewModel
    {
        public Guid? Id { get; set; }
        public string DriverName { get; set; }
        public DateTime CreatedAt { get; set; } 
        public string SalesPersonId { get; set; }
        public Guid? RouteId { get; set; }
        public Guid? VehicleId { get; set; }

    }
}
