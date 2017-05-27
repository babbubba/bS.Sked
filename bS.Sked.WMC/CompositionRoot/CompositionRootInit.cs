using bS.Sked.CompositionRoot;
using bS.Sked.Data;
using bS.Sked.Data.Interfaces;
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
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterModelBinders(typeof(MvcApplication).Assembly);
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterModelBinderProvider();

            // OPTIONAL: Register web abstractions like HttpContextBase.
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterWebAbstractionModule();

            // OPTIONAL: Enable property injection in view pages.
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterView();

            // OPTIONAL: Enable property injection into action filters.
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterFilterProvider();
            #endregion

            // Context and Unit Of Work
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterInstance(new ApplicationContextConfigInfo { ConnectionString = @"Server = localhost; Database = eork3v2; User ID = root; Password = beibub1;", ExtraDllModelFolders = @"C:\eOrk3\PLUGINS\" });
            Sked.CompositionRoot.CompositionRoot.Instance().Register<ObjectContextImpl, IObjectContext>();
            Sked.CompositionRoot.CompositionRoot.Instance().Register<UnitOfWork, IUnitOfWork>();

            //Repositories
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterGeneric (typeof(RepositoryBase<>), typeof(IRepository<>));

            //Build the CompositionRoot IOC Container
            Sked.CompositionRoot.CompositionRoot.Instance().BuildContainer();

            // Set the dependency resolver to the Composition Root Container.
            DependencyResolver.SetResolver(Sked.CompositionRoot.CompositionRoot.Instance().GetMvcDependencyResolver());
        }

     
    }
}