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
        public Device Device { get; set; }
        public TimeSpan UsedHours { get; set; }
        public DeviceStatus Status { get; set; }
        public float CarbonEmission { get; set; }
        public float DailyKwhUsage { get; set; }
        public float MonthlyKwhUsage { get; set; }
    }
}
