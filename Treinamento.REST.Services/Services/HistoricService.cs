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

        public IEnumerable<Historic> GetLastMonthHistoricsByCompanyId(int companyId)
        {
            var historics = _historicRepository.GetHistoricsByCompanyId(companyId);
            Dictionary<int, float> usedDeviceHours = new Dictionary<int, float>();
            foreach (var historic in historics)
            {
                if (historic.Date.Month == DateTime.Now.Month + 1)
                    if (!usedDeviceHours.ContainsKey(historic.Id))
                        usedDeviceHours.Add(historic.Id, 0);
            }

            foreach (int key in usedDeviceHours.Keys)
            {
                DateTime hoje = DateTime.Now;
                DateTime dataInicio = new DateTime(hoje.Year, hoje.Month, 1, 0, 0, 0);
                foreach(var historic in historics)
                {
                    if (historic.DeviceId == key)
                    {
                        if (historic.Status == "0")
                        {
                            var tempo = historic.Date - dataInicio;
                            usedDeviceHours[key] += (float)tempo.TotalSeconds/3600;
                        }
                        else if (historic.Status == "1")
                        {
                            dataInicio = historic.Date;
                        }
                    }
                }
            }

            return null;
        }
    }
}
