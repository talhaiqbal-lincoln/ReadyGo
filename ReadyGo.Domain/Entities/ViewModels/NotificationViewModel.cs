using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class NotificationViewModel
    {
    }
    public class NotificationTableViewModel
    {
        public string ProfileImage { get; set; }
        public Guid Id { get; set; }
        public string TimeSpan { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsRead { get; set; }
    }
}
