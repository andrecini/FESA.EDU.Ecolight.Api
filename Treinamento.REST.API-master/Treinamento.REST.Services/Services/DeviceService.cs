using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Domain.Interfaces.Repositories;
using Treinamento.REST.Domain.Interfaces.Services;

namespace Treinamento.REST.Services.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public IEnumerable<Device> GetDevices(int skip, int pageSize)
        {
            return _deviceRepository.GetDevices(skip, pageSize);
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

        public IEnumerable<Device> GetActiveDevices(int skip, int pageSize)
        {
            var devices = _deviceRepository.GetDevices(skip, pageSize);

            var activeDevices = devices.Where(x => x.Enable == SettingsStatus.Active);

            return activeDevices;
        }

        public IEnumerable<Device> GetInactiveDevices(int skip, int pageSize)
        {
            var devices = _deviceRepository.GetDevices(skip, pageSize);

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

        public int GetTotalAmountOfDevices()
        {
            var totalAmount = _deviceRepository.CountDevices();

            return totalAmount;
        }

        public float GetAllDevicesCarbonTax()
        {
            throw new NotImplementedException();
        }

        public float GetAllDevicesExpenses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Device> GetCriticalDevices(int skip, int pageSize)
        {
            throw new NotImplementedException();
        }

        public float GetDeviceEnergySaving(int deviceId)
        {
            throw new NotImplementedException();
        }

        public float GetDeviceExpenses(int deviceId)
        {
            throw new NotImplementedException();
        }

        public float GetDeviceExpenseSavings(int deviceId)
        {
            throw new NotImplementedException();
        }

        public float GetDeviceUsedHours(int deviceId)
        {
            throw new NotImplementedException();
        }

        public float GetMonthDeviceEnergyExpenses(int deviceId, int month)
        {
            throw new NotImplementedException();
        }

        public float GetMonthDeviceExpenses(int deviceId, int month)
        {
            throw new NotImplementedException();
        }

        public Device UpdateDeviceLampAmount(int deviceId)
        {
            throw new NotImplementedException();
        }

        public Device UpdateDeviceUsedHours(int deviceId, int hours)
        {
            throw new NotImplementedException();
        }

        public bool DeleteDeviceById(int deviceId)
        {
            throw new NotImplementedException();
        }
    }
}
