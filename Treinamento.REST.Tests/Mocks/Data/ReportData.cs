using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.Devices.Output;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Tests.Mocks.Data
{
    public static class ReportData
    {
        public static Dictionary<string, DeviceReport> GetSample()
        {
            var devices = new Dictionary<string, DeviceReport>();

            devices.Add("Simples", new DeviceReport
            {
                AllDevices = DeviceData.GetList(10),
                CarbonEmission = (float)159.75,
                CriticalDevices = DeviceData.GetList(1),
                DevicesExpenses = (float)567.432007,
                MonthlyDevicesExpenseSavings = new List<float> { (float)17582.4, (float)17582.4, (float)17582.4, (float)17582.4, (float)17582.4, (float)17014.97 },
                MonthlyKwhSavings = new List<float> { (float)23760, (float)23760, (float)23760, (float)23760, (float)23760, (float)22993.2 }
            });

            return devices;
        }
    }
}
