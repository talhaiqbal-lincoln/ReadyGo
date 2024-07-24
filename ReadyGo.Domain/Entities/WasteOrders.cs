using ReadyGo.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ReadyGo.Domain.Entities
{
    public class WasteOrders : BaseEntity
    {
        public float Quantity { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public ReturnOrderReasonEnum? Reason { get; set; }
        public string WasteReason { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }

        #region NavigationalProperties:
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
        #endregion
    }
}
