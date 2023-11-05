using Dapper;
using System.Data;
using Treinamento.REST.Domain.Entities.EndpointsModel;
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

        public Domain.Entities.Devices.Settings AddSettings(SettingsInput settingsInput)
        {
            var sql = $@"INSERT INTO Settings
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
            var sql = "DELETE FROM Settings WHERE Id = @Id";

            var qtdLinhasAfetadas = _dbConnection.Execute(sql, new { Id = settingsId });

            return qtdLinhasAfetadas > 0;
        }

        public Domain.Entities.Devices.Settings GetSettingsById(int id)
        {
            var sql = $@"SELECT
                            Id as Id,
                            Settings_Name as Name,
                            Settings_Description as Description,
                            OnDate as OnDate,
                            OffDate as OffDate,
                            Brightness as Brightness,
                            Settings_Enable as Enable,
                            Device_Id as DeviceId
                         FROM Settings WHERE Id = @Id;";

            var settigs = _dbConnection.QueryFirstOrDefault<Domain.Entities.Devices.Settings>(sql, new { Id = id });

            return settigs;
        }

        public IEnumerable<Domain.Entities.Devices.Settings> GetSettings(int skip, int pageSize)
        {
            var sql = $@"SELECT
                            Id as Id,
                            Settings_Name as Name,
                            Settings_Description as Description,
                            OnDate as OnDate,
                            OffDate as OffDate,
                            Brightness as Brightness,
                            Settings_Enable as Enable,
                            Device_Id as DeviceId
                         FROM Settings
            ";

            var settigs = _dbConnection.Query<Domain.Entities.Devices.Settings>(sql, new { Skip = skip, PageSize = pageSize });

            return settigs;
        }

        public Domain.Entities.Devices.Settings UpdateSettings(Domain.Entities.Devices.Settings settings)
        {
            var sql = $@"UPDATE Settings
                 SET
                    Settings_Name = @Name,
                    Settings_Description = @Description,
                    OnDate = @OnDate,
                    OffDate = @OffDate,
                    Brightness = @Brightness
                 OUTPUT INSERTED.Id
                 WHERE
                    Id = @Id;";

            var Id = _dbConnection.QuerySingle<int>(sql, settings);

            return GetSettingsById(Id);
        }

        public Domain.Entities.Devices.Settings UpdateSettingsStatus(int settingsId, SettingsStatus status)
        {
            var sql = $@"UPDATE Settings
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
