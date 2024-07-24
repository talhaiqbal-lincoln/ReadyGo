using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities
{
    public class Configuration : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string ConfigKey { get; set; }
        [Required]
        [StringLength(255)]
        public string Value { get; set; }
    }
}
