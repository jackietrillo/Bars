using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace Bars.DependencyResolution
{
    public class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
             Scan(
                 scan =>
                 {
                     scan.Assembly("Bars.Core");
                     scan.Assembly("Bars.Services");					
                     scan.TheCallingAssembly();
                     scan.WithDefaultConventions();                    
                 });                       
        }
    }
}