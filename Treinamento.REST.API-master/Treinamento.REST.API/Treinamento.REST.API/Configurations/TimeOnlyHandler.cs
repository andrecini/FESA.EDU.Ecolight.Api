using Dapper;
using System.Data;

namespace Treinamento.REST.API.Configurations
{
    public class TimeOnlyHandler : SqlMapper.TypeHandler<TimeOnly>
    {
        public override TimeOnly Parse(object value)
        {
            return TimeOnly.FromTimeSpan((TimeSpan)value);
        }

        public override void SetValue(IDbDataParameter parameter, TimeOnly value)
        {
            parameter.Value = value.ToTimeSpan();
        }
    }
}
