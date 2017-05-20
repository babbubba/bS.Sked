using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.CompositionRoot.Interfaces
{
    public enum RegistrationType
    {
        Singleton = 0,
        Transient = 1
    }
    public interface ICompositionRoot
    {
        void Register<T>(T component, RegistrationType type = RegistrationType.Transient);
        void Register<T>(T component, string componentName, RegistrationType type = RegistrationType.Transient);
        void RegisterInstance<T>(object instance);
        void RegisterIocModule<T>(T iocModule) where T:IIocModule;
        T Resolve<T>();
        T Resolve<T>(string ComponentName);
        bool BuildContainer();
    }

    public interface IIocModule
    {

    }
}
