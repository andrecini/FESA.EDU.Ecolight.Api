using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Tests.Mocks.Data
{
    public static class HistoricData
    {
        public static Dictionary<string, Historic> GetSample()
        {
            var devices = new Dictionary<string, Historic>();

            devices.Add("Simples", new Historic
            {
                Id = 1,
                CompanyId = 1,
                DeviceId = 1,
                Date = DateTime.Now,
                Status = "Active",
                Description = "Ativação de Dispositivo"
            });

            devices.Add("Editado", new Historic
            {
                Id = 1,
                CompanyId = 1,
                DeviceId = 1,
                Date = DateTime.Now,
                Status = "Active",
                Description = "Ativação de Dispositivo"
            });

            return devices;

        }

        public static List<Historic> GetList(int amount)
        {
            var historics = new List<Historic>();

            for (int i = 1; i <= amount; i++)
            {
                historics.Add(new Historic
                {
                    Id = i,
                    CompanyId = 1,
                    DeviceId = 1,
                    Date = new DateTime(2023, 11, 27, 20 - i, 0, 0),
                    Status = i % 2 == 0 ? "1" : "0",
                    Description = i%2 == 0 ? "Ativação de Dispositivo" : "Desativação de Dispositivo"
                });;
            }

            return historics;
        }
    }
}
