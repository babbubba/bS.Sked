﻿using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Reflection;
using System.Web.Mvc;

namespace bS.Sked.CompositionRoot
{
    public class CR : ICompositionRoot
    {
        ContainerBuilder builder;
        IContainer iocContainer;

        public CR()
        {
            builder = new ContainerBuilder();
        }

        #region Singleton
        static CR singletonInstance;

        public static CR Instance()
        {
            return (singletonInstance != null) ? singletonInstance : singletonInstance = new CR();
        }
        #endregion

        public bool BuildContainer()
        {
            iocContainer = builder.Build();

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>An instance of type 'System.Web.Mvc.IDependencyResolver'. You have to cast this value to register in MVC.</returns>
        public IDependencyResolver GetMvcDependencyResolver()
        {
            if (iocContainer == null) throw new ApplicationException("Container has not been initialized.");
            return new AutofacDependencyResolver(iocContainer);
        }

        /// <summary>
        /// Register a component to be created through reflection.
        /// </summary>
        /// <typeparam name="Component">The component type</typeparam>
        public void Register<Component>()
        {
            if (iocContainer != null) throw new ApplicationException("Container has been initialized yet.");
            builder.RegisterType<Component>();
        }

        /// <summary>
        /// Register a component to be created through reflection and configure the service that the component will provide.
        /// </summary>
        /// <typeparam name="Component"></typeparam>
        /// <typeparam name="Service"></typeparam>
        public void Register<Component, Service>()
        {
            if (iocContainer != null) throw new ApplicationException("Container has been initialized yet.");
            builder.RegisterType<Component>().As<Service>();
        }

        /// <summary>
        /// Register an instance as a component.
        /// </summary>
        /// <typeparam name="Component">The Component type of the instance to register.</typeparam>
        /// <typeparam name="Service">The service for this component.</typeparam>
        /// <param name="componentInstance">>The Component instance to register.</param>
        public void RegisterInstance<Component, Service>(Component componentInstance) where Component : class
        {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterInstance(componentInstance).As<Service>();
        }

        /// <summary>
        /// Register an instance as a component (without specifying the Service).
        /// </summary>
        /// <typeparam name="Component">The Component type of the instance to register.</typeparam>
        /// <typeparam name="Service">The service for this component.</typeparam>
        /// <param name="componentInstance">>The Component instance to register.</param>
        public void RegisterInstance<Component>(Component componentInstance) where Component : class
        {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterInstance(componentInstance);
        }

        public void RegisterIocModule<T>(T iocModule) where T : IIocModule
        {
            if (iocContainer != null) throw new ApplicationException("Container has been initialized yet.");
            var module = (Autofac.Core.IModule)iocModule;
            builder.RegisterModule(module);
        }

        /// <summary>
        /// Registers MVC controllers.
        /// </summary>
        /// <param name="mvcAssembly">The Gloabl.asax main class assembly.</param>
        public void RegisterControllers(Assembly mvcAssembly)
            {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterControllers(mvcAssembly);
        }

        /// <summary>
        /// Add for registrartion the model binders that require DI.
        /// </summary>
        /// <param name="mvcAssembly">The Gloabl.asax main class assembly.</param>
        public void RegisterModelBinders(Assembly mvcAssembly)
        {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterModelBinders(mvcAssembly);
        }

        /// <summary>
        /// Registers Model Binders added with method <see cref="RegisterModelBinders"/>
        /// </summary>
        public void RegisterModelBinderProvider()
        {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterModelBinderProvider();
        }

        //TODO: This method has to ber abstracted with ICompositionRootModule interface to avoid Autofac dependences in target project
        public void RegisterModule<TModule>() where TModule : Autofac.Core.IModule, new()
        {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterModule<TModule>();
        }

        /// <summary>
        /// Register web abstractions like HttpContextBase.
        /// </summary>
        public void RegisterWebAbstractionModule()
        {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterModule<AutofacWebTypesModule>();
        }

        /// <summary>
        /// Enable property injection in view pages.
        /// </summary>
        public void RegisterView()
        {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterSource(new ViewRegistrationSource());
        }

        /// <summary>
        /// Enable property injection into action filters.
        /// </summary>
        public void RegisterFilterProvider()
        {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterFilterProvider();
        }

        /// <summary>
        /// Register an un-parameterised generic type, e.g. Repository. Concrete types will be made as they are requested.
        /// </summary>
        /// <param name="component"></param>
        /// <param name="service"></param>
        public void RegisterGeneric(Type component, Type service)
        {
            if (iocContainer != null) throw new ApplicationException("Container has been still initialized.");
            builder.RegisterGeneric(component).As(service).InstancePerLifetimeScope();
        }




        public T Resolve<T>()
        {
            if (iocContainer == null) throw new ApplicationException("Container has not been initialized yet.");
            return iocContainer.Resolve<T>();
        }
    }
}
