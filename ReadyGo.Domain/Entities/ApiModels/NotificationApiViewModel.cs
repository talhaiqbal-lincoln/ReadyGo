using System;

namespace ReadyGo.Domain.Entities.ApiModels
{
    public class NotificationApiViewModel
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
