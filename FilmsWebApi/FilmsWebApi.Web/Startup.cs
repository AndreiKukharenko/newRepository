using System;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using FilmsWebApi.Web.App_Start;
using Autofac.Integration.WebApi;

[assembly:OwinStartup(typeof(FilmsWebApi.Web.Startup))]

namespace FilmsWebApi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            ConfigureAuth(app);
            app.UseWebApi(config);
            WebApiConfig.Register(config);
            DependenciesConfig.RegisterDependencies(config);

            // the Autofac middleware itself will be added to the pipeline, after which 
            //any Microsoft.Owin.OwinMiddleware classes registered with the container will also be added to the pipeline
            //app.UseAutofacMiddleware(DependenciesConfig.Container);

            app.UseAutofacWebApi(config);
        }
    }
}
