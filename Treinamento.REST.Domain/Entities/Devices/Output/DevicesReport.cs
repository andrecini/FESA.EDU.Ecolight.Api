using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.REST.Domain.Entities.Devices.Output
{
    public class DevicesReport
    {
        public int QtdLamp { get; set; }
        public int QtdDevices { get; set; }
        public List<Device> Devices { get; set;}
        public List<Settings> Settings { get; set; }
    }
}
