using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class CustomerViewModel
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [SwaggerSchema("First Name of customer", Nullable = false)]
        [Display(Name = "First Name")]
        [StringLength(LabelConstants.NameMaxLength)]
        public string FirstName { get; set; }

        [SwaggerSchema("Last Name of customer.", Nullable = false)]
        [Display(Name = "Last Name")]
        [StringLength(LabelConstants.NameMaxLength)]
        public string LastName { get; set; }

        [SwaggerSchema("First address of customer.", Nullable = false)]
        [Display(Name = "Address Line 1")]
        [Required]
        public string Address1 { get; set; }

        [SwaggerSchema("Second address of customer.", Nullable = true)]
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [Required]
        //[RegularExpression("^[0-9]{5}-[0-9]{7}-[0-9]$", ErrorMessage = "CNIC No must follow the XXXXX-XXXXXXX-X format!")]
        [StringLength(15, ErrorMessage = "The CNIC No must follow the XXXXX-XXXXXXX-X format!", MinimumLength = 15)]
        [Remote("CheckCNIC", "Customer", HttpMethod = "POST", ErrorMessage = "CNIC No must follow the XXXXX-XXXXXXX-X format!")]
        public string CNIC { get; set; }

        [StringLength(LabelConstants.CityMaxLength, ErrorMessage = ValidationErrorConstants.MaxLength)]
        [SwaggerSchema("City of customer.", Nullable = false)]
        public string City { get; set; }

        //[Required]
        [SwaggerSchema("Province of customer.", Nullable = false)]
        [StringLength(LabelConstants.CityMaxLength, ErrorMessage = ValidationErrorConstants.MaxLength)]
        //[RegularExpression(RegexConstants.OnlyAlphabets, ErrorMessage = ValidationErrorConstants.AlphabetsError)]
        public string Province { get; set; }
        
        //[RegularExpression(@"^(?! )[A-Za-z0-9 _@()./#&$%+-]*(?<! )$", ErrorMessage = "The Business Name only accept alphanumeric and special characters(@./#$&%+-) with no leading and trailing spaces.")]
        [StringLength(LabelConstants.NameMaxLength, ErrorMessage = ValidationErrorConstants.MinLength, MinimumLength = 1)]
        [Required]
        [Display(Name = "Business Name")]
        public string BusinessName { get; set; }

        //[Required]
        [SwaggerSchema("Email of customer.", Nullable = true, Format = "jsmith@example.com")]
        //[Remote("CheckDupEmail", "Customer", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Customer already exists.")]
        [EmailAddress(ErrorMessage = ValidationErrorConstants.EmailNotValid)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Remote("CheckDupNumber", "Customer", AdditionalFields = "Id", HttpMethod = "POST")]
        [StringLength(13, ErrorMessage = "Please enter mobile number in valid format (+923XXXXXXXXX).", MinimumLength = 13)]
        [Display(Name = "Mobile Number")]
        [SwaggerSchema("Phone number of customer.", Nullable = false, Format = "jsmith@example.com")]
        public string PhoneNumber { get; set; }

        [SwaggerSchema("Current balance of customer.", Nullable = true)]
        public double Balance { get; set; } = 0;

        [JsonIgnore]
        public string DiscountId { get; set; }

        [JsonIgnore]
        public virtual Discount Discount { get; set; }

        public string RouteAxCode { get; set; }

        [Display(Name = "Route")]
        [JsonIgnore]
        public Guid RouteId { get; set; }
        [JsonIgnore]
        public string RouteName { get; set; }
        [JsonIgnore]

        public string ErrorStatus { get; set; }

        [RegularExpression(@"^(\+|-)?(?:90(?:(?:\.0{1,6})?)|(?:[0-9]|[1-8][0-9])(?:(?:\.[0-9]{1,40})?))$", ErrorMessage = "Not a valid lat value.")]
        [SwaggerSchema("Latitude value of address.", Nullable = true)]

        public string Latitude { get; set; }

        [RegularExpression(@"^(\+|-)?(?:180(?:(?:\.0{1,6})?)|(?:[0-9]|[1-9][0-9]|1[0-7][0-9])(?:(?:\.[0-9]{1,40})?))$", ErrorMessage = "Not a valid long value.")]
        [SwaggerSchema("Longitude value of address.", Nullable = true)]

        public string Longitude { get; set; }

        [JsonIgnore]
        public string PictureId { get; set; }
 
        [JsonIgnore]
        public virtual ResourceFile? ProfilePicture { get; set; }
        [Remote("CheckDupAxCode", "Customer", AdditionalFields = "Id", HttpMethod = "POST")]
        public string AxCode { get; set; }
    }
    public class CustomerTableViewModel
    {
        public string BusinessName { get; set; }
        public Guid Id { get; set; }
        public string AxCode { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string RouteName { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string AssignedSP { get; set; }
        public string SyncStatus { get; set; }
    }
    public class CustomerInfoViewModel
    {
        public string BusinessName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CNIC { get; set; }
        public string RouteName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public ResourceFile Image { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}