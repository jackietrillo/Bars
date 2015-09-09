namespace Bars.Core.Providers
{
    public sealed class DbConnectionInformation
    {
        private readonly string _connectionStringName;
        public string ConnectionStringName { get { return _connectionStringName; } }

        private readonly string _providerInvariantName;
        public string ProviderInvariantName { get { return _providerInvariantName; } }

        private readonly string _connectionString;
        public string ConnectionString { get { return _connectionString; } }

        public DbConnectionInformation(string connectionStringName, string connectionString, string providerInvariantName)
        {
            _connectionStringName = connectionStringName;
            _connectionString = connectionString;
            _providerInvariantName = providerInvariantName;
        }
    }
}

