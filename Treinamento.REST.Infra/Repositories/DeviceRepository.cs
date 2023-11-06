using Dapper;
using System.Data;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Entities.EndpointsModel;
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
            var sql = $@"INSERT INTO Device
                         (
                            Device_Name,
                            Verification_Code,
                            Lamp_Amount,
                            Local_Description,
                            Status_Enable,
                            Company_Id
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
                         FROM Device 
                         WHERE Status_Enable = 1;";

            var device = _dbConnection.QueryFirst<int>(sql);

            return device;
        }

        public int CountDevices(int companyId)
        {
            var sql = $@"SELECT COUNT(*)
                         FROM Device
                         WHERE Company_Id = @companyId";

            var device = _dbConnection.QueryFirst<int>(sql, new {companyId = companyId});

            return device;
        }

        public int CountInactiveDevices()
        {
            var sql = $@"SELECT COUNT(*)
                         FROM Device 
                         WHERE Status_Enable = 1;";

            var device = _dbConnection.QueryFirst<int>(sql);

            return device;
        }

        public bool DeleteDeviceById(int deviceId)
        {
            var sql = "DELETE FROM Device WHERE Id = @Id";

            var qtdLinhasAfetadas = _dbConnection.Execute(sql, new { Id = deviceId });

            return qtdLinhasAfetadas > 0;
        }


        public Device GetDeviceById(int id)
        {
            var sql = $@"SELECT
                            Id as Id,
                            Device_Name as DeviceName,
                            Verification_Code as VerificationCode,
                            Lamp_Amount as LampAmount,
                            Local_Description as LocalDescription,
                            Status_Enable as Enable,
                            Company_Id as EmpresaId
                         FROM Device WHERE Id = @Id;";

            var devices = _dbConnection.QueryFirstOrDefault<Device>(sql, new { Id = id });

            return devices;
        }

        public IEnumerable<Device> GetDevices(int companyId)
        {
            var sql = $@"SELECT
                            Id as Id,
                            Device_Name as DeviceName,
                            Verification_Code as VerificationCode,
                            Lamp_Amount as LampAmount,
                            Local_Description as LocalDescription,
                            Status_Enable as Enable,
                            Company_Id as EmpresaId
                         FROM Device
                         WHERE Company_Id = @companyId";

            var devices = _dbConnection.Query<Device>(sql, new { companyId = companyId });

            return devices;
        }

        public Device UpdateDevice(Device device)
        {
            var sql = $@"UPDATE Device
                 SET
                    Device_Name = @DeviceName,
                    Verification_Code = @VerificationCode,
                    Local_Description = @LocalDescription,
                    Lamp_Amount = @LampAmount,
                    Status_Enable = @Enable,
                    Company_Id = @EmpresaId
                 OUTPUT INSERTED.Id
                 WHERE
                    Id = @Id;";

            var Id = _dbConnection.QuerySingle<int>(sql, device);

            return GetDeviceById(Id);
        }

        public Device UpdateDeviceStatus(int deviceId, SettingsStatus status)
        {
            var sql = $@"UPDATE Device
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
