namespace ReadyGo.Domain.Entities.ViewModels
{
    public class DiscountViewModel : BaseEntity
    {
        public bool IsApproved { get; set; }
        public double DiscountValue { get; set; }
        public bool IsPercentage { get; set; }
    }
}
