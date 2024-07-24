using ReadyGo.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using ReadyGo.Domain.Constants;

namespace ReadyGo.Domain.Entities.ViewModels
{
    [SwaggerSchema("Properties that will be used in a promotion entity.")]
    public class PromotionViewModel
    {
        [Required]
        [MinLength(3)]
        [StringLength(LabelConstants.NameMaxLength)]
        [SwaggerSchema("Registered Promotion Name.", Nullable = false)]
        public string Title { get; set; }

        [MinLength(5)]
        [MaxLength(500)]
        [SwaggerSchema("A breif description of Promotion.", Nullable = true)]
        public string Description { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        [SwaggerSchema("AxCode assigned to particular promotion.", Nullable = false)]
        public string AxCode { get; set; }

        [Required]
        [SwaggerSchema("Quantity of Base product.", Nullable = false)]
        public int BaseProductQuantity { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(10)]
        [SwaggerSchema("Unique AxCode of Base product.", Nullable = false)]
        public string BaseProductCode { get; set; }

        [Required]
        [SwaggerSchema("Quantity of product on promotion.", Nullable = false)]
        public int PromoProductQuantity { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(4)]
        [SwaggerSchema("Ax Code of product on promotion.", Nullable = false)]
        public string PromoProductCode { get; set; }

        [SwaggerSchema("AxCode of route. If provided then promo will be applied on particular route else will be applied on all routes.", Nullable = true)]
        public string RouteCode { get; set; }

        [SwaggerSchema("Limit the promo quantity. If null or 0 then work based on calculation else will restrict the user that only specified promo quantity can be provided.", Nullable = true)]
        public int MaxPromoQuantity { get; set; }

        [Required]
        [SwaggerSchema("Date when the promotion will be starting.", Nullable = false)]
        public DateTime StartDate { get; set; }

        [Required]
        [SwaggerSchema("Date when the promotion will be ending.", Nullable = false)]
        public DateTime EndDate { get; set; }
    }

    public class PromoTableViewModel
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string RouteName { get; set; }
        public string AxCode { get; set; }
        public string PromoProduct { get; set; }
        public string BaseProduct { get; set; }
        public int PromoQuantity { get; set; }
        public int BaseQuantity { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool IsExpired { get; set; }
        public string MaxQuantity { get; set; }
    }
}
