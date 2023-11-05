using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.REST.Domain.Entities.EndpointsModel
{
    [DisplayName("Settings")]
    public class SettingsInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime OnDate { get; set; }
        public DateTime OffDate { get; set; }
        public int Brightness { get; set; }
        public bool Enable { get; set; }
        public int DeviceId { get; set; }
    }
}
