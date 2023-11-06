using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Auth;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.Devices.Output;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Interfaces.Services
{
    public interface IDeviceService
    {
        IEnumerable<Device> GetDevices(int companyId);
        Device GetDeviceById(int id);
        int GetTotalAmountOfDevices(int companyId);
        Device AddDevice(DeviceInput deviceInput);
        Device UpdateDevice(int deviceId, DeviceInput deviceInput);
        DeviceReport GetDeviceReport(int companyId);
        Dashboard GetDashboard(int companyId);
    }
}
