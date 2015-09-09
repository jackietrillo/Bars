using System;
using System.Collections.Generic;
using System.Data.SqlClient;

using Bars.Data.CommandFactories;
using Bars.Core.DomainModels;
using Bars.Core.Providers;

namespace Bars.Data.Repositories
{
    public class BarRepository : RepositoryBase, IBarRepository
    {
        private readonly SqlConnection sqlConnection;
        public BarRepository(IConfigurationProvider configurationProvider) : base(configurationProvider)
        {
            sqlConnection = GetDbConnection();
        }

        public IEnumerable<Bar> GetBars()
        {
            return ExecuteReaderForSequence(sqlConnection, DbCommandFactories.CreateCommandForGetBars, BarsDataReaderToModelAdapter.CreateBarSequenceInstance);
        }

        public Bar GetBar(string name)
        {
            return ExecuteReadeForSingle(sqlConnection, DbCommandFactories.CreateCommandForGetBar, name, BarsDataReaderToModelAdapter.CreateBarInstance);
        }

        public void AddBar(string name)
        {
            ExecuteNonQueryUsingTransaction(sqlConnection, DbCommandFactories.CreateCommandForCreateBar, name);
        }

        public void UpdateBar(string name, string urlSafeName)
        {
            ExecuteNonQueryUsingTransaction(sqlConnection, DbCommandFactories.CreateCommandForUpdateBar, name, urlSafeName);
        }

        public void DeleteBar(string name)
        {
            ExecuteNonQueryUsingTransaction(sqlConnection, DbCommandFactories.CreateCommandForDeleteBar, name);
        }

        public void UpdateBar(string name)
        {
            throw new NotImplementedException();
        }
    }
}
