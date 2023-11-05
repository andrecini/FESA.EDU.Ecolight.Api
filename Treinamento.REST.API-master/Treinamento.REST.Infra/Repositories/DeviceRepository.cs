using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
using Treinamento.REST.Domain.Entities.Users;
using Treinamento.REST.Domain.Enums;
using Treinamento.REST.Domain.Interfaces.Repositories;

namespace Treinamento.REST.Data.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IDbConnection _dbConnection;

        public DeviceRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Device AddDevice(DeviceInput deviceInput)
        {
            var sql = $@"INSERT INTO dbo.Users
                         (
                            Device_Name,
                            Verification_Code,
                            Lamp_Amount,
                            LOCAL_DESCRIPTION,
                            STATUS_ENABLE,
                            EMPRESA_ID
                         )
                         OUTPUT INSERTED.Id
                         VALUES
                         (
                            @DeviceName,
                            @VerificationCode,
                            @LampAmount,
                            @LocalDescription,
                            @Enable,
                            @EmpresaId
                         );";

            var newId = _dbConnection.QuerySingle<int>(sql, deviceInput);

            var newUser = GetDeviceById(newId);

            return newUser;
        }

        public int CountActiveDevices()
        {
            var sql = $@"SELECT COUNT(*)
                         FROM Devices 
                         WHERE Status_Enable = 1;";

            var device = _dbConnection.QueryFirst<int>(sql);

            return device;
        }

        public int CountDevices()
        {
            var sql = $@"SELECT COUNT(*)
                         FROM Devices";

            var device = _dbConnection.QueryFirst<int>(sql);

            return device;
        }

        public int CountInactiveDevices()
        {
            var sql = $@"SELECT COUNT(*)
                         FROM Devices 
                         WHERE Status_Enable = 1;";

            var device = _dbConnection.QueryFirst<int>(sql);

            return device;
        }

        public bool DeleteDeviceById(int deviceId)
        {
            var sql = "DELETE FROM dbo.Devices WHERE Id = @Id";

            var qtdLinhasAfetadas = _dbConnection.Execute(sql, new { Id = deviceId });

            return qtdLinhasAfetadas > 0;
        }


        public Device GetDeviceById(int id)
        {
            var sql = $@"SELECT *
                         FROM Devices WHERE Id = @Id;";

            var devices = _dbConnection.QueryFirstOrDefault<Device>(sql, new { Id = id });

            return devices;
        }

        public IEnumerable<Device> GetDevices(int skip, int pageSize)
        {
            var sql = $@"SELECT * FROM Devices";

            var devices = _dbConnection.Query<Device>(sql, new { Skip = skip, PageSize = pageSize });

            return devices;
        }


        public Device UpdateDevice(int deviceId, DeviceInput deviceInput)
        {
            var sql = $@"UPDATE dbo.Devices
                 SET
                    Local_Description = @LocalDescription,
                    Lamp_Amount = @LampAmount,
                    Used_Hours = @UsedHours
                 OUTPUT INSERTED.Id
                 WHERE
                    Id = @Id;";

            var Id = _dbConnection.QuerySingle<int>(sql, deviceInput);

            return GetDeviceById(Id);
        }

        public Device UpdateDeviceStatus(int deviceId, DeviceStatus status)
        {
            var sql = $@"UPDATE dbo.Devices
                 SET
                    STATUS_ENABLE = @Enable
                 OUTPUT INSERTED.Id
                 WHERE
                    Id = @Id;";

            var Id = _dbConnection.QuerySingle<int>(sql, status);

            return GetDeviceById(Id);
        }
    }
}
