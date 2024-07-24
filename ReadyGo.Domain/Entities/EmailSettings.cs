using System;
using System.ComponentModel.DataAnnotations;

namespace ReadyGo.Domain.Entities
{
    public class EmailSettings
    {
        public int Id { get; set; }
        public string SmtpHost { get; set; }
        public int SmtpPort { get; set; }
        [DataType(DataType.EmailAddress)]
        public string SmtpEmailAddress { get; set; }
        [DataType(DataType.Password)]
        public string SmtpPassword { get; set; }
        public bool EnableSSL { get; set; }
    }
}
