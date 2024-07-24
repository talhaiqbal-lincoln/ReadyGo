using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ReadyGo.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string AXCode { get; set; }

        [Required]
        public string VehicleNumber { get; set; }

        public string Model { get; set; }
        public string Type { get; set; }
        public string DriverName { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        [InverseProperty("Vehicle")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
