﻿using System;
using Autofac;
using Autofac.Integration.Mvc;
using FilmsWebApi.DAL.Infrastructure;
using FilmsWebApi.DAL.Repositories;
using FilmsWebApi.DAL.Context;
using FilmsWebApi.DAL.UnitOfwork;

namespace FilmsWebApi.App_Start
{
    public static class DependenciesConfig
    {
        private static ContainerBuilder builder;
        public static void RegisterDependencies()
        {
            builder = new ContainerBuilder();

            // Can Register MVC controllers, model binders that require DI,
            // web abstractions like HttpContextBase;
            // Enable property injection in view pages. http://docs.autofac.org/en/latest/integration/mvc.html

            builder.RegisterType<FilmsRepository>().As<IFilmsRepository>();
            builder.RegisterType<AppContext>().As<IAppContext>();
            builder.RegisterType<UnitOfWork>().As<IUoW>();
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