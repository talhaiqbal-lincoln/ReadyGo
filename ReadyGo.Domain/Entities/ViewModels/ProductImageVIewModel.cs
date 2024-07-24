using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class ProductImageVIewModel
    {
        [Required]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Required]
        public string ImageId { get; set; }
        public virtual ResourceFile Image { get; set; }
    }
}
