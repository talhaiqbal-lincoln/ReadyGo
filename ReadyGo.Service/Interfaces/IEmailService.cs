using ReadyGo.Domain.Entities;
using ReadyGo.Infrastructure.ViewModel;
using System.Threading.Tasks;

namespace ReadyGo.Service.Interfaces
{
    public interface IEmailService
    {
        bool SendEmail(EmailRequest emailModel); 
        Task<bool> SendEmailAsync(EmailRequest emailModel);
        bool TestMail(EmailSettings sender, EmailRequest receiver);
    }
}
