using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class Route : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? SyncedAt { get; set; }
        public string AxCode { get; set; }
        public bool IsActive { get; set; } = true;
#nullable enable

        #region NavigationalProperties:
        [InverseProperty("Route")]
        public virtual ICollection<Discount>? Discounts { get; set; }

        [InverseProperty("Route")]
        public virtual ICollection<AssignedRoute>? SalesPersons { get; set; }

        [InverseProperty("Route")]
        public virtual ICollection<Customer>? Customers { get; set; }

        public virtual ICollection<Promotion>? Promotions { get; set; }

        #endregion NavigationalProperties:

#nullable disable
    }
}