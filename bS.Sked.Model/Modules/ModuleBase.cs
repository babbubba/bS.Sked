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

        public ModuleBase()
        {
          //  throw new ApplicationException("Extension Module has to implements constructor and populate 'supportedElementTypes' field.");
        }

        public abstract IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement);
        public abstract bool IsSupported(IExecutableElementModel executableElement);
    }
}
