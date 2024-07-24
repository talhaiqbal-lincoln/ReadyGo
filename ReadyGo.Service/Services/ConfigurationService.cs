using ReadyGo.Domain.Entities;
using ReadyGo.Domain.Enum;
using ReadyGo.Persistence.Seeds;
using ReadyGo.Service.Interfaces;
using ReadyGo.Service.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ReadyGo.Service.Services
{
    public class ConfigurationService : IConfigurationService
    {
        private readonly IGenericRepository<Configuration> _configRepo;

        public ConfigurationService(IGenericRepository<Configuration> configRepo)
        {
            _configRepo = configRepo;
        }
        public List<Configuration> GetConfiguration(string role)
        {
            var config = _configRepo.GetAll().ToList();
            string custManag = "1";
            string stockManag = "1";
            string salesPersonManag = "1";
            if (role.CompareTo(Roles.SalesManager.GetDescription()) == 0)
            {
                custManag = config.Where(x => x.ConfigKey == "Sales Manager_Customer").FirstOrDefault().Value;
                stockManag = config.Where(x => x.ConfigKey == "Sales Manager_Stock").FirstOrDefault().Value;
                salesPersonManag = config.Where(x => x.ConfigKey == "Sales Manager_SalesPerson").FirstOrDefault().Value;
            }
            else if (role.CompareTo(Roles.MarketingManager.GetDescription()) == 0)
            {
                custManag = config.Where(x => x.ConfigKey == "Marketing Manager_Customer").FirstOrDefault().Value;
                stockManag = config.Where(x => x.ConfigKey == "Marketing Manager_Stock").FirstOrDefault().Value;
                salesPersonManag = config.Where(x => x.ConfigKey == "Marketing Manager_SalesPerson").FirstOrDefault().Value;
            }
            List<Configuration> configurations = new List<Configuration> { new Configuration { ConfigKey = "custManag", Value = custManag }, new Configuration { ConfigKey = "stockManag", Value = stockManag }, new Configuration { ConfigKey = "salesPersonManag", Value = salesPersonManag } };
            return configurations;
        }
    }
}
