using ReadyGo.Domain.Constants;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class ConfigurationViewModel : BaseEntity
    {
        [Required(ErrorMessage = ValidationErrorConstants.RequiredError)]
        [StringLength(25)]
        [Display(Name = "Configuration Key")]
        public string ConfigKey { get; set; }
        [Required(ErrorMessage = ValidationErrorConstants.RequiredError)]
        [StringLength(50)]
        public string Value { get; set; }
    }
}
