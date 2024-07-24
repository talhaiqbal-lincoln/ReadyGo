using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class PriceHistoryViewModel
    {
        [Required]
        [SwaggerSchema("Price of product", Nullable = false)]
        public float Price { get; set; }

        [Required]
        [SwaggerSchema("Tax applied on product", Nullable = false)]
        public float Tax { get; set; }

        [Required]
        [SwaggerSchema("Date on which new price will applicable.", Nullable = false)]
        public DateTime From { get; set; }

        public string ProductAxCode { get; set; }
    }
}
