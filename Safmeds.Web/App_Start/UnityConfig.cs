using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Safmeds.Repo.Repositories;
using Safmeds.Repo.Repositories.SqlServer;
using Safmeds.Repo.EntityFramework;
using System.Data.Entity;
using Safmeds.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Safmeds.Web.Controllers;
using Microsoft.Owin.Security;
using System.Web;
using Safmeds.Core;

namespace Safmeds.Web.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            //Membership 
            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType(typeof(UserManager<>),
            new InjectionConstructor(typeof(IUserStore<>)));
            container.RegisterType<Microsoft.AspNet.Identity.IUser>(new InjectionFactory(c => c.Resolve<Microsoft.AspNet.Identity.IUser>()));
            container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            container.RegisterType<IdentityUser, ApplicationUser>(new ContainerControlledLifetimeManager());
            container.RegisterType<DbContext, ApplicationDbContext>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAuthenticationManager>(new InjectionFactory(o => HttpContext.Current.GetOwinContext().Authentication));
            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<IUserStore<ApplicationUser>,UserStore<ApplicationUser>>(new InjectionConstructor(new ApplicationDbContext()));

            container.RegisterType<IUserStore<ApplicationUser>,
            UserStore<ApplicationUser>>(new InjectionConstructor(new ApplicationDbContext()));

            //Service
            container.RegisterType<IDataService, DataService>(new PerRequestLifetimeManager());

            //Repositories
            container.RegisterType<ISafmedRepository, SQLSafmedRepository>(new PerRequestLifetimeManager());
            container.RegisterType<ISafmedSessionRepository, SQLSafmedSessionRepository>(new PerRequestLifetimeManager());

            //Context
            container.RegisterType<SafmedsContext>(new PerRequestLifetimeManager());
                
        }
    }
}
