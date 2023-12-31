﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.Devices.Output;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Interfaces.Repositories
{
    public interface IDeviceRepository
    {
        IEnumerable<Device> GetDevices(int companyId);

        int CountDevices(int companyId);

        int CountActiveDevices();

        int CountInactiveDevices();

        Device GetDeviceById(int id);

        Device AddDevice(DeviceInput deviceInput);

        Device UpdateDevice(Device device);

        bool DeleteDeviceById(int deviceId);

        Device UpdateDeviceStatus(int deviceId, SettingsStatus status);
    }
}
