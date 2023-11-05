using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Treinamento.REST.Domain.Entities.Devices
{
    public class Historic
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public int DeviceId { get; set; }
    }
}
