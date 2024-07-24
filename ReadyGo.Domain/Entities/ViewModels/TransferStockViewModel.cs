using System;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class TransferStockViewModel
    {
        public string SpName { get; set; } 
        public string RouteName { get; set; }
        public string AssignedBy { get; set; }
        public bool Status { get; set; }
        public Guid Id { get; set; }
        public string CreatedAt { get; set; }
    }
}
