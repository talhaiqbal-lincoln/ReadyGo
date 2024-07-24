using ReadyGo.Domain.Entities;
using ReadyGo.Infrastructure.ViewModel;
using ReadyGo.Persistence;
using ReadyGo.Service.Interfaces;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ReadyGo.Service.Services
{
    public class EmailService : IEmailService
    {
        public IApplicationDbContext _applicationDbContext { get; }

        public EmailService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<bool> SendEmailAsync(EmailRequest request)
        {
            try
            {
                using var smtpclient = new SmtpClient();
                var mailSettings = _applicationDbContext.MailSettings.FirstOrDefault();
                var credential = new NetworkCredential
                {
                    UserName = mailSettings.SmtpEmailAddress,
                    Password = mailSettings.SmtpPassword
                };

                smtpclient.Port = mailSettings.SmtpPort;
                smtpclient.EnableSsl = mailSettings.EnableSSL;
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = credential;
                smtpclient.Host = mailSettings.SmtpHost;
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(mailSettings.SmtpEmailAddress),
                    BodyEncoding = Encoding.UTF8
                };
                mailMessage.To.Add(request.ToEmail);
                mailMessage.Body = request.Body;
                mailMessage.Subject = request.Subject;
                mailMessage.IsBodyHtml = request.IsBodyHtml;

                await smtpclient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SendEmail(EmailRequest request)
        {
            try
            {
                using var smtpclient = new SmtpClient();
                var mailSettings = _applicationDbContext.MailSettings.FirstOrDefault();
                var credential = new NetworkCredential
                {
                    UserName = mailSettings.SmtpEmailAddress,
                    Password = mailSettings.SmtpPassword
                };

                smtpclient.Port = mailSettings.SmtpPort;
                smtpclient.EnableSsl = mailSettings.EnableSSL;
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = credential;
                smtpclient.Host = mailSettings.SmtpHost;
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(mailSettings.SmtpEmailAddress),
                    BodyEncoding = Encoding.UTF8
                };
                mailMessage.To.Add(request.ToEmail);
                mailMessage.Body = request.Body;
                mailMessage.Subject = request.Subject;
                mailMessage.IsBodyHtml = request.IsBodyHtml;

                smtpclient.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool TestMail(EmailSettings sender,EmailRequest receiver)
        {
            try
            {
                using var smtpclient = new SmtpClient();
                var credential = new NetworkCredential
                {
                    UserName = sender.SmtpEmailAddress,
                    Password = sender.SmtpPassword
                };

                smtpclient.Port = sender.SmtpPort;
                smtpclient.EnableSsl = sender.EnableSSL;
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = credential;
                smtpclient.Host = sender.SmtpHost;
                smtpclient.DeliveryMethod = SmtpDeliveryMethod.Network;

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(sender.SmtpEmailAddress),
                    BodyEncoding = Encoding.UTF8
                };
                mailMessage.To.Add(receiver.ToEmail);
                mailMessage.Body = receiver.Body;
                mailMessage.Subject = receiver.Subject;
                mailMessage.IsBodyHtml = receiver.IsBodyHtml;

                smtpclient.Send(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
