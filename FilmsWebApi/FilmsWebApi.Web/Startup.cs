using System;
using System.Collections.Generic;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using FilmsWebApi.Web.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

[assembly:OwinStartup(typeof(FilmsWebApi.Web.Startup))]

namespace FilmsWebApi.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            WebApiConfig.Register(config);
            ConfigureAuth(app);
            app.UseWebApi(config);
        }
    }
}
