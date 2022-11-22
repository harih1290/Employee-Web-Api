[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(APISTUDENT.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(APISTUDENT.App_Start.NinjectWebCommon), "Stop")]

namespace APISTUDENT.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Dependencies;
    using System.Web.UI.WebControls;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Activation;
    using Ninject.Syntax;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using APISTUDENT.Models.Interface;
    using APISTUDENT.Models;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                //GlobalConfiguration.Configuration.DependencyResolver = new NinjectResolver(kernel);
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<ISqlHelpernterface>().To<SQLHelperRepository>();
        }
    }
    //public class NinjectResolver : NinjectScope,IDependencyResolver
    //{
    //    private readonly IKernel _kernel;
    //    public NinjectResolver(IKernel kernel)
    //    {
    //        _kernel = kernel;
    //    }
    //    public IDependencyScope BeginScop()
    //    {
    //        return new NinjectScope(_kernel.BeginBlock());
    //    }
    //}
    //public class NinjectScope : IDependencyScope
    //{
    //    protected IResolutionRoot resolutionRoot;
    //    public NinjectScope (IResolutionRoot kernel)
    //    {
    //        resolutionRoot = kernel;
    //    }
    //    public object GetService(Type serviceType)
    //    {
    //        IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
    //        return resolutionRoot.Resolve(request).SingleOrDefault();
    //    }
    //    public IEnumerable<object> GetService(Type serviceType)
    //    {
    //        IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
    //        return resolutionRoot.Resolve(request).ToList();
    //    }
    //    public void Dispose()
    //    {
    //        IDisposable disposable = (IDisposable)resolutionRoot;
    //        if (disposable != null) disposable.Dispose();
    //        resolutionRoot = null;
    //    }
    //}
}