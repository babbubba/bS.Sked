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

        /// <summary>
        /// Executes the element.
        /// </summary>
        /// <param name="context">The context (from the Main Object).</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns></returns>
        public IExtensionExecuteResult ExecuteElement(IExtensionContext context, IExecutableElementModel executableElement)
        {
            if (context == null) return new ExtensionExecuteResult
            {
                IsSuccessfullyCompleted = false,
                Message = $"Main Object context cannot be null.",
                Errors = new string[] { "Can not execute the Element." }
            };

            if (executableElement == null) return new ExtensionExecuteResult
            {
                IsSuccessfullyCompleted = false,
                Message = $"Element cannot be null.",
                Errors = new string[] { "Can not execute the Element." }
            };

            try
            {
                return executeElemnt(context, executableElement);
            }
            catch (Exception ex)
            {

                return new ExtensionExecuteResult
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Error executing the Element.",
                    Errors = new string[] { $"{ex.Message}" }
                };
            }
        }

        private IExtensionExecuteResult executeElemnt(IExtensionContext context, IExecutableElementModel executableElement)
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
