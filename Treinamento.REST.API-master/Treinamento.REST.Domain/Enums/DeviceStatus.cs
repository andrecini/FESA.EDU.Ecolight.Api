using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.REST.Domain.Enums
{
    public enum DeviceStatus
    {
        [EnumMember(Value = "Inactive")]
        Inactive = 0,
        [EnumMember(Value = "Active")]
        Active = 1
    }
}
