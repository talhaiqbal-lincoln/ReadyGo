using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ReadyGo.Domain.Entities
{
    public class Category : BaseEntity
    {
        [StringLength(25)]
        [Required]
        public string Name { get; set; }
        public int Position { get; set; }
        public string AxCode { get; set; }

        public DateTime? SyncedAt { get; set; }
        #region Navigational_Properties:

        [JsonIgnore]
        [XmlIgnore]
        [InverseProperty("Category")]
        public virtual ICollection<Product> Products { get; set; }
        #endregion
    }
}
