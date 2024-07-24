using ReadyGo.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class EmailSettingsViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ValidationErrorConstants.RequiredError)]
        [Display(Name = "Smtp Host")]
        public string SmtpHost { get; set; }
        [Required(ErrorMessage = ValidationErrorConstants.RequiredError)]
        [Display(Name = "Smtp Port")]
        public int SmtpPort { get; set; }
        [Required(ErrorMessage = ValidationErrorConstants.RequiredError)]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage =  ValidationErrorConstants.NotValid)]
        public string SmtpEmailAddress { get; set; }
        [Required(ErrorMessage = ValidationErrorConstants.RequiredError)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string SmtpPassword { get; set; }
        public bool EnableSSL { get; set; }
    }
}
