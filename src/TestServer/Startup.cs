using Owin;
using System.Web.Http;

namespace TestServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            _ = config.Routes.MapHttpRoute(
                name: "TestSrvApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            _ = appBuilder.UseWebApi(config);
        }
    }
}
