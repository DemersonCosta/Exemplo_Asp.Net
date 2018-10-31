﻿using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Winterfell.Core;
using Winterfell.Web.App_Data;
using Winterfell.Web.Infra;
using Winterfell.Web.Infra.Container;

namespace Winterfell.Web
{
    public class MvcApplication : HttpApplication
    {
        private static IWindsorContainer _container;

        protected void Application_Start()
        {
            SetupContainer();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ValueProviderFactories.Factories.Remove(ValueProviderFactories.Factories.OfType<JsonValueProviderFactory>().FirstOrDefault());
            ValueProviderFactories.Factories.Add(new DefaultJsonValueProviderFactory());
        }

        private void SetupContainer()
        {
            _container = new DefaultContainer();

            ((DefaultContainer)_container).SetupForWeb();

            _container.Register(
                Component.For<DataService>()
                );

            _container.Install(new WindsorControllerInstaller());
            var windsorControllerFactory = new WindsorControllerFactory(_container);

            ControllerBuilder.Current.SetControllerFactory(windsorControllerFactory);
        }
    }
}
