using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinamento.REST.Domain.Entities.Devices;
using Treinamento.REST.Domain.Interfaces.Repositories;

namespace Treinamento.REST.Data.Repositories
{
    public class HistoricRepository : IHistoricRepository
    {
        private readonly IDbConnection _dbConnection;

        public HistoricRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IEnumerable<Historic> GetHistorics()
        {
            var sql = $@"Select 
                            Id as Id,
                            Historic_Date as Date,
                            Historic_Description as Description,
                            Historic_Status as Status,
                            Device_Id as DeviceId,
                            Company_Id as CompanyId
                         FROM Historic";

            var historics = _dbConnection.Query<Historic>(sql);

            return historics;
        }

        public IEnumerable<Historic> GetHistoricsByCompanyId(int companyId)
        {
            var sql = $@"SELECT 
                             Id as Id,
                             Historic_Date as Date,
                             Historic_Description as Description,
                             Historic_Status as Status,
                             Device_Id as DeviceId,
                             Company_Id as CompanyId 
                         FROM Historic
                         WHERE Company_Id = @companyId 
                         ORDER BY Historic_Date;";

            var historics = _dbConnection.Query<Historic>(sql, new { companyId = companyId });

            return historics;
        }
    }
}
