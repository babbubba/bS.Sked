using bS.Sked.Model.Interfaces.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.Elements;

namespace bS.Sked.Model.Modules
{
    public abstract class ModuleBase : IExtensionModule
    {
        protected string[] supportedElementTypes;
        protected string[] implementedElementTypes;

        public ModuleBase()
        {
          //  throw new ApplicationException("Extension Module has to implements constructor and populate 'supportedElementTypes' field.");
        }

        public abstract IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement);
        //public abstract bool IsSupported(IExecutableElementModel executableElement);
        //public abstract bool IsImplemented(IExecutableElementModel executableElement);

        public virtual bool IsSupported(IExecutableElementModel executableElement)
        {
            return supportedElementTypes?.Contains(executableElement.ElementType.PersistingId) ?? false;
        }
        public virtual bool IsImplemented(IExecutableElementModel executableElement)
        {
            return implementedElementTypes?.Contains(executableElement.ElementType.PersistingId) ?? false;
        }
    }
}
