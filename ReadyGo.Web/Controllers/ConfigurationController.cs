using Microsoft.AspNetCore.Mvc;
using ReadyGo.Domain.Entities;
using ReadyGo.Infrastructure.Filters;
using ReadyGo.Service.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using ReadyGo.Domain.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ReadyGo.Web.Controllers
{
    [Authorize]
    [TypeFilter(typeof(AdminAccessFilter))]
    public class ConfigurationController : BaseController
    {
        private readonly IGenericRepository<Configuration> _configRepo;

        public ConfigurationController(IGenericRepository<Configuration> configRepo)
        {
            _configRepo = configRepo;
        }

        public IActionResult Index()
        {
            IEnumerable<Configuration> list = _configRepo.GetAll();
            return View(list);
        }


        [HttpPost]
        [ModelValidationFilter]
        public IActionResult SaveConfiguration(IFormCollection configlist)
        {
            try
            {
                Configuration configuration = new Configuration();
                foreach (var config in configlist)
                {
                    if (config.Key != "__RequestVerificationToken")
                    {
                        var configKey = "";
                        configKey = config.Key.Trim(new Char[] { '\"' });
                        configuration = _configRepo.FindBy(x => x.ConfigKey.Equals(configKey));
                        configuration.ConfigKey = configKey;
                        configuration.Value = config.Value.Count > 1 ? config.Value[1] : config.Value[0];
                        _configRepo.Update(configuration);
                    }
                }
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Configuration")
                });
            }
            catch (Exception ex)
            {
                LogException(ex);
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }
        [HttpPost]
        public IActionResult SaveTerms(string terms)
        {
            try
            {
                var config = _configRepo.Get(AppConstants.TermsConditions);
                config.Value = terms;
                _configRepo.Update(config);
                return Ok(new
                {
                    Message = string.Format(SuccessMessageConstants.UpdateSuccess, "Terms & Conditions")
                });
            }
            catch(Exception ex)
            {
                return BadRequest(new
                {
                    Message = ErrorMessageConstants.Error
                });
            }
        }
    }
}