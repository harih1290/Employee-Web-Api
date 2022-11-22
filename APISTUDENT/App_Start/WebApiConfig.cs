using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;
using APISTUDENT.Models.Interface;
using APISTUDENT.Models;
using Ninject.Web.WebApi;

namespace APISTUDENT
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            //var cons = new DefaultInlineConstraintResolver()
            //{
            //    ConstraintMap =
            //    {
            //        ["Apiversion"]=typeof(ApiVersionRouteConstraint)
            //    }
            //};
            //IKernel kernel = new StandardKernel();
            //kernel.Bind<ISqlHelpernterface>().To<SQLHelperRepository>();
            //config.DependencyResolver = new NinjectDependencyResolver(kernel);
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
