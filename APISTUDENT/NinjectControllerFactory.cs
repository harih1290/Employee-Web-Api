using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using APISTUDENT.Models.Interface;
using APISTUDENT.Models;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace APISTUDENT
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        /// <summary>
        /// Constructor
        ///To add Interface and Repository to the kernal
        /// </summary>

        public NinjectControllerFactory()

        {
            ninjectKernel = new StandardKernel();

            //ninjectKernel.Load(Assembly.GetExecutingAssembly());
            ninjectKernel.Load(typeof(NinjectControllerFactory).Assembly);
            //GlobalConfiguration.Configuration.DependencyResolver =
            //                       new LocalNinjectDependencyResolver(ninjectKernel);
            AddBindings();
        }

        /// <summary>
        /// To get Controller Instance
        /// </summary>
        /// <param name="requestContext">Request Context</param>
        /// <param name="controllerType">Controller Type</param>
        /// <returns>Controller Instance</returns>

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        /// <summary>
        /// Binds Interface with Repository
        /// </summary>

        private void AddBindings()
        {

            ninjectKernel.Bind<ISqlHelpernterface>().To<SQLHelperRepository>();
            

        }
    }

    
}