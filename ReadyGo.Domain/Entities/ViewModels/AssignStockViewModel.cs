using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class AssignStockViewModel : BaseEntity
    {
        public string FromWarehouse { get; set; }
        [Required]
        [ForeignKey("Route")]
        [SwaggerSchema("Id of respective route.", Nullable = false, Format = "Guid")]

        public string RouteId { get; set; }
        [Required]
        [ForeignKey("CreatedBy")]
        [SwaggerSchema("Id of person who created route.", Nullable = false, Format = "Guid")]

        public string CreatedById { get; set; }
        [Required]
        [ForeignKey("Vehicle")]
        [SwaggerSchema("vehicle assigned for transfer stock.", Nullable = false, Format = "Guid")]

        public string VehicleId { get; set; }

        [SwaggerSchema("Name of driver assigned to vehicle.", Nullable = true)]

        public string DriverName { get; set; }

        //[JsonIgnore]
        public ICollection<Products> Products { get; set; }
    }

    public class AssignStockApiViewModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [SwaggerSchema("Name of warehouse from where stock is transfered.", Nullable = true)]
        public string FromWarehouse { get; set; }

        [Required]
        [SwaggerSchema("AxCode of respective route.", Nullable = false)]
        public string RouteAxCode { get; set; }

        [JsonIgnore]
        [SwaggerSchema("Id of person who created route.", Nullable = false)]

        public string CreatedById { get; set; }

        [Required]
        [SwaggerSchema("Vehicle AxCode assigned for transfer stock.", Nullable = false, Format = "Guid")]
        public string VehicleAxCode { get; set; }

        [SwaggerSchema("Name of driver assigned to vehicle.", Nullable = true)]
        public string DriverName { get; set; }

        public ICollection<ProductApiViewModel> AssignStocks { get; set; }
    }

    public class Products
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }

    public class ProductApiViewModel
    {
        [Required]
        public string AssignStockAXCode { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public string ProductAxCode { get; set; }
    }


}
