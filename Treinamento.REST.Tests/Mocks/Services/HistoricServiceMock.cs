using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Data.Repositories;
using Treinamento.REST.Domain.Interfaces.Repositories;
using Treinamento.REST.Domain.Interfaces.Services;
using Treinamento.REST.Tests.Mocks.Data;

namespace Treinamento.REST.Tests.Mocks.Services
{
    public static class HistoricServiceMock
    {
        private static IHistoricService _service;

        public static IHistoricService Get()
        {
            if (_service == null) CreateInstance();

            return _service;
        }

        private static void CreateInstance()
        {
            var mock = new Mock<IHistoricService>();

            mock.Setup(x => x.GetHistoricsByCompanyId(It.IsAny<int>())).Returns(HistoricData.GetList(10));
            mock.Setup(x => x.GetHistorics()).Returns(HistoricData.GetList(20));

            _service = mock.Object;
        }
    }
}
