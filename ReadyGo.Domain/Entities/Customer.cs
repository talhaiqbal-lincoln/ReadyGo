using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [StringLength(LabelConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [StringLength(LabelConstants.NameMaxLength)]
        public string LastName { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [StringLength(LabelConstants.CityMaxLength)]
        public string City { get; set; }

        [StringLength(LabelConstants.CityMaxLength)]
        public string Province { get; set; }

        public string Email { get; set; }
        public string CNIC { get; set; }
        public string PhoneNumber { get; set; }
        public double Balance { get; set; } = 0;
        public DateTime CreatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public string CreatedById { get; set; }

        public bool IsActive { get; set; } = true;
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AxCode { get; set; }
        public string BusinessName { get; set; }

        [ForeignKey("Route")]
        public Guid? RouteId { get; set; }

        public DateTime? SyncedAt { get; set; }

        [ForeignKey("ProfilePicture")]
        public Guid? PictureId { get; set; }

        #region NavigationalProperties:

        public virtual ResourceFile? ProfilePicture { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Order>? Orders { get; set; }

        public virtual Route? Route { get; set; }

        public virtual ApplicationUser CreatedBy { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Promotion> Promotions { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Discount> Discounts { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Payment> Payments { get; set; }
        #endregion NavigationalProperties:
    }
}