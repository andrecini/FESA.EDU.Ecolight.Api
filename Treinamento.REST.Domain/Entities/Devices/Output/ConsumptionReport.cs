using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.REST.Domain.Entities.Devices.Output
{
    public class ConsumptionReport
    {
        // Historico e Dispositivos
        public TimeSpan UsedHours { get; set; }
        public float DailySavingsKwh { get; set; }
        public float DailySavingsRs { get; set; }
        public float MonthlySavingsKwh { get; set; }
        public float MonthlySavingsRs { get; set; }
        public List<Device> CriticalDevices { get; set; }
        public float CarbonEmission { get; set; }
    }
}
