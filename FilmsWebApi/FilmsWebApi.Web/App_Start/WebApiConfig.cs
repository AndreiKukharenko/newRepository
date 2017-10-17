using System.Web.Http;
using Microsoft.Owin.Security.OAuth;

namespace FilmsWebApi.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //var cors = new EnableCorsAttribute("localhost:16629", "*", "*"); //can be useful
            config.EnableCors();

            //supress other authentication, prevents CSRF
            config.SuppressDefaultHostAuthentication();
            //adds token authentication
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
        }
    }
}
