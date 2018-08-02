[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MVC5_Template.Web.DependencyInjectionConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MVC5_Template.Web.DependencyInjectionConfig), "Stop")]

namespace MVC5_Template.Web
{
    using System;
    using System.Data.Entity;
    using System.Web;

    using Auth.ApplicationManagers;
    using Auth.Models;

    using AutoMapper;
    using Core.Contracts;

    using Infrastructure.Attributes;
    using Infrastructure.Filters;   

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Web.Common;
    using Ninject.Web.Mvc.FilterBindingSyntax;

    using Persistence.Data;
    using Persistence.Data.Repositories;
    using Persistence.Data.UnitOfWork;

    using Services.Data.Contracts;

    public static class DependencyInjectionConfig 
    {
        private static readonly Bootstrapper Bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            Bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            Bootstrapper.ShutDown();
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
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            kernel.Bind(x =>
            {
                x.FromAssemblyContaining(typeof(IDataService))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            kernel
                .Bind(typeof(DbContext), typeof(MsSqlDbContext))
                .To<MsSqlDbContext>()
                .InRequestScope();

            // Configure the db context, user manager and signin manager to use a single instance per request
            kernel.Bind<ApplicationUserManager>().ToSelf().InRequestScope();
            kernel.Bind<ApplicationSignInManager>().ToSelf().InRequestScope();
            kernel.Bind<IUserStore<User>>().To<UserStore<User>>().InRequestScope();
            kernel.Bind<IAuthenticationManager>()
                .ToMethod(c => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();
            kernel.Bind<IdentityFactoryOptions<ApplicationUserManager>>().ToSelf().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(IRepository<,>)).To(typeof(EfRepository<,>)).InRequestScope();
            kernel.Bind<IMapper>().ToMethod(ctx => Mapper.Instance).InSingletonScope();

            kernel.BindFilter<SaveChangesFilter>(System.Web.Mvc.FilterScope.Controller, 0)
                .WhenActionMethodHas<SaveChangesAttribute>();
        }
    }
}
