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
using static Dapper.SqlMapper;

namespace Treinamento.REST.Data.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
        private readonly IDbConnection _dbConnection;

        public SettingsRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Treinamento.REST.Domain.Entities.Devices.Settings AddSettings(SettingsInput settingsInput)
        {
            var sql = $@"INSERT INTO dbo.Users
                         (
                            Settings_Name,
                            Settings_Description,
                            OnDate,
                            OffDate,
                            Brightness,
                            Settings_Enable,
                            Device_Id
                         )
                         OUTPUT INSERTED.Id
                         VALUES
                         (
                            @Name,
                            @Description,
                            @OnDate,
                            @OffDate,
                            @Brightness,
                            @Enable,
                            @DeviceId
                         );";

            var newId = _dbConnection.QuerySingle<int>(sql, settingsInput);

            var newUser = GetSettingsById(newId);

            return newUser;
        }

        public int CountActiveSettings()
        {
            var sql = $@"SELECT COUNT(*)
                         FROM Settings 
                         WHERE Settings_Enable = 1;";

            var settigs = _dbConnection.QueryFirst<int>(sql);

            return settigs;
        }

        public int CountSettings()
        {
            var sql = $@"SELECT COUNT(*)
                         FROM Settings";

            var settigs = _dbConnection.QueryFirst<int>(sql);

            return settigs;
        }

        public int CountInactiveSettings()
        {
            var sql = $@"SELECT COUNT(*)
                         FROM Settings 
                         WHERE Settings_Enable = 1;";

            var settigs = _dbConnection.QueryFirst<int>(sql);

            return settigs;
        }

        public bool DeleteSettingsById(int settingsId)
        {
            var sql = "DELETE FROM dbo.Settings WHERE Id = @Id";

            var qtdLinhasAfetadas = _dbConnection.Execute(sql, new { Id = settingsId });

            return qtdLinhasAfetadas > 0;
        }


        public Treinamento.REST.Domain.Entities.Devices.Settings GetSettingsById(int id)
        {
            var sql = $@"SELECT
                            Id as Id,
                            Settings_Name as Name,
                            Settings_Description as Description,
                            OnDate as OnDate,
                            OffDate as EmpreOffDatesaId,
                            Brightness as Brightness,
                            Settings_Enable as Enable,
                            Device_Id as DeviceId
                         FROM Settings WHERE Id = @Id;";

            var settigs = _dbConnection.QueryFirstOrDefault<Treinamento.REST.Domain.Entities.Devices.Settings>(sql, new { Id = id });

            return settigs;
        }

        public IEnumerable<Treinamento.REST.Domain.Entities.Devices.Settings> GetSettings(int skip, int pageSize)
        {
            var sql = $@"SELECT
                            Settings_Name as Name,
                            Settings_Description as Description,
                            OnDate as OnDate,
                            OffDate as EmpreOffDatesaId,
                            Brightness as Brightness,
                            Settings_Enable as Enable,
                            Device_Id as DeviceId,
                         FROM Settings
            ";

            var settigs = _dbConnection.Query<Treinamento.REST.Domain.Entities.Devices.Settings>(sql, new { Skip = skip, PageSize = pageSize });

            return settigs;
        }


        public Treinamento.REST.Domain.Entities.Devices.Settings UpdateSettings(int settingsId, SettingsInput settingsInput)
        {
            var sql = $@"UPDATE dbo.Settings
                 SET
                    Settings_Name = @Name,
                    Settings_Description = @Description,
                    OnDate = @OnDate,
                    OffDate = @OffDate,
                    Brightness = @Brightness
                 OUTPUT INSERTED.Id
                 WHERE
                    Id = @Id;";

            var Id = _dbConnection.QuerySingle<int>(sql, settingsInput);

            return GetSettingsById(Id);
        }

        public Treinamento.REST.Domain.Entities.Devices.Settings UpdateSettingsStatus(int settingsId, SettingsStatus status)
        {
            var sql = $@"UPDATE dbo.Settings
                 SET
                    SETTINGS_ENABLE = @Enable
                 OUTPUT INSERTED.Id
                 WHERE
                    Id = @Id;";

            var Id = _dbConnection.QuerySingle<int>(sql, status);

            return GetSettingsById(Id);
        }
    }
}
