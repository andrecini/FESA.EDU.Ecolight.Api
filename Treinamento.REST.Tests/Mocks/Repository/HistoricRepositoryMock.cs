using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Data.Repositories;
using Treinamento.REST.Domain.Interfaces.Repositories;
using Treinamento.REST.Tests.Mocks.Data;

namespace Treinamento.REST.Tests.Mocks.Repository
{
    public static class HistoricRepositoryMock
    {
        private static IHistoricRepository _repository;

        public static IHistoricRepository Get()
        {
            if (_repository == null) CreateInstance();

            return _repository;
        }

        private static void CreateInstance()
        {
            var mock = new Mock<IHistoricRepository>();

            mock.Setup(x => x.GetHistoricsByCompanyId(It.IsAny<int>())).Returns(HistoricData.GetList(10));
            mock.Setup(x => x.GetHistorics()).Returns(HistoricData.GetList(20));

            _repository = mock.Object;
        }
    }
}
