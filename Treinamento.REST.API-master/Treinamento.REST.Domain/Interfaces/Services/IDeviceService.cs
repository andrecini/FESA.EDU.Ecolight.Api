using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Auth;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Interfaces.Services
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetDevices(int skip, int pageSize);

        IEnumerable<Device> GetCriticalDevices(int skip, int pageSize);

        IEnumerable<Device> GetActiveDevices(int skip, int pageSize);

        IEnumerable<Device> GetInactiveDevices(int skip, int pageSize);

        Device GetDeviceById(int id);

        int GetTotalAmountOfDevices();

        Device AddDevice(DeviceInput deviceInput);

        Device UpdateDevice(int deviceId, DeviceInput deviceInput);

        bool DeleteDeviceById(int deviceId);

        Device UpdateDeviceLampAmount(int deviceId);

        Device UpdateDeviceStatus(int deviceId, SettingsStatus status);

        Device UpdateDeviceUsedHours(int deviceId, int hours);

        float GetDeviceUsedHours(int deviceId);

        float GetDeviceExpenses(int deviceId);

        float GetDeviceEnergySaving(int deviceId);

        float GetMonthDeviceExpenses(int deviceId, int month);
        
        float GetMonthDeviceEnergyExpenses(int deviceId, int month);

        float GetDeviceExpenseSavings(int deviceId);

        float GetAllDevicesCarbonTax();

        float GetAllDevicesExpenses();

    }
}
