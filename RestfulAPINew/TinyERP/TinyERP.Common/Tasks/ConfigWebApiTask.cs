using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace TinyERP.Common.Tasks
{
    internal class ConfigWebApiTask : IConfigWebApiTask
    {
        public void Execute(object arg = null)
        {
            HttpConfiguration config = arg as HttpConfiguration;
            if (config == null) { return; }
            //config.EnsureInitialized();
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
