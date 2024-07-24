using ReadyGo.Domain.Entities.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class AssignStock : BaseEntity
    {
        public string AXCode { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        
        [Required]
        [ForeignKey("TransferStock")]
        public Guid TransferId { get; set; }
        #region NavigationalProperties:
        public virtual Product Product { get; set; }
        public virtual TransferStock TransferStock { get; set; }
        #endregion
    }
}
