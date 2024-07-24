using ReadyGo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReadyGo.Service.Interfaces
{
    public interface IConfigurationService
    {
        List<Configuration> GetConfiguration(string role);
    }
}
