using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class ContactViewModel
    {
        [Required(ErrorMessage ="Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; }
        
    }
}
