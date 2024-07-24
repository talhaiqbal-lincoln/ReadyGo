using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [SwaggerSchema("Identifier of particular entity.", Nullable = false)]

        public Guid Id { get; set; }

        [JsonIgnore]
        public DateTime? DeletedAt { get; set; }
    }
}
