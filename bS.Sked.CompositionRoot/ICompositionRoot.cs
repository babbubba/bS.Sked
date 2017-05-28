using System;
using System.Reflection;
using System.Web.Mvc;
using Autofac.Core;

namespace bS.Sked.CompositionRoot
{
    public interface ICompositionRoot
    {
        bool BuildContainer();
        IDependencyResolver GetMvcDependencyResolver();
        void Register<Component>();
        void Register<Component, Service>();
        void RegisterControllers(Assembly mvcAssembly);
        void RegisterFilterProvider();
        void RegisterGeneric(Type component, Type service);
        void RegisterInstance<Component>(Component componentInstance) where Component : class;
        void RegisterInstance<Component, Service>(Component componentInstance) where Component : class;
        void RegisterIocModule<T>(T iocModule) where T : IIocModule;
        void RegisterModelBinderProvider();
        void RegisterModelBinders(Assembly mvcAssembly);
        void RegisterView();
        void RegisterWebAbstractionModule();
        T Resolve<T>();
    }
}