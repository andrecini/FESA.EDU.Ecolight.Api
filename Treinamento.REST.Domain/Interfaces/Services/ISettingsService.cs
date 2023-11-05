using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Interfaces.Services
{
    public interface ISettingsService
    {
        IEnumerable<Entities.Devices.Settings> GetSettings(int skip, int pageSize);

        Entities.Devices.Settings GetSettingsById(int id);

        Entities.Devices.Settings AddSettings(SettingsInput settingsInput);

        IEnumerable<Entities.Devices.Settings> GetActiveSettings(int skip, int pageSize);

        IEnumerable<Entities.Devices.Settings> GetInactiveSettings(int skip, int pageSize);

        Entities.Devices.Settings UpdateSettings(int settingsId, SettingsInput settingsInput);

        Entities.Devices.Settings UpdateSettingsStatus(int settingsId, SettingsStatus status);

        int GetTotalAmountOfSettings();
    }
}
