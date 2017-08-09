using Autofac.Integration.WebApi;
using RealmdigitalInterview.Core.Interfaces;
using RealmdigitalInterview.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RealmdigitalInterview.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //api registrations
            IocContainer.ContainerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            IocContainer.ContainerBuilder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            IocContainer.ContainerBuilder.RegisterWebApiModelBinderProvider();

            //component registrations
            Services.Ioc.IocRegistration.Register();

            IocContainer.RegisterInstance<IConnection>(new Connection
            {
                Name = ConfigurationManager.ConnectionStrings["Default"].Name,
                ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString
            });

            //build ioc container
            IocContainer.Build();
            
            //assign autofac dependency resolver
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(IocContainer.Container);

            
        }
    }
}
