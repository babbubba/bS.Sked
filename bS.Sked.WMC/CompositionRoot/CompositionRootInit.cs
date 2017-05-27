using bS.Sked.CompositionRoot;
using bS.Sked.Model.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bS.Sked.WMC.CompositionRoot
{
    public class CompositionRootInit
    {
        /// <summary>
        /// Init Composition Root and register Controllers, ModelBinders, Web abstractions, enable injection in views
        /// and set MVC 'DependencyResolver' to use CompositionRoot Container.
        /// </summary>
        public static void Main()
        {
            #region MVC
            // Register your MVC controllers. 
            CR.Instance().RegisterControllers(typeof(MvcApplication).Assembly);
            
            // OPTIONAL: Register model binders that require DI.
            CR.Instance().RegisterModelBinders(typeof(MvcApplication).Assembly);
            CR.Instance().RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            CR.Instance().RegisterWebAbstractionModule();

            // OPTIONAL: Enable property injection in view pages.
            CR.Instance().RegisterView();

            // OPTIONAL: Enable property injection into action filters.
            CR.Instance().RegisterFilterProvider();
            #endregion

            // Context and Unit Of Work
            CR.Instance().RegisterInstance(new ApplicationContextConfigInfo { ConnectionString = @"Server = localhost; Database = eork3v2; User ID = root; Password = beibub1;", ExtraDllModelFolders = @"C:\eOrk3\PLUGINS\" });
            CR.Instance().Register<ObjectContextImpl, IObjectContext>();
            CR.Instance().Register<UnitOfWork, IUnitOfWork>();

            //Repositories
            CR.Instance().RegisterGeneric (typeof(RepositoryBase<>), typeof(IRepository<>));

            //Build the CompositionRoot IOC Container
            CR.Instance().BuildContainer();

            // Set the dependency resolver to the Composition Root Container.
            DependencyResolver.SetResolver(CR.Instance().GetMvcDependencyResolver());
        }

        private interface IObjectContext
        {
        }

        private interface IRepository<T>
        {
        }

        private interface IUnitOfWork
        {
        }

        private class ObjectContextImpl    : IObjectContext
        {
        }

        private class RepositoryBase<T>   : IRepository<T>
        {
        }

        private class UnitOfWork    : IUnitOfWork
        {
        }
    }
}