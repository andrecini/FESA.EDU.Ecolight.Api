using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Services.Services;
using Treinamento.REST.Tests.Mocks.Data;
using Treinamento.REST.Tests.Mocks.Repository;

namespace Treinamento.REST.Tests
{
    public class HistoricServiceTest
    {
        [Fact]
        public void GetHistorics()
        {
            var service = new HistoricService(HistoricRepositoryMock.Get());

            var historicos = service.GetHistorics();

            Assert.Equivalent(HistoricData.GetList(20), historicos);
        }
        
        [Fact]
        public void GetHistoricsByCompanyId()
        {
            var service = new HistoricService(HistoricRepositoryMock.Get());

            var historicos = service.GetHistoricsByCompanyId(1);

            Assert.Equivalent(HistoricData.GetList(10), historicos);
        }
    }
}
