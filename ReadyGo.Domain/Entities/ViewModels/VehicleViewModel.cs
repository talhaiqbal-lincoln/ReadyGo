using Newtonsoft.Json;
using ReadyGo.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    [SwaggerSchema("Properties that will be used in a vehicle entity.")]
    public class VehicleViewModel
    {
        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        [SwaggerSchema("AxCode assigned to particular vehicle.", Nullable = true)]
        public string AXCode { get; set; }

        [Required]
        [MinLength(4)]
        [StringLength(LabelConstants.NameMaxLength)]
        [SwaggerSchema("Vehicle registration number.", Nullable = false)]
        public string VehicleNumber { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(LabelConstants.NameMaxLength)]
        [SwaggerSchema("Name of vehicle's driver.", Nullable = false)]
        public string DriverName { get; set; }

        [MinLength(3)]
        [StringLength(LabelConstants.NameMaxLength)]
        [SwaggerSchema("Name of vehicle's model", Nullable = true)]
        public string Model { get; set; }

        [Required]
        [MinLength(3)]
        [StringLength(LabelConstants.NameMaxLength)]
        [SwaggerSchema("Type of vehicle", Nullable = false)]
        public string Type { get; set; }
    }
}
