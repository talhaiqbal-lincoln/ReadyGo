using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public float Quantity { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [ForeignKey("Promotion")]
        public Guid? PromotionId { get; set; }
        public double Price { get; set; }
        public float Discount { get; set; }

        #region NavigationalProperties:
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        public virtual Promotion Promotion { get; set; }
        #endregion
    }
}
