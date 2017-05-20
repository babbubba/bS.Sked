using bS.Sked.Model.CompositionRoot.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.CompositionRoot
{
    public class CompositionRoot : ICompositionRoot
    {



        #region Singleton
        static CompositionRoot singletonInstance;
        public static CompositionRoot SingletonInstance()
        {
            return (singletonInstance != null) ? singletonInstance : new CompositionRoot();
        } 
        #endregion

        public bool BuildContainer()
        {
            throw new NotImplementedException();
        }

        public void Register<T>(T component, RegistrationType type = RegistrationType.Transient)
        {
            throw new NotImplementedException();
        }

        public void Register<T>(T component, string componentName, RegistrationType type = RegistrationType.Transient)
        {
            throw new NotImplementedException();
        }

        public void RegisterInstance<T>(object instance)
        {
            throw new NotImplementedException();
        }

        public void RegisterIocModule<T>(T iocModule) where T : IIocModule
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>(string ComponentName)
        {
            throw new NotImplementedException();
        }
    }
}
