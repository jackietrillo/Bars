using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Bars.Data.Extensions
{
    public static class DbCommandExtensions
    {
        private static DbParameter InitializeCommandParameter(SqlCommand sqlCommand, SqlDbType sqlDbType, ParameterDirection parameterDirection, string parameterName, object value)
        {
            var dbParameter = sqlCommand.CreateParameter();
            dbParameter.SqlDbType = sqlDbType;
            dbParameter.Direction = parameterDirection;
            dbParameter.ParameterName = parameterName;
            dbParameter.Value = value;
            return dbParameter;
        }

        public static void AddReturnParameter(this DbCommand dbCommand)
        {
            var dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.Int32;
            dbParameter.Direction = ParameterDirection.ReturnValue;
            dbParameter.ParameterName = "@Return";
            dbCommand.Parameters.Add(dbParameter);
        }

        public static void AddParameter(this SqlCommand sqlDbCommand, SqlDbType sqlDbType, string parameterName, object value)
        {
            var sqlDbParameter = InitializeCommandParameter(sqlDbCommand, sqlDbType, ParameterDirection.Input, parameterName, value);
            sqlDbCommand.Parameters.Add(sqlDbParameter);
        }

        public static void AddParameter(this SqlCommand sqlDbCommand, SqlDbType sqlDbType, string parameterName, object value, int size)
        {
            var sqlDbParameter = InitializeCommandParameter(sqlDbCommand, sqlDbType, ParameterDirection.Input, parameterName, value);
            sqlDbParameter.Size = size;
            sqlDbCommand.Parameters.Add(sqlDbParameter);
        }
    }
}
