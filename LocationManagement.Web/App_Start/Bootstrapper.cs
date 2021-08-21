using Autofac;
using Autofac.Integration.Mvc;
using LocationManagement.Data;
using LocationManagement.Repositories;
using LocationManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LocationManagement.Web.App_Start
{
    public class Bootstrapper : Autofac.Module
    {
        public static void Run()
        {
            SetAutofacContainer();
        }
        private static void SetAutofacContainer()
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
                builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
                builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
                builder.RegisterType<DbContextFactory>().As<IDbContextFactory>().InstancePerRequest();

                builder.RegisterType<CityRepository>().As<ICityRepository>().InstancePerRequest();
                builder.RegisterType<CityService>().As<ICityService>().InstancePerRequest();

                builder.RegisterType<CountryRepository>().As<ICountryRepository>().InstancePerRequest();
                builder.RegisterType<CountryService>().As<ICountryService>().InstancePerRequest();

                //builder.RegisterAssemblyTypes(typeof(ICityRepository).Assembly)
                //   .Where(t => t.Name.EndsWith("Repository"))
                //   .AsImplementedInterfaces().InstancePerRequest();
                //builder.RegisterAssemblyTypes(typeof(ICityService).Assembly)
                //   .Where(t => t.Name.EndsWith("Service"))
                //   .AsImplementedInterfaces()
                //   .PropertiesAutowired()
                //   .InstancePerRequest();

                IContainer container = builder.Build();
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            }
            catch (System.Exception)
            {
            }
        }

    }
}