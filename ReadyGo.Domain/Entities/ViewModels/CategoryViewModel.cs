using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        [SwaggerSchema("Name of product's category.", Nullable = false)]
        public string Name { get; set; }

        public string AxCode { get; set; }

        [JsonIgnore]
        public DateTime? SyncedAt { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}
