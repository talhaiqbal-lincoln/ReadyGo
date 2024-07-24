using ReadyGo.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        [MinLength(3)]
        [StringLength(LabelConstants.NameMaxLength)]
        [SwaggerSchema("Name of particular product", Nullable = false)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(500)]
        [SwaggerSchema("A short description of product", Nullable = true)]
        public string Description { get; set; }

        [Required]
        public string CategoryAxCode { get; set; }

        [SwaggerSchema("AxCode of the base product", Nullable = true)]
        public string ParentProductCode { get; set; }

        [MinLength(4)]
        [MaxLength(10)]
        [SwaggerSchema("Ax Code assigned to particular product.", Nullable = true)]
        public string AxCode { get; set; }
    }

    public class CheckPromoProductViewModel : BaseEntity
    {
        public int Quantity { get; set; }
    }
}
