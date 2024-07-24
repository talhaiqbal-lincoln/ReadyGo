using System.Collections.Generic;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class ProductDetailViewModel : BaseEntity
    {
        public Product Product { get; set; }
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    }
    public class ProductVariant
    {
        public string VariantName { get; set; }
        public int TotalAssign { get; set; }
        public int TotalReturn { get; set; }
        public int TotalWaste { get; set; }
        public int TotalDelivered { get; set; }
        public float CurrentPrice { get; set; }
        public string AxCode { get; set; }
    } 
}
