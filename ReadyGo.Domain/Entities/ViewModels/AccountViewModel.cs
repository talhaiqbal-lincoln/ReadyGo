using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = ValidationErrorConstants.NotValid)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = ValidationErrorConstants.NotValid)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(LabelConstants.PasswordMaxLength, ErrorMessage = ValidationErrorConstants.MinLength, MinimumLength = LabelConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Required]
        [Compare("Password", ErrorMessage = ValidationErrorConstants.PassMismatch)]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = ValidationErrorConstants.NotValid)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(LabelConstants.PasswordMaxLength, ErrorMessage = ValidationErrorConstants.MinLength, MinimumLength = LabelConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = ValidationErrorConstants.PassMismatch)]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress(ErrorMessage = ValidationErrorConstants.NotValid)]
        [Display(Name = "Email Address")]
        [Remote("CheckMail", "Account", HttpMethod = "POST", ErrorMessage = ValidationErrorConstants.NoEmailFound)]
        public string Email { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Old Password")]
        [StringLength(LabelConstants.PasswordMaxLength, ErrorMessage = ValidationErrorConstants.MinLength, MinimumLength = LabelConstants.PasswordMinLength)]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(LabelConstants.PasswordMaxLength, ErrorMessage = ValidationErrorConstants.MinLength, MinimumLength = LabelConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required]
        [StringLength(LabelConstants.PasswordMaxLength, ErrorMessage = ValidationErrorConstants.MinLength, MinimumLength = LabelConstants.PasswordMinLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = ValidationErrorConstants.PassMismatch)]
        public string ConfirmPassword { get; set; }
    }
}