namespace Bars.Core.Providers
{
    public interface IConfigurationProvider
    {
        DbConnectionInformation GetDbConnectionInformation(string connectionStringName);
    }
}
