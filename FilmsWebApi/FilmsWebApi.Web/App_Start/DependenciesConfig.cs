using Autofac;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Repositories;
using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.UnitOfwork;
using FilmsWebApi.DAL.Models;
using FilmsWebApi.BLL.Infrastructure;
using FilmsWebApi.BLL.Services;
using System.Web.Http;

namespace FilmsWebApi.Web.App_Start
{
    public static class DependenciesConfig
    {
        private static ContainerBuilder builder;
        public static void RegisterDependencies(HttpConfiguration config)
        {
            builder = new ContainerBuilder();

            // Can Register MVC controllers, model binders that require DI,
            // web abstractions like HttpContextBase;
            // Enable property injection in view pages. http://docs.autofac.org/en/latest/integration/mvc.html

            // TODO: manage lifetime scope 

            builder.RegisterType<GenericRepository<Film>>().As<IGenericRepository<Film>>();
            builder.RegisterType<UnitOfWork>().As<IUoW>();
            builder.RegisterType<FilmService>().As<IFilmService>();

        }

        public static ContainerBuilder Builder
        {
            get
            {
                return builder;
            }
        }

    }
}