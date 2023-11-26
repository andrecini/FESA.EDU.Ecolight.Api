using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Data.Repositories;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Domain.Interfaces.Repositories;
using Treinamento.REST.Tests.Mocks.Data;

namespace Treinamento.REST.Tests.Mocks.Repository
{
    public static class DeviceRepositoryMock
    {
        private static IDeviceRepository _repository;

        public static IDeviceRepository Get()
        {
            if (_repository == null) CreateInstance();

            return _repository;
        }

        private static void CreateInstance()
        {
            var mock = new Mock<IDeviceRepository>();

            mock.Setup(x => x.CountDevices(It.IsAny<int>())).Returns(10);
            mock.Setup(x => x.CountActiveDevices()).Returns(10);
            mock.Setup(x => x.CountInactiveDevices()).Returns(0);
            mock.Setup(x => x.GetDeviceById(It.IsAny<int>())).Returns(DeviceData.GetSample()["Simples"]);
            mock.Setup(x => x.GetDevices(It.IsAny<int>())).Returns(DeviceData.GetList(10));
            mock.Setup(x => x.AddDevice(It.IsAny<DeviceInput>())).Returns(DeviceData.GetSample()["Simples"]);
            mock.Setup(x => x.UpdateDevice(It.IsAny<Device>())).Returns(DeviceData.GetSample()["Editado"]);
            mock.Setup(x => x.UpdateDeviceStatus(It.IsAny<int>(), It.IsAny<SettingsStatus>())).Returns(DeviceData.GetSample()["Editado"]);
            mock.Setup(x => x.DeleteDeviceById(It.IsAny<int>())).Returns(true);

            _repository = mock.Object;
        }
    }
}
