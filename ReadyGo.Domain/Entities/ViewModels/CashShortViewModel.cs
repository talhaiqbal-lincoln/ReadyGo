using System;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class CashShortViewModel
    {
        public Guid ReportId { get; set; }
        [Required]
        [Display(Name ="Cash Short")]
        public double CashShort { get; set; }
        public double Recievable { get; set; }
    }
}
