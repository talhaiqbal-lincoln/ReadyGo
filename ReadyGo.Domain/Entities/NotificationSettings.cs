using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReadyGo.Domain.Entities
{
    public class NotificationSettings : BaseEntity
    {
        [ForeignKey("User")]
        public string UserId { get; set; }
        public NotficationEnums NotificationType { get; set; }
        #region Navigational Property
        public virtual ApplicationUser User { get; set; }
        #endregion
    }
}
