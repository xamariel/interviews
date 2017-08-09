using Autofac.Integration.Mvc;
using Realmdigital_Interview;
using Realmdigital_Interview.Global;
using RealmdigitalInterview.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Retiremate_Integration_Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //set api endpoint
            ApiEndpoint.DefaultApi = ConfigurationManager.AppSettings["ApiEndpoint"];

            //implement ioc container

            //controller registrations
            IocContainer.ContainerBuilder.RegisterControllers(typeof(WebApiApplication).Assembly);

            //component registrations
            IocRegistration.Register();

            //build ioc container
            IocContainer.Build();

            //assign autofac dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(IocContainer.Container));
        }
    }
}
