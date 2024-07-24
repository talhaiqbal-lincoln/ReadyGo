using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class ImportStockViewModel
    {
        [Required]
        public string RouteName { get; set; }
        [Required]
        public string ProductSkuCode { get; set; }
        [Required]
        public string Quantity { get; set; }
        [Required]
        public string VehicleNumber { get; set; }
        public string DriverName { get; set; }
        public string ErrorStatus { get; set; }
        public Guid RouteId { get; set; }
    }
}
