using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class Product : BaseEntity
    {
        [StringLength(25)]
        [Required]
        public string Name { get; set; }
        public float Quantity { get; set; }
        public string AxCode { get; set; }
        public string Description { get; set; }
        [ForeignKey("Category")]
        [Required]
        public Guid CategoryId { get; set; }
        [ForeignKey("VariantOf")]
        public Guid? ProductId { get; set; }
        [ForeignKey("Image")]
        public Guid? ImageId { get; set; }
        #region NavigationalProperties:
        public virtual Product VariantOf { get; set; }
        public virtual Category Category { get; set; }
        public virtual ResourceFile Image { get; set; }
        public virtual ICollection<Product> Variants { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<PriceHistory> Prices { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<Discount> Discounts { get; set; }
        #endregion
    }
}
