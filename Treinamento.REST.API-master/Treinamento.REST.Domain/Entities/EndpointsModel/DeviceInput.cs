using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Entities.EndpointsModel
{
    [DisplayName("Devices")]
    public class DeviceInput
    {
        public string DeviceName { get; set; }
        public string VerificationCode { get; set; }
        public int LampAmount { get; set; }
        public string LocalDescription { get; set; }
        public int EmpresaId { get; set; }
        public SettingsStatus Enable { get; set; }
        public float UsedHours { get; set; }
    }
}
