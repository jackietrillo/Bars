using Bars.Core.Logging;

namespace Bars.Services
{
    internal class ServiceBase
    {
        protected ServiceBase()
        {
            Log = new Logger(GetType().FullName);
        }

        protected Logger Log { get; private set; }
    }

}
