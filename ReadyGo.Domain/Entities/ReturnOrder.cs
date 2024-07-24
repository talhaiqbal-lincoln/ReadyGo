using ReadyGo.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class ReturnOrder : BaseEntity
    {
        public float Quantity { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public double Price { get; set; }
        public float Discount { get; set; }
        public ReturnOrderReasonEnum? Reason { get; set; }
        public string ReturnReason { get; set; }
        #region NavigationalProperties:
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        #endregion
    }
}
