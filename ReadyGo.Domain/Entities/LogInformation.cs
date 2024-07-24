using ReadyGo.Domain.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class LogInformation : BaseEntity
    {
        public string ActionSource { get; set; }
        public string Action { get; set; }
        public string IPAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("ChangedBy")]
        public string ChangedById { get; set; }
        public virtual ApplicationUser ChangedBy { get; set; }
        public string Exception { get; set; }

    }
}
