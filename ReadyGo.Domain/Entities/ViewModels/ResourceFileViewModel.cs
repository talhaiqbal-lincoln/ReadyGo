using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities.ViewModels
{
    public class ResourceFileViewModel : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string MimeType { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public byte[] File { get; set; }
        public string ImageUrl { get; set; }
    }
}
