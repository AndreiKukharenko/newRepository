using Autofac;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.UnitOfwork;
using FilmsWebApi.BLL.Infrastructure;
using FilmsWebApi.BLL.Services;
using System.Web.Http;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace FilmsWebApi.Web.App_Start
{
    public static class DependenciesConfig
    {
        public static void RegisterDependencies(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
        
            builder.RegisterType<AppContext>().AsSelf().WithParameter("connectionString", "Films").InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUoW>().InstancePerRequest();
            builder.RegisterType<FilmService>().As<IFilmService>().InstancePerRequest();

            // register controllers all at once using assembly scanning
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType<FilmsController>().InstancePerRequest();  //register ApiController manually

            //register filter provider implementation
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}