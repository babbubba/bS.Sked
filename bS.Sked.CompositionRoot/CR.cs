using Autofac;
using Autofac.Integration.Mvc;
using bS.Sked.Model.CompositionRoot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static CR SingletonInstance()
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
        public object GetResolver()
        {
            if (iocContainer == null) throw new ApplicationException("Container has not been initialized.");
            return new AutofacDependencyResolver(iocContainer);
        }

        public void Register<Component>()
        {
            if (iocContainer != null) throw new ApplicationException("Container has been initialized yet.");
            builder.RegisterType<Component>();
        }

        public void Register<Component, Service>()
        {
            if (iocContainer != null) throw new ApplicationException("Container has been initialized yet.");
            builder.RegisterType<Component>().As<Service>();
        }

        public void RegisterInstance<Component, Service>(Component componentInstance) where Component : class
        {
            if (iocContainer != null) throw new ApplicationException("Container has been initialized yet.");
            builder.RegisterInstance(componentInstance).As<Service>();
        }

        public void RegisterIocModule<T>(T iocModule) where T : IIocModule
        {
            if (iocContainer != null) throw new ApplicationException("Container has been initialized yet.");
            var module = (Autofac.Core.IModule)iocModule;
            builder.RegisterModule(module);
        }

        public T Resolve<T>()
        {
            if (iocContainer == null) throw new ApplicationException("Container has not been initialized yet.");
            return iocContainer.Resolve<T>();
        }
    }
}
