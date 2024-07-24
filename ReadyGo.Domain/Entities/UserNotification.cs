using ReadyGo.Domain.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class UserNotification : BaseEntity
    {
        public bool IsRead { get; set; } = false;
        [ForeignKey("Notification")]
        public Guid NotificationId { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        #region Navigational Property
        public virtual ApplicationUser User { get; set; }
        public virtual Notification Notification { get; set; }
        #endregion
    }
}
