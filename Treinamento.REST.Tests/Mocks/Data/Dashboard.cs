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
    public static class DashboardData
    {
        public static Dictionary<string, Dashboard> GetSample()
        {
            var devices = new Dictionary<string, Dashboard>();

            devices.Add("Simples", new Dashboard
            {
                Total = 10,
                Inactive = 0,
                Active = 10,
                MonthlyDeviceExpenses = new List<float> { (float)0, (float)0, (float)0, (float)0, (float)0, (float)567.43 },
                MonthlyKwhUsage = new List<float> { (float)0, (float)0, (float)0, (float)0, (float)0, (float)766.8 }
            });

            return devices;
        }
    }
}
