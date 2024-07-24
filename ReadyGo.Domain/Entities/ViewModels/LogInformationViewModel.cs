using System;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class LogInformationViewModel
    {
        public string ChangedBy { get; set; }
        public string RoleName { get; set; }
        public string ActionSource { get; set; }
        public string Action { get; set; }
        public string IPAddress { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
