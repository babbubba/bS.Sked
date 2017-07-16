using bS.Sked.Model.Interfaces.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
using bS.Sked.Model.Interfaces.DTO;

namespace bS.Sked.Model.Modules
{
    public abstract class ModuleBase : IExtensionModule
    {
        protected string[] supportedElementTypes;
        protected string[] implementedElementTypes;

        public ModuleBase()
        {
        }

        public abstract IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement);
        public abstract IExecutableElementBaseViewModel AddElement(string elementPID, IDictionary<string, IField> properties);
     
        public virtual bool IsSupported(string executableElementPersistingId)
        {
            return supportedElementTypes?.Contains(executableElementPersistingId) ?? false;
        }
        public virtual bool IsImplemented(string executableElementPersistingId)
        {
            return implementedElementTypes?.Contains(executableElementPersistingId) ?? false;
        }

        public abstract IExecutableElementBaseViewModel EditElement(string elementId, string elementPID, IDictionary<string, IField> properties);
    }
}
