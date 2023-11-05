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
        IEnumerable<Treinamento.REST.Domain.Entities.Devices.Settings> GetSettings(int skip, int pageSize);

        int CountSettings();
        int CountActiveSettings();

        int CountInactiveSettings();

        Treinamento.REST.Domain.Entities.Devices.Settings GetSettingsById(int id);

        Treinamento.REST.Domain.Entities.Devices.Settings AddSettings(SettingsInput settingsInput);

        Treinamento.REST.Domain.Entities.Devices.Settings UpdateSettings(int settingsId, SettingsInput settingsInput);

        bool DeleteSettingsById(int settingsId);

        Treinamento.REST.Domain.Entities.Devices.Settings UpdateSettingsStatus(int settingsId, SettingsStatus status);

        //Device UpdateDeviceUsedHours(int deviceId, int hours);

        //float GetDeviceUsedHours(int deviceId);
    }
}
