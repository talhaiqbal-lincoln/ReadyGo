using ReadyGo.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ApiModels
{
    [SwaggerSchema("Properties that will be used in a Route entity.")]
    public class RouteApiViewModel
    {
        [Required]
        [MinLength(3)]
        [StringLength(LabelConstants.NameMaxLength)]
        [SwaggerSchema("Name of particular route", Nullable = false)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(500)]
        [SwaggerSchema("A short description of route", Nullable = true)]
        public string Description { get; set; }

        [SwaggerSchema("Time at which route was synced.", Nullable = true)]
        public DateTime? SyncedAt { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        [SwaggerSchema("Ax Code assigned to particular route.", Nullable = true)]
        public string AxCode { get; set; }

        [Required]
        [SwaggerSchema("Active status of route.", Nullable = true)]
        public bool IsActive { get; set; } = true;
    }
}
