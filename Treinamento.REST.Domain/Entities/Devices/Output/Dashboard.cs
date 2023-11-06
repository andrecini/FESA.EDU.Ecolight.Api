using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.REST.Domain.Entities.Devices.Output
{
    public class Dashboard
    {
        public int Active { get; set; }
        public int Inactive { get; set; }
        public int Total { get; set; }
        public IEnumerable<float> MonthlyKwhUsage { get; set; }
        public IEnumerable<float> MonthlyDeviceExpenses { get; set; }
    }
}
