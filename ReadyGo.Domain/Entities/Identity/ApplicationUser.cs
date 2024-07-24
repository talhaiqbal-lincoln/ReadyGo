using Microsoft.AspNetCore.Identity;
using ReadyGo.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(LabelConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [StringLength(LabelConstants.NameMaxLength)]
        public string LastName { get; set; }

        public string Address1 { get; set; }

        [StringLength(LabelConstants.CityMaxLength)]
        public string City { get; set; }

        [StringLength(LabelConstants.CityMaxLength)]
        public string Province { get; set; }

        public DateTime? DeletedAt { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; }

        public bool IsActive { get; set; } = true;
        public string AxCode { get; set; }

#nullable enable
        public DateTime? SyncedAt { get; set; }
        public DateTime? InviteTime { get; set; }
        public string? Address2 { get; set; }

        [ForeignKey("ProfileImage")]
        public Guid? ProfileImageId { get; set; }

        #region NavigationalProperties:

        public virtual ResourceFile? ProfileImage { get; set; }

        [InverseProperty("SalesPerson")]
        public virtual ICollection<Order>? Orders { get; set; }

        [InverseProperty("SalesPerson")]
        public virtual ICollection<AssignedRoute>? Routes { get; set; }

#nullable disable
        public virtual ApplicationRole Role { get; set; }
        [InverseProperty("User")]
        public virtual List<UserNotification> Notifications { get; set; }
        [InverseProperty("User")]
        public virtual List<NotificationSettings> NotificationSettings { get; set; }
        [InverseProperty("ApprovedBy")]
        public virtual List<Order> ApprovedOrders { get; set; }
        [InverseProperty("SalesPerson")]
        public virtual List<Payment> Payments { get; set; }

        #endregion NavigationalProperties:
    }
}