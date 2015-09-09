using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Http;

namespace Bars.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
              name: "Bars API",
              routeTemplate: "api/{controller}/{action}/{name}",
              defaults: new { controller = "bars", action = "get", name = RouteParameter.Optional }
          );       
        }
    }
}