using ReadyGo.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReadyGo.Domain.Entities
{
    public class ResourceFile : BaseEntity
    {
        [Required]
        [StringLength(25)]
        public string MimeType { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public byte[] File { get; set; }

        #region NavigationalProperties:
        [InverseProperty("ProfileImage")]
        public virtual ApplicationUser ImageUser { get; set; }
        [InverseProperty("ProfilePicture")]
        public virtual Customer ImageCustomer { get; set; }
        #endregion
    }
}
