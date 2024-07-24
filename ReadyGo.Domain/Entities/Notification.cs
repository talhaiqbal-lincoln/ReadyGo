using ReadyGo.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Content { get; set; }
        public string RedirectUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("CreatedBy")]
        public string CreatedByid { get; set; }
        public virtual ApplicationUser CreatedBy { get; set; }
        #region Navigational Property
        [InverseProperty("Notification")]
        public virtual ICollection<UserNotification> Notifications { get; set; }
        #endregion
    }
}
