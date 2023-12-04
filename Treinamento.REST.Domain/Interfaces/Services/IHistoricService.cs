using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Devices;

namespace Treinamento.REST.Domain.Interfaces.Services
{
    public interface IHistoricService
    {
        IEnumerable<Historic> GetHistoricsByCompanyId(int companyId);

        IEnumerable<Historic> GetHistorics();
    }
}
