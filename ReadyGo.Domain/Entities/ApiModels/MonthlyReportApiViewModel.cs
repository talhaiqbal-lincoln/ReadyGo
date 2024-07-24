using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ApiModels
{
    public class MonthlyReportApiViewModel
    {
        public DateTime Day { get; set; }
        public double ReturnTotal { get; set; } = 0;
        public double WasteTotal { get; set; } = 0;
        public double SaleTotal { get; set; } = 0;

    }
}
