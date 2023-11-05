using System;
using System.Collections.Generic;
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
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public Device AddDevice(DeviceInput deviceInput)
        {
            var user = Device.Map(deviceInput);

            return _deviceRepository.AddDevice(deviceInput);
        }

        public bool DeleteDeviceById(int deviceId)
        {
            return _deviceRepository.DeleteDeviceById(deviceId);
        }

        public IEnumerable<Device> GetActiveDevices(int skip, int pageSize)
        {
            throw new NotImplementedException();
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

        public Device GetDeviceById(int id)
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

        public IEnumerable<Device> GetDevices(int skip, int pageSize)
        {
            throw new NotImplementedException();
        }

        public float GetDeviceUsedHours(int deviceId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Device> GetInactiveDevices(int skip, int pageSize)
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

        public int GetTotalAmountOfDevices()
        {
            throw new NotImplementedException();
        }

        public Device UpdateDevice(int deviceId, UserInput userInput)
        {
            throw new NotImplementedException();
        }

        public Device UpdateDeviceLampAmount(int deviceId)
        {
            throw new NotImplementedException();
        }

        public Device UpdateDeviceStatus(int deviceId, DeviceStatus status)
        {
            throw new NotImplementedException();
        }

        public Device UpdateDeviceUsedHours(int deviceId, int hours)
        {
            throw new NotImplementedException();
        }
    }
}
