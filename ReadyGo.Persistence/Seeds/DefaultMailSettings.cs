using ReadyGo.Domain.Entities;

namespace ReadyGo.Persistence.Seeds
{
    public static class DefaultMailSettings
    {
        public static EmailSettings MailSetting()
        {
            return new EmailSettings
            {
                Id = 1,
                SmtpEmailAddress = "Lighthousetestmail@gmail.com",
                SmtpPassword = "ReadyGoWebApp1",
                EnableSSL = true,
                SmtpHost = "smtp.gmail.com",
                SmtpPort = 587
            };
        }
    }
}