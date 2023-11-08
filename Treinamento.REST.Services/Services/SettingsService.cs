using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Domain.Interfaces.Repositories;
using Treinamento.REST.Domain.Interfaces.Services;

namespace Treinamento.REST.Services.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _settingsRepository;

        public SettingsService(ISettingsRepository settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public IEnumerable<Settings> GetSettings(int companyId)
        {
            return _settingsRepository.GetSettings(companyId);
        }

        public Settings GetSettingsById(int id)
        {
            return _settingsRepository.GetSettingsById(id);
        }

        public Settings AddSettings(SettingsInput settingsInput)
        {
            return _settingsRepository.AddSettings(settingsInput);
        }

        public IEnumerable<Settings> GetActiveSettings(int companyId)
        {
            var settings = _settingsRepository.GetSettings(companyId);

            var activeSettings = settings.Where(x => x.Enable == true);

            return activeSettings;
        }

        public IEnumerable<Settings> GetInactiveSettings(int companyId)
        {
            var settings = _settingsRepository.GetSettings(companyId);

            var inactiveSettings = settings.Where(x => x.Enable == false);

            return inactiveSettings;
        }

        public Settings UpdateSettings(int settingsId, SettingsInput settingsInput)
        {
            var settings = Settings.Map(settingsId, settingsInput);

            var updatedSettings = _settingsRepository.UpdateSettings(settings);

            return updatedSettings;
        }

        public Settings UpdateSettingsStatus(int settingsId, SettingsStatus status)
        {
            var updatedDevice = _settingsRepository.UpdateSettingsStatus(settingsId, status);

            return updatedDevice;
        }

        public int GetTotalAmountOfSettings(int companyId)
        { 
            var totalAmount = _settingsRepository.CountSettings(companyId);

            return totalAmount;
        }
    }
}
