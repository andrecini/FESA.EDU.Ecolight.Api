using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;

namespace Treinamento.REST.Domain.Entities.Devices
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string VerificationCode { get; set; }
        public int LampAmount { get; set; }
        public string LocalDescription { get; set; }
        public int EmpresaId { get; set; }
        public DeviceStatus Enable{ get; set; }
        public float UsedHours { get; set; }

        public static Device Map(DeviceInput device)
        {
            return new Device()
            {
                DeviceName = device.DeviceName,
                VerificationCode = device.VerificationCode,
                LampAmount = device.LampAmount,
                LocalDescription = device.LocalDescription,
                EmpresaId = device.EmpresaId,
                Enable = device.Enable,
                UsedHours = device.UsedHours,
            };
        }

        public static Device Map(int id, DeviceInput device)
        {
            return new Device()
            {
                Id = id,
                DeviceName = device.DeviceName,
                VerificationCode = device.VerificationCode,
                LampAmount = device.LampAmount,
                LocalDescription = device.LocalDescription,
                EmpresaId = device.EmpresaId,
                Enable = device.Enable,
                UsedHours = device.UsedHours,
            };
        }
    }
}
