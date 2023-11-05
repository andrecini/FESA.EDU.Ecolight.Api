using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.EndpointsModel;

namespace Treinamento.REST.Domain.Entities.Devices
{
    public class Settings
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeOnly OnDate { get; set; }
        public TimeOnly OffDate { get; set; }
        public int Brightness { get; set; }
        public bool Enable { get; set; }
        public int DeviceId { get; set; }

        public static Settings Map(SettingsInput settings)
        {
            return new Settings()
            {
                Name = settings.Name,
                Description = settings.Description,
                OnDate = settings.OnDate,
                OffDate = settings.OffDate,
                Brightness = settings.Brightness,
                Enable = settings.Enable,
                DeviceId = settings.DeviceId,
            };
        }

        public static Settings Map(int id, SettingsInput settings)
        {
            return new Settings()
            {
                Id = id,
                Name = settings.Name,
                Description = settings.Description,
                OnDate = settings.OnDate,
                OffDate = settings.OffDate,
                Brightness = settings.Brightness,
                Enable = settings.Enable,
                DeviceId = settings.DeviceId,
            };
        }
    }
}
