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
    public static class SettingsRepositoryMock
    {
        private static ISettingsRepository _repository;

        public static ISettingsRepository Get()
        {
            if (_repository == null) CreateInstance();

            return _repository;
        }

        private static void CreateInstance()
        {
            var mock = new Mock<ISettingsRepository>();

            mock.Setup(x => x.GetSettings(It.IsAny<int>())).Returns(SettingsData.GetList(20));
            mock.Setup(x => x.GetSettingsById(It.IsAny<int>())).Returns(SettingsData.GetSample()["Simples"]);
            mock.Setup(x => x.CountSettings(It.IsAny<int>())).Returns(10);
            mock.Setup(x => x.CountActiveSettings(It.IsAny<int>())).Returns(5);
            mock.Setup(x => x.CountInactiveSettings(It.IsAny<int>())).Returns(5);
            mock.Setup(x => x.AddSettings(It.IsAny<SettingsInput>())).Returns(SettingsData.GetSample()["Simples"]);
            mock.Setup(x => x.UpdateSettings(It.IsAny<Settings>())).Returns(SettingsData.GetSample()["Editado"]);
            mock.Setup(x => x.UpdateSettingsStatus(It.IsAny<int>(), It.IsAny<SettingsStatus>())).Returns(SettingsData.GetSample()["Editado"]);
            mock.Setup(x => x.DeleteSettingsById(It.IsAny<int>())).Returns(true);

            _repository = mock.Object;
        }
    }
}
