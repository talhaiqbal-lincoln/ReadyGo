using ReadyGo.Domain.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class AssignedRoute : BaseEntity
    {
        [ForeignKey("SalesPerson")]
        public string SalesPersonId { get; set; }

        [ForeignKey("Route")]
        public Guid RouteId { get; set; }

        public DateTime? TemporaryAssignedTill { get; set; }

        #region Navigational_Properties:

        public virtual Route Route { get; set; }
        public virtual ApplicationUser SalesPerson { get; set; }

        #endregion Navigational_Properties:
    }
}