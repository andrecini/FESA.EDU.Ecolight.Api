using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Interfaces.Repositories;
using Treinamento.REST.Domain.Interfaces.Services;

namespace Treinamento.REST.Services.Services
{
    public class HistoricService : IHistoricService
    {
        private readonly IHistoricRepository _historicRepository;

        public HistoricService(IHistoricRepository historicRepository)
        {
            _historicRepository = historicRepository;
        }

        public IEnumerable<Historic> GetHistorics()
        {
            return _historicRepository.GetHistorics();
        }

        public IEnumerable<Historic> GetHistoricsByCompanyId(int companyId)
        {
            var historics = _historicRepository.GetHistoricsByCompanyId(companyId);

            return historics;
        }
    }
}
