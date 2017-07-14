using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Engine
{
    public class Executer
    {
        private IRepository<IPersisterEntity> _repository;
        private IEnumerable<IExtensionModule> _modules;

        public Executer(IRepository<IPersisterEntity> repository, IEnumerable<IExtensionModule> modules)
        {
            _repository = repository;
            _modules = modules;
        }

        public IExtensionExecuteResult ExecuteElement(IExtensionContext context, IExecutableElementModel executableElement)
        {
            foreach (var module in _modules)
            {
                if (module.IsImplemented(executableElement.ElementType.PersistingId))
                {
                    return module.Execute(context, executableElement);
                }
            }

            return new ExtensionExecuteResult
            {
                IsSuccessfullyCompleted = false,
                Message = $"No module implements this element (element type: '{executableElement.ElementType.Name}').",
                Errors = new string[] { "Can not init Main Object" }
            };
        }

        
    }
}
