using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Entities.Devices.Output
{
    public class DeviceReport
    {
        public float CarbonEmission { get; set; }
        public float DevicesExpenses { get; set; }
        public IEnumerable<Device> CriticalDevices { get; set; }
        public IEnumerable<Device> AllDevices { get; set; }
        public IEnumerable<float> MonthlyKwhSavings { get; set; }
        public IEnumerable<float> MonthlyDevicesExpenseSavings { get; set; }
    }
}
