using System.ComponentModel.Design;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.Devices.Output;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Domain.Interfaces.Repositories;
using Treinamento.REST.Domain.Interfaces.Services;

namespace Treinamento.REST.Services.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IHistoricService _historicService;

        public DeviceService(IDeviceRepository deviceRepository, IHistoricService historicService)
        {
            _deviceRepository = deviceRepository;
            _historicService = historicService;
        }

        public IEnumerable<Device> GetDevices(int companyId)
        {
            return _deviceRepository.GetDevices(companyId);
        }

        public Device GetDeviceById(int id)
        {
            return _deviceRepository.GetDeviceById(id);
        }

        public Device AddDevice(DeviceInput deviceInput)
        {
            var user = Device.Map(deviceInput);

            return _deviceRepository.AddDevice(deviceInput);
        }

        public IEnumerable<Device> GetActiveDevices(int companyId)
        {
            var devices = _deviceRepository.GetDevices(companyId);

            var activeDevices = devices.Where(x => x.Enable == SettingsStatus.Active);

            return activeDevices;
        }

        public IEnumerable<Device> GetInactiveDevices(int companyId)
        {
            var devices = _deviceRepository.GetDevices(companyId);

            var inactiveDevices = devices.Where(x => x.Enable == SettingsStatus.Inactive);

            return inactiveDevices;
        }

        public Device UpdateDevice(int deviceId, DeviceInput deviceInput)
        {
            var device = Device.Map(deviceId, deviceInput);

            var updatedDevice = _deviceRepository.UpdateDevice(device);

            return updatedDevice;
        }

        public Device UpdateDeviceStatus(int deviceId, SettingsStatus status)
        {
            var updatedDevice = _deviceRepository.UpdateDeviceStatus(deviceId, status);

            return updatedDevice;
        }

        public int GetTotalAmountOfDevices(int companyId)
        {
            var totalAmount = _deviceRepository.CountDevices(companyId);

            return totalAmount;
        }

        public DeviceReport GetDeviceReport(int companyId)
        {
            var report = new DeviceReport
            {
                CarbonEmission = GetAllDevicesCarbonTax(companyId),
                DevicesExpenses = GetAllDevicesExpenses(companyId),
                CriticalDevices = GetCriticalDevices(companyId),
                AllDevices = GetAllDevices(companyId),
                MonthlyDevicesExpenseSavings = GetLastSixMonthsExpensesSaving(companyId),
                MonthlyKwhSavings = GetLastSixMonthsEnergySaving(companyId)
            };

            return report;
        }

        public Dashboard GetDashboard(int companyId)
        {
            var dashboard = new Dashboard
            {
                Active = GetActiveDevices(companyId).Count(),
                Inactive = GetInactiveDevices(companyId).Count(),
                MonthlyDeviceExpenses = GetLastSixMonthsExpenses(companyId),
                MonthlyKwhUsage = GetLastSixMonthsEnergyExpenses(companyId)
            };

            dashboard.Total = dashboard.Active + dashboard.Inactive;

            return dashboard;
        }

        #region Reports Methods

        private IEnumerable<Device> GetAllDevices(int companyId)
        {
            var devices = GetDevices(companyId);

            foreach (var device in devices)
            {
                device.UsedKWH = GetMonthDevicesEnergyExpenses(companyId, DateTime.Now.Month, DateTime.Now.Year);
            }

            return devices;
        }

        private IEnumerable<float> GetLastSixMonthsExpensesSaving(int companyId)
        {
            var devices = GetDevices(companyId);
            var list = new List<float>();

            for (int i = 5; i >= 0; i--)
            {
                var dataAtual = DateTime.Now.AddMonths(-i);
                var expenseSaving = GetMonthDeviceExpenseSavings(companyId, dataAtual.Month, dataAtual.Year);
                list.Add(expenseSaving);
            }

            return list;
        }

        private IEnumerable<float> GetLastSixMonthsExpenses(int companyId)
        {
            var devices = GetDevices(companyId);
            var list = new List<float>();

            for (int i = 5; i >= 0; i--)
            {
                var dataAtual = DateTime.Now.AddMonths(-i);
                var expenses = GetMonthDevicesExpenses(companyId, dataAtual.Month, dataAtual.Year);
                list.Add(expenses);
            }

            return list;
        }

        private IEnumerable<float> GetLastSixMonthsEnergySaving(int companyId)
        {
            var devices = GetDevices(companyId);
            var list = new List<float>();

            for (int i = 5; i >= 0; i--)
            {
                var dataAtual = DateTime.Now.AddMonths(-i);
                var energySaving = GetMonthDeviceEnergySaving(companyId, dataAtual.Month, dataAtual.Year);
                list.Add(energySaving);
            }

            return list;
        }

        private IEnumerable<float> GetLastSixMonthsEnergyExpenses(int companyId)
        {
            var devices = GetDevices(companyId);
            var list = new List<float>();

            for (int i = 5; i >= 0; i--)
            {
                var dataAtual = DateTime.Now.AddMonths(-i);
                var expenses = GetMonthDevicesEnergyExpenses(companyId, dataAtual.Month, dataAtual.Year);
                list.Add(expenses);
            }

            return list;
        }

        private float GetAllDevicesCarbonTax(int companyId)
        {
            return GetDevicesUsedHoursByCompanyId(companyId) * (float)0.0125;
        }

        private float GetAllDevicesExpenses(int companyId)
        {
            double kwhPrice = 0.74;

            return (GetDevicesUsedHoursByCompanyId(companyId) * 60 / 1000) * (float)kwhPrice;
        }

        private IEnumerable<Device> GetCriticalDevices(int companyId)
        {
            List<Device> criticalDevices = new List<Device>();
            var devices = GetDevices(companyId);

            foreach (var device in devices)
            {
                var tempo = GetDeviceUsedHoursByDeviceId(device.Id);
                if (tempo > 100)
                    criticalDevices.Add(device);
            }

            return criticalDevices;
        }

        private float GetDeviceExpenses(int deviceId)
        {
            var kwh = (float)0.74;
            var watt = (float)60;

            return (GetDeviceUsedHoursByDeviceId(deviceId) * watt / 1000) * (float)kwh;
        }

        private float GetMonthDeviceEnergySaving(int companyId, int month, int year)
        {
            double maxExpenses = 30 * 60 * 24 * _deviceRepository.CountDevices(companyId) / 1000;
            return (float)maxExpenses - GetMonthDevicesEnergyExpenses(companyId, month, year);
        }

        private float GetMonthDeviceExpenseSavings(int companyId, int month, int year)
        {
            double maxExpenses = 30 * 60 * 24 * _deviceRepository.CountDevices(companyId) / 1000 * 0.74;
            return (float)maxExpenses - GetMonthDevicesExpenses(companyId, month, year);
        }

        private float GetDeviceUsedHours(int deviceId)
        {
            return GetDeviceUsedHoursByDeviceId(deviceId);
        }

        private float GetMonthDevicesEnergyExpenses(int companyId, int month, int year)
        {
            var watt = 60;

            return (GetMonthDevicesUsedHoursByCompanyId(companyId, month, year) * (float)watt) / 1000;
        }

        private float GetMonthDevicesExpenses(int companyId, int month, int year)
        {
            var kwh = 0.74;

            return GetMonthDevicesEnergyExpenses(companyId, month, year) * (float)kwh;
        }

        private float GetDeviceUsedHoursByDeviceId(int deviceId)
        {
            List<int> ids = new List<int>();
            double tempo = 0;
            var historics = _historicService.GetHistorics();

            foreach (var historic in historics)
                if (!ids.Contains(historic.DeviceId))
                    ids.Add(historic.DeviceId);

            DateTime hoje = DateTime.Now;
            DateTime dataInicio = new DateTime(hoje.Year, hoje.Month, 1, 0, 0, 0);
            foreach (var historic in historics)
            {
                if (historic.DeviceId == deviceId)
                {
                    if (historic.Status == "0")
                    {
                        var tempoEmSegundos = (historic.Date - dataInicio).TotalSeconds;
                        tempo += (tempoEmSegundos / 3600);
                    }
                    else if (historic.Status == "1")
                    {
                        dataInicio = historic.Date;
                    }
                }
            }

            return (float)tempo;
        }

        private float GetDevicesUsedHoursByCompanyId(int companyId)
        {
            List<int> ids = new List<int>();
            var historics = _historicService.GetHistoricsByCompanyId(companyId);
            double tempo = 0;

            foreach (var historic in historics)
                if (!ids.Contains(historic.DeviceId))
                    ids.Add(historic.DeviceId);

            foreach (int key in ids)
            {
                DateTime hoje = DateTime.Now;
                DateTime dataInicio = new DateTime(hoje.Year, hoje.Month, 1, 0, 0, 0);
                foreach (var historic in historics)
                {
                    if (historic.DeviceId == key)
                    {
                        if (historic.Status == "0")
                        {
                            var tempoEmSegundos = (historic.Date - dataInicio).TotalSeconds;
                            tempo += (tempoEmSegundos / 3600);
                        }
                        else if (historic.Status == "1")
                        {
                            dataInicio = historic.Date;
                        }
                    }
                }
            }

            return (float)tempo;

        }

        private float GetMonthDevicesUsedHoursByCompanyId(int companyId, int month, int year)
        {
            List<int> ids = new List<int>();
            var historics = _historicService.GetHistoricsByCompanyId(companyId);
            double tempo = 0;

            foreach (var historic in historics)
                if (!ids.Contains(historic.DeviceId))
                    ids.Add(historic.DeviceId);

            foreach (int key in ids)
            {
                DateTime hoje = DateTime.Now;
                DateTime dataInicio = new DateTime(hoje.Year, hoje.Month, 1, 0, 0, 0);
                foreach (var historic in historics)
                {
                    if (historic.Date.Month == month && historic.Date.Year == year)
                        if (historic.DeviceId == key)
                        {
                            if (historic.Status == "0")
                            {
                                var tempoEmSegundos = (historic.Date - dataInicio).TotalSeconds;
                                tempo += (tempoEmSegundos / 3600);
                            }
                            else if (historic.Status == "1")
                            {
                                dataInicio = historic.Date;
                            }
                        }
                }
            }

            return (float)tempo;
        }

        #endregion

    }
}
