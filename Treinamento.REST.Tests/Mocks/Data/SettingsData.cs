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
    public static class SettingsData
    {
        public static Dictionary<string, Settings> GetSample()
        {
            var devices = new Dictionary<string, Settings>();

            devices.Add("Simples", new Settings
            {
                Id = 1,
                Brightness = 50,
                Description = "Automação Teste",
                DeviceId = 1,
                OnDate = new TimeOnly(10, 00),
                OffDate = new TimeOnly(22, 00),
                Enable = true,
                Name = "Automação 1"
            });
            
            devices.Add("Editado", new Settings
            {
                Id = 1,
                Brightness = 50,
                Description = "Automação Teste - Editado",
                DeviceId = 1,
                OnDate = new TimeOnly(10, 00),
                OffDate = new TimeOnly(22, 00),
                Enable = true,
                Name = "Automação 1"
            });

            return devices;

        }

        public static Dictionary<string, SettingsInput> GetDeviceInput()
        {
            var devices = new Dictionary<string, SettingsInput>();

            devices.Add("Simples", new SettingsInput
            {
                Brightness = 50,
                Description = "Automação Teste",
                DeviceId = 1,
                OnDate = new TimeOnly(10, 00),
                OffDate = new TimeOnly(22, 00),
                Enable = true,
                Name = "Automação 1"
            });

            return devices;
        }

        public static List<Settings> GetList(int amount)
        {
            var devices = new List<Settings>();

            for (int i = 1; i <= amount; i++)
            {
                devices.Add(new Settings
                {
                    Id = i,
                    Brightness = 50,
                    Description = "Automação Teste",
                    DeviceId = i,
                    OnDate = new TimeOnly(10, 00),
                    OffDate = new TimeOnly(22, 00),
                    Enable = i%2 == 0 ? true : false,
                    Name = $"Automação {i}"
                });
            }

            return devices;
        }
    }
}
