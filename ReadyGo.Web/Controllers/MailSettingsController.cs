using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Constants;
using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Entities.ViewModels;
using ReadyGo.Domain.Enum;
using ReadyGo.Infrastructure.Filters;
using ReadyGo.Infrastructure.ViewModel;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    public class MailSettingsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<EmailSettings> _emailRepo;

        public MailSettingsController(IMapper mapper, IGenericRepository<EmailSettings> emailRepo)
        {
            _emailRepo = emailRepo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var emailSettings = _emailRepo.GetAll().FirstOrDefault();
            var emailSettingsVM = _mapper.Map<EmailSettingsViewModel>(emailSettings);
            return View(emailSettingsVM);
        }

        [HttpPost]
        [ModelValidationFilter]
        public async Task<IActionResult> SaveSetting(EmailSettingsViewModel emailSettingsVM)
        {
            var mailSettings = _mapper.Map<EmailSettings>(emailSettingsVM);
            EmailRequest email = new EmailRequest
            {
                Body = EmailConstants.TestEmailBody,
                IsBodyHtml = false,
                Subject = EmailConstants.TestEmailSubject,
                ToEmail = mailSettings.SmtpEmailAddress
            };

            bool isValid = _emailSender.TestMail(mailSettings, email);
            if (isValid)
            {
                _emailRepo.Update(mailSettings);
                await AddLogAsync(LogActions.ConfigurationChanged.GetDescription(), string.Empty, LogsActionSrc.MailSettings.ToString());
            }
            else
            {
                ModelState.AddModelError(string.Empty, string.Format(ErrorMessageConstants.NotValid, "Email Configuration"));
                return BadRequest(new { Message = string.Format(ErrorMessageConstants.NotValid, "Email Configuration") });
            }

            return Ok(new { Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Email Configurations") });
        }
    }
}