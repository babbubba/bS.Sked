using bS.Sked.CompositionRoot;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.Interfaces.Tasks;
using bS.Sked.Model.Modules;
using bS.Sked.Model.Tasks;
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

        #region C.tor

        public Executer(IRepository<IPersisterEntity> repository, IEnumerable<IExtensionModule> modules)
        {
            _repository = repository;
            _modules = modules;
        }

        #endregion

        #region Private

        private IExtensionExecuteResult executeElement(IExtensionContext context, IExecutableElementModel executableElement)
        {
            var mod = _modules.SingleOrDefault(x => x.IsImplemented(executableElement.ElementType.PersistingId));
            if (mod != null) return mod.Execute(context, executableElement);

            //foreach (var module in _modules)
            //{
            //    if (module.IsImplemented(executableElement.ElementType.PersistingId))
            //    {
            //        return module.Execute(context, executableElement);
            //    }
            //}

            return new ExtensionExecuteResultModel
            {
                IsSuccessfullyCompleted = false,
                Message = $"No module implements this element (element type: '{executableElement.ElementType.Name}').",
                Errors = new string[] { "Can not init Element" },
                SourceId = executableElement.Id.ToString()
            };
        }

        #endregion

        /// <summary>
        /// Executes the element.
        /// </summary>
        /// <param name="context">The context (from the Main Object).</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns></returns>
        public IExtensionExecuteResult ExecuteElement(IExtensionContext context, IExecutableElementModel executableElement)
        {
            if (context == null) return new ExtensionExecuteResultModel
            {
                IsSuccessfullyCompleted = false,
                Message = $"Can not execute the Element.",
                Errors = new string[] { "Main Object context cannot be null." },
                SourceId = executableElement.Id.ToString(),
                MessageType = MessageTypeEnum.Error
            };

            if (executableElement == null) return new ExtensionExecuteResultModel
            {
                IsSuccessfullyCompleted = false,
                Message = $"Can not execute the Element.",
                Errors = new string[] { "Element can not be null." },
                SourceId = executableElement.Id.ToString(),
                MessageType = MessageTypeEnum.Error
            };

            try
            {
                return executeElement(context, executableElement);
            }
            catch (Exception ex)
            {

                return new ExtensionExecuteResultModel
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Error executing the Element.",
                    Errors = new string[] { $"{ex.Message}" },
                    SourceId = executableElement.Id.ToString()
                };
            }
        }

        public ITaskExecuteResult ExecuteTask(ITaskModel taskToExecute)
        {
            if (taskToExecute.MainObject == null) return new TaskExecuteResultModel
            {
                Message = "Cannot execute the Task.",
                IsSuccessfullyCompleted = false,
                Errors = new string[] { "Main Object can not be null." },
                SourceId = taskToExecute.Id.ToString(),
                MessageType = MessageTypeEnum.Error                
            };

            try
            {
                return executeTask(taskToExecute);
            }
            catch (Exception ex)
            {
                return new TaskExecuteResultModel
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Error executing the Task.",
                    Errors = new string[] { $"{ex.Message}" },
                    SourceId = taskToExecute.Id.ToString(),
                    MessageType = MessageTypeEnum.Fatal
                };
            }
        }

        private ITaskExecuteResult executeTask(ITaskModel taskToExecute)
        {
            var elementsResult = new List<IExtensionExecuteResult>();
            var elementsToExecute = taskToExecute.Elements.Where(x => x.IsActive).OrderBy(x => x.CreationDate).OrderBy(x => x.Position);

            var extensionContexts = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExtensionContext>>();
            var extensionContext = extensionContexts.Single(x => x.GetType().Name.Contains(taskToExecute.MainObject.MainObjectType.PersistingId));
            extensionContext.MainObject = taskToExecute.MainObject;

            foreach (var element in elementsToExecute)
            {
                var currenElementResult = ExecuteElement(extensionContext, element);
                //TODO: tracci i messaggi di ritorno e ferma se è un warning o un error ed è il caso di fermare...
                elementsResult.Add(currenElementResult);
            }

            if (elementsResult.Any(x => !x.IsSuccessfullyCompleted))
            {
                //some element failed to execute
                return new TaskExecuteResultModel
                {
                    Message = "Task Failed.",
                    IsSuccessfullyCompleted = false,
                    Errors = elementsResult.SelectMany(x => x.Errors).ToArray(),
                    SourceId = taskToExecute.Id.ToString(),
                    MessageType = MessageTypeEnum.Error
                };
            }

            if (elementsResult.Any(x => x.Errors.Count() > 0))
            {
                // All elements was executed but errors occurred
                return new TaskExecuteResultModel
                {
                    Message = "Task executed with errors.",
                    IsSuccessfullyCompleted = true,
                    Errors = elementsResult.SelectMany(x => x.Errors).ToArray(),
                    SourceId = taskToExecute.Id.ToString(),
                    MessageType = MessageTypeEnum.Warning
                };
            }

            return new TaskExecuteResultModel
            {
                Message = $"Task Completed. {elementsToExecute.Count()} elements executed.",
                IsSuccessfullyCompleted = true,
                SourceId = taskToExecute.Id.ToString(),
                MessageType = MessageTypeEnum.Info
            };
        }
    }
}
