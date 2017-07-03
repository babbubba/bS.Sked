﻿using bS.Sked.Data;
using bS.Sked.Data.Interfaces;
using bS.Sked.Services.WMC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace bS.Sked.WMC
{
    public class CompositionRootConfig
    {
        /// <summary>
        /// Init Composition Root and register Controllers, ModelBinders, Web abstractions, enable injection in views
        /// and set MVC 'DependencyResolver' to use CompositionRoot Container.
        /// </summary>
        public static void RegisterComponents()
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

            #region Dynamically registers Extensions Modules and Intializer (as Self)

            string[] assemblyScanerPattern = new[] { @"bS.Sked.Extensions.*.dll" };

            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            // Scan for assemblies containing extrensions
            List<Assembly> assemblies = new List<Assembly>();
            assemblies.AddRange(
                Directory.EnumerateFiles(Directory.GetCurrentDirectory(), "*.dll", SearchOption.AllDirectories)
                         .Where(filename => assemblyScanerPattern.Any(pattern => Regex.IsMatch(filename, pattern)))
                         .Select(Assembly.LoadFrom)
                );

            foreach (var assembly in assemblies)
            {
                Sked.CompositionRoot.CompositionRoot.Instance().RegisterExtensionsAssemblyTypes(assembly);

            } 
            #endregion
            
            // Context and Unit Of Work
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterInstance(new DataContextConfigInfo { ConnectionString = @"Server = localhost; Database = sked; User ID = root; Password = beibub1;", ExtraDllModelFolders = null });
            Sked.CompositionRoot.CompositionRoot.Instance().Register<ObjectContextImpl, IObjectContext>();
            Sked.CompositionRoot.CompositionRoot.Instance().Register<UnitOfWork, IUnitOfWork>();

            //Repositories
            Sked.CompositionRoot.CompositionRoot.Instance().RegisterGeneric (typeof(RepositoryBase<>), typeof(IRepository<>));

            //Services
            Sked. CompositionRoot.CompositionRoot.Instance().Register<LeftSidebarService>();
            Sked. CompositionRoot.CompositionRoot.Instance().Register<SettingService>();
            Sked. CompositionRoot.CompositionRoot.Instance().Register<DatabaseManagerService>();

            //Build the CompositionRoot IOC Container
            Sked.CompositionRoot.CompositionRoot.Instance().BuildContainer();

            // Set the dependency resolver of MVC to the Composition Root Container.
            DependencyResolver.SetResolver(Sked.CompositionRoot.CompositionRoot.Instance().GetMvcDependencyResolver());
        }

     
    }
}