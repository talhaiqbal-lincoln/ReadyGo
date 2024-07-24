namespace ReadyGo.Domain.Entities.ViewModels
{
    public class OrderDetailViewModel : BaseEntity
    {
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string ProductDetailId { get; set; }
        public string PromotionId { get; set; }
        public int Quantity { get; set; }
    }
}
