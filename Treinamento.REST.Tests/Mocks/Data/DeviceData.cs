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
    public static class DeviceData
    {
        public static Dictionary<string, Device> GetSample()
        {
            var devices = new Dictionary<string, Device>();

            devices.Add("Simples", new Device
            {
                Id = 1,
                EmpresaId = 1,
                DeviceName = "Dispositivo Teste",
                VerificationCode = "123456",
                LampAmount = 20,
                LocalDescription = "Interruptor da Sala 01",
                Enable = SettingsStatus.Active,
                UsedKWH = (float)766.8
            });

            devices.Add("Editado", new Device
            {
                Id = 1,
                EmpresaId = 1,
                DeviceName = "Dispositivo Teste - Editado",
                VerificationCode = "123456",
                LampAmount = 30,
                LocalDescription = "Interruptor da Sala 01",
                Enable = SettingsStatus.Active,
                UsedKWH = (float)766.8
            });

            return devices;

        }

        public static Dictionary<string, DeviceInput> GetDeviceInput()
        {
            var devices = new Dictionary<string, DeviceInput>();

            devices.Add("Simples", new DeviceInput
            {
                EmpresaId = 1,
                DeviceName = "Dispositivo Teste",
                VerificationCode = "123456",
                LampAmount = 20,
                LocalDescription = "Interruptor da Sala 01",
                Enable = SettingsStatus.Active,
            });

            return devices;
        }

        public static List<Device> GetList(int amount)
        {
            var devices = new List<Device>();

            for (int i = 1; i <= amount; i++)
            {
                devices.Add(new Device
                {
                    Id = i,
                    EmpresaId = 1,
                    DeviceName = $"Dispositivo Teste - {i}",
                    VerificationCode = "123456",
                    LampAmount = i * 10,
                    LocalDescription = $"Interruptor da Sala {i}",
                    Enable = SettingsStatus.Active,
                    UsedKWH = (float)766.8
                });
            }

            return devices;
        }
    }
}
