using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Interfaces.Repositories
{
    public interface ISettingsRepository
    {
        IEnumerable<Entities.Devices.Settings> GetSettings(int companyId);
        int CountSettings(int companyId);
        int CountActiveSettings(int companyId);
        int CountInactiveSettings(int companyId);
        Entities.Devices.Settings GetSettingsById(int id);
        Entities.Devices.Settings AddSettings(SettingsInput settingsInput);
        Entities.Devices.Settings UpdateSettings(Entities.Devices.Settings settings);
        bool DeleteSettingsById(int settingsId);
        Entities.Devices.Settings UpdateSettingsStatus(int settingsId, SettingsStatus status);
    }
}
