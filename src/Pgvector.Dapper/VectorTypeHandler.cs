using Dapper;
using Pgvector;
using System.Data;
using System.Data.SqlClient;

namespace Pgvector.Dapper;

public class VectorTypeHandler : SqlMapper.TypeHandler<Vector>
{
    public override Vector? Parse(object value)
    {
        if (value == null || value is DBNull)
        {
            return null;
        }
        else if (value is Vector vec)
        {
            return vec;
        }
        else
        {
            var s = value.ToString();
            return s != null ? new Vector(s) : null;
        }
    }

    public override void SetValue(IDbDataParameter parameter, Vector value)
    {
        parameter.Value = value == null ? DBNull.Value : value;

        if (parameter is SqlParameter sqlParameter)
        {
            sqlParameter.UdtTypeName = "vector";
        }
    }
}
