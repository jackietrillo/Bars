using System.Data;
using System.Data.SqlClient;

using Bars.Data.Extensions;

namespace Bars.Data.CommandFactories
{
    public class DbCommandFactories
    {     
        public static SqlCommand CreateCommandForCreateBar(SqlConnection sqlConnection, string name)
        {
            var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "CreateBar";
            sqlCommand.AddReturnParameter();
            sqlCommand.AddParameter(SqlDbType.NVarChar, "@Name", name, 100);
            return sqlCommand;
        }
   
        public static SqlCommand CreateCommandForGetBar(SqlConnection sqlConnection, string name)
        {
            var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetBar";
            sqlCommand.AddReturnParameter();
            sqlCommand.AddParameter(SqlDbType.NVarChar, "@Name", name, 100);
            return sqlCommand;
        }

        public static SqlCommand CreateCommandForGetBars(SqlConnection sqlConnection)
        {
            var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "GetBars";
            return sqlCommand;
        }

        public static SqlCommand CreateCommandForDeleteBar(SqlConnection sqlConnection, string name)
        {
            var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "DeleteArtist";
            sqlCommand.AddParameter(SqlDbType.NVarChar, "@Name", name, 100);    
            return sqlCommand;
        }

        public static SqlCommand CreateCommandForUpdateBar(SqlConnection sqlConnection, string name, string urlSafeName)
        {
            var sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = "UpdateBar";
            sqlCommand.AddReturnParameter();
            sqlCommand.AddParameter(SqlDbType.NVarChar, "@Name", name, 100);
            sqlCommand.AddParameter(SqlDbType.NVarChar, "@UrlSafeName", urlSafeName, 100);
            return sqlCommand;
        }
    }
}
