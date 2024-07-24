
namespace ReadyGo.Domain.Entities.ViewModels
{
    public class ReturnOrderViewModel : BaseEntity
    {
        public string ProductDetailId { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string ReturnReason { get; set; }
        public int Quantity { get; set; }
    }
}
