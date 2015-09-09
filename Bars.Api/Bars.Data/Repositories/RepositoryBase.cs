using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

using Bars.Core.Providers;

namespace Bars.Data.Repositories
{
    public class RepositoryBase
    {
        public delegate SqlCommand CommandFactory<TCommandParameter>(SqlConnection sqlConnection, TCommandParameter commandParameter);
        public delegate SqlCommand CommandFactory<TCommandParameter1, TCommandParameter2>(SqlConnection sqlConnection, TCommandParameter1 commandParameter, TCommandParameter2 commandParameter2);
        public delegate SqlCommand CommandFactory(SqlConnection sqlConnection);

        public delegate TResult ModelAdapterForSingle<TResult>(IDataRecord dataRecord);        
        public delegate IEnumerable<TResult> ModelAdapterForSequence<TResult>(DbDataReader dbDataReader);

        private static string CONNECTION_STRING_NAME = "Bars";

        private readonly IConfigurationProvider _configurationProvider;

        public RepositoryBase(IConfigurationProvider configurationProvider)
        {         
            _configurationProvider = configurationProvider;
        }

        protected SqlConnection _sqlConnection;
        protected SqlConnection GetDbConnection()
        {
            if (_sqlConnection == null)
            {
                var connectionInformation = _configurationProvider.GetDbConnectionInformation(CONNECTION_STRING_NAME);
                _sqlConnection = (SqlConnection)DbProviderFactories.GetFactory(connectionInformation.ProviderInvariantName).CreateConnection();
                _sqlConnection.ConnectionString = connectionInformation.ConnectionString;
            }

            return _sqlConnection;
        }

        protected static void ExecuteNonQueryUsingTransaction(SqlConnection sqlConnection, SqlCommand sqlCommand)
        {
            sqlConnection.Open();
            SqlTransaction transaction = null;
            try
            {
                transaction = sqlConnection.BeginTransaction();
                sqlCommand.Transaction = transaction;
                sqlCommand.ExecuteNonQuery();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                sqlCommand.Dispose();
                transaction.Dispose();
                sqlConnection.Close();
            }
        }

        protected static void ExecuteNonQueryUsingTransaction<TCommandParameter>(SqlConnection sqlConnection, CommandFactory<TCommandParameter> commandFactory, TCommandParameter commandParameter)
        {
            ExecuteNonQueryUsingTransaction(sqlConnection, commandFactory(sqlConnection, commandParameter));
        }

        protected static void ExecuteNonQueryUsingTransaction<TCommandParameter1, TCommandParameter2>(SqlConnection sqlConnection, CommandFactory<TCommandParameter1, TCommandParameter2> commandFactory, TCommandParameter1 commandParameter1, TCommandParameter2 commandParameter2)
        {
            ExecuteNonQueryUsingTransaction(sqlConnection, commandFactory(sqlConnection, commandParameter1, commandParameter2));
        }

        protected static IEnumerable<TResult> ExecuteReaderForSequence<TCommandParameter, TResult>(SqlConnection sqlConnection, CommandFactory<TCommandParameter> commandFactory, TCommandParameter commandParameter, ModelAdapterForSequence<TResult> modelAdapter)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlCommand = commandFactory(sqlConnection, commandParameter);
                sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader.HasRows ? modelAdapter(sqlDataReader) : Enumerable.Empty<TResult>();
            }
            finally
            {
                sqlDataReader.Dispose();
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
        }

        protected static IEnumerable<TResult> ExecuteReaderForSequence<TResult>(SqlConnection sqlConnection, CommandFactory commandFactory, ModelAdapterForSequence<TResult> modelAdapter)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;
            try
            {
                sqlCommand = commandFactory(sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();
                return sqlDataReader.HasRows ? modelAdapter(sqlDataReader) : Enumerable.Empty<TResult>();
            }
            finally
            {
                sqlDataReader.Dispose();
                sqlCommand.Dispose();
                sqlConnection.Close();
            }
        }

        protected static TResult ExecuteReadeForSingle<TCommandParameter, TResult>(SqlConnection sqlConnection, CommandFactory<TCommandParameter> commandFactory, TCommandParameter commandParameter, ModelAdapterForSingle<TResult> modelAdapter)
        {
            sqlConnection.Open();
            SqlTransaction transaction = null;
            SqlCommand sqlCommand = null;
            SqlDataReader sqlDataReader = null;

            try
            {
                transaction = sqlConnection.BeginTransaction();
                sqlCommand = commandFactory(sqlConnection, commandParameter);
                sqlCommand.Transaction = transaction;

                sqlDataReader = sqlCommand.ExecuteReader();
                TResult result = sqlDataReader.Read() ? modelAdapter(sqlDataReader) : default(TResult);

                sqlDataReader.Close();
                transaction.Commit();
                return result;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                sqlDataReader.Dispose();
                sqlCommand.Dispose();
                transaction.Dispose();
                sqlConnection.Close();
            }
        }
    }
}
