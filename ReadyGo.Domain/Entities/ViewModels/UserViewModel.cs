using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities.Identity;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.ViewModel;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class UserViewModel
    {
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        [Required]
        [RegularExpression(RegexConstants.Names, ErrorMessage = ValidationErrorConstants.AlphabetsError)]
        [StringLength(LabelConstants.NameMaxLength, ErrorMessage = ValidationErrorConstants.MinLength, MinimumLength = LabelConstants.NameMinLength)]
        public string FirstName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Last Name")]
        [RegularExpression(RegexConstants.Names, ErrorMessage = ValidationErrorConstants.AlphabetsError)]
        [StringLength(LabelConstants.NameMaxLength, ErrorMessage = ValidationErrorConstants.MinLength, MinimumLength = LabelConstants.NameMinLength)]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(13, ErrorMessage = "Please enter mobile number in valid format (+923XXXXXXXXX).", MinimumLength = 13)]
        [Display(Name = "Mobile Number")]
        [Required]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = ValidationErrorConstants.EmailNotValid)]
        [Required]
        [Remote("CheckDupEmail", "User", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "User already exists.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public string Id { get; set; }

        [Required]
        [Display(Name = "Address Line 1")]
        public string Address1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        [StringLength(LabelConstants.CityMaxLength, ErrorMessage = ValidationErrorConstants.MaxLength)]
        public string City { get; set; }

        [StringLength(LabelConstants.CityMaxLength, ErrorMessage = ValidationErrorConstants.MaxLength)]
        public string Province { get; set; }
        public string ErrorStatus { get; set; }
        public bool SmNotification { get; set; } = false;
        public bool SpNotification { get; set; } = false;
        public bool MmNotification { get; set; } = false;
        public ApplicationRole Role { get; set; }
        public string UserRole { get; set; }
        public ResourceFile ProfileImage { get; set; }
        [Remote("CheckDupAxCode", "User", AdditionalFields = "Id", HttpMethod = "POST")]
        public string AxCode { get; set; }
        [Required]
        [Display(Name = "Role")]
        public Guid RoleId { get; set; }
        public Roles RoleType { get; set; }
        public DateTime? SyncedAt { get; set; }
    }

    public class InviteTableViewModel
    {
        public string UserRole { get; set; }
        public string ProfileImage { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? InviteTime { get; set; }
        public bool TimeFlag { get; set; }
        public string Email { get; set; }
    }
    public class UserTableViewModel
    {
        public string AxCode { get; set; }
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfileImage { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsCurrentUser { get; set; }
        public string UserRole { get; set; }
        public bool IsActive { get; set; }
        public bool SyncedStatus { get; set; }
    }
    public class InvitationViewModel
    {
        public ApplicationUser User { get; set; }
        public string Email { get; set; }
        public EmailRequest EmailRequest { get; set; }
        public string CallBackUrl { get; set; }
    }
}