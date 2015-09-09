using System.Configuration;

namespace Bars.Core.Providers
{
    public class ConfigurationProvider : IConfigurationProvider
    {     
        public DbConnectionInformation GetDbConnectionInformation(string connectionStringName)
        {
            var connectionStringSetting = ConfigurationManager.ConnectionStrings[connectionStringName];
            if (connectionStringSetting == null)
                throw new ConfigurationErrorsException("No ConnectionString setting with the name: \"" + connectionStringName + "\" was found.");
        
            return new DbConnectionInformation(connectionStringName, connectionStringSetting.ConnectionString, connectionStringSetting.ProviderName);
        }
    }
}
