using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Interfaces.Services
{
    public interface ISettingsService
    {
        IEnumerable<Entities.Devices.Settings> GetSettings(int companyId);

        Entities.Devices.Settings GetSettingsById(int id);

        Entities.Devices.Settings AddSettings(SettingsInput settingsInput);

        IEnumerable<Entities.Devices.Settings> GetActiveSettings(int companyId);

        IEnumerable<Entities.Devices.Settings> GetInactiveSettings(int companyId);

        Entities.Devices.Settings UpdateSettings(int settingsId, SettingsInput settingsInput);

        Entities.Devices.Settings UpdateSettingsStatus(int settingsId, SettingsStatus status);

        int GetTotalAmountOfSettings(int companyId);
    }
}
