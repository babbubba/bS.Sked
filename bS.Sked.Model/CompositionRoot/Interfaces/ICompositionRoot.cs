using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.CompositionRoot.Interfaces
{
    public interface ICompositionRoot
    {
        void Register<Component>();
        void Register<Component, Service>();
        void RegisterInstance<Component, Service>(Component componentInstance) where Component : class;
        void RegisterIocModule<T>(T iocModule) where T:IIocModule;
        T Resolve<T>();
        object GetResolver();
        bool BuildContainer();
    }

    public interface IIocModule 
    {

    }
}
