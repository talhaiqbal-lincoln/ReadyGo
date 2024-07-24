using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class PriceHistory : BaseEntity
    {
        public float Price { get; set; }
        public float Tax { get; set; }
        public DateTime From { get; set; }
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }

        [JsonIgnore]
        public virtual Product Product { get; set; }
    }
}
