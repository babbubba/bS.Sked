using bS.Sked.CompositionRoot;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Engine;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Jobs;
using bS.Sked.Model.Interfaces.MainObjects;
using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.Interfaces.Tasks;
using bS.Sked.Model.Jobs;
using bS.Sked.Model.Modules;
using bS.Sked.Model.Tasks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Engine
{
    public class Executer
    {
        private IRepository<IPersisterEntity> _repository;
        private IEnumerable<IExtensionModule> _modules;
        private readonly EngineConfig engineConfig;

        #region C.tor

        public Executer(IRepository<IPersisterEntity> repository, IEnumerable<IExtensionModule> modules, EngineConfig engineConfig)
        {
            _repository = repository;
            _modules = modules;
            this.engineConfig = engineConfig;
        }

        #endregion

        #region Private

        private IElementInstanceModel ElementInstanceStart(IExecutableElementModel element, string parentPath)
        {
            if (element.Instances == null) element.Instances = new List<IElementInstanceModel>();
            var elementInstance = new Model.Elements.ElementInstanceModel();
            elementInstance.StartTime = DateTime.UtcNow;
            _repository.Add(elementInstance);
            elementInstance.PersistingFullPath = Path.Combine(parentPath, elementInstance.Id.ToString()); 
            _repository.Update(elementInstance);
            return elementInstance;
        }
        private IElementInstanceModel ElementInstanceStop(IElementInstanceModel elementInstance)
        {
            elementInstance.EndTime = DateTime.UtcNow;
            _repository.Update(elementInstance);
            return elementInstance;
        }

        private ITaskInstanceModel TaskInstanceStart(ITaskModel task, string parentPath)
        {
            if (task.Instances == null) task.Instances = new List<ITaskInstanceModel>();
            var taskInstance = new Model.Tasks.TaskInstanceModel();
            taskInstance.StartTime = DateTime.UtcNow;
            _repository.Add(taskInstance);
            taskInstance.PersistingFullPath = Path.Combine(parentPath, taskInstance.Id.ToString());
            _repository.Update(taskInstance);
            return taskInstance;
        }

        private ITaskInstanceModel TaskInstanceStop(ITaskInstanceModel taskInstance)
        {
            taskInstance.EndTime = DateTime.UtcNow;
            _repository.Update(taskInstance);
            return taskInstance;
        }

        private IJobInstanceModel JobInstanceStart(IJobModel job)
        {
            if (job.Instances == null) job.Instances = new List<IJobInstanceModel>();
            var jobInstance = new Model.Jobs.JobInstanceModel();
            jobInstance.StartTime = DateTime.UtcNow;
            _repository.Add(jobInstance);
            jobInstance.PersistingFullPath = Path.Combine(engineConfig.TempFolder, jobInstance.Id.ToString());
            _repository.Update(jobInstance);
            return jobInstance;
        }

        private IJobInstanceModel JobInstanceStop(IJobInstanceModel jobInstance)
        {
            jobInstance.EndTime = DateTime.UtcNow;
            _repository.Update(jobInstance);
            return jobInstance;
        }

        private IExtensionExecuteResult executeElement(IMainObjectModel mainObject, IExecutableElementModel executableElement, ITaskInstanceModel taskInstance)
        {

            var mod = _modules.SingleOrDefault(x => x.IsImplemented(executableElement.ElementType.PersistingId));
            if (mod != null)
            {
                var elementInstance = ElementInstanceStart(executableElement, taskInstance.PersistingFullPath);

                var result = mod.Execute(mainObject, executableElement, elementInstance);

                ElementInstanceStop(elementInstance);

                return result;
            }

            return new ExtensionExecuteResultModel
            {
                IsSuccessfullyCompleted = false,
                Message = $"No module implements this element (element type: '{executableElement.ElementType.Name}').",
                Errors = new string[] { "Can not init Element" },
                SourceId = executableElement.Id.ToString(),
                MessageType = MessageTypeEnum.Fatal
            };
        }

        private ITaskExecuteResult executeTask(ITaskModel taskToExecute, IJobInstanceModel jobInstance)
        {
            var taskInstance = TaskInstanceStart(taskToExecute, jobInstance.PersistingFullPath);

            var elementsResult = new List<IExtensionExecuteResult>();
            var elementsToExecute = taskToExecute.Elements.Where(x => x.IsActive).OrderBy(x => x.CreationDate).OrderBy(x => x.Position);

            foreach (var element in elementsToExecute)
            {
                var currenElementResult = ExecuteElement(taskToExecute.MainObject, element, taskInstance);
                elementsResult.Add(currenElementResult);

                if (currenElementResult.MessageType == MessageTypeEnum.Error && element.StopParentIfErrorOccurs)
                {
                    // we have to stop the task and send back an error result
                    taskInstance.HasErrors++;
                    return new TaskExecuteResultModel
                    {
                        Message = $"Task Failed. The element '{element.Name}' ({element.Id}) failed to execute and aborts the parent task.",
                        IsSuccessfullyCompleted = false,
                        Errors = GetErrorsFromResults(elementsResult),
                        SourceId = taskToExecute.Id.ToString(),
                        MessageType = MessageTypeEnum.Error
                    };
                }

                if (currenElementResult.MessageType == MessageTypeEnum.Warning && element.StopParentIfWarningOccurs)
                {
                    // we have to stop the task and send back an error result
                    taskInstance.HasErrors++;
                    return new TaskExecuteResultModel
                    {
                        Message = $"Task Failed. The element '{element.Name}' ({element.Id}) has at least a warn and aborts the parent task.",
                        IsSuccessfullyCompleted = false,
                        Errors = GetErrorsFromResults(elementsResult),
                        SourceId = taskToExecute.Id.ToString(),
                        MessageType = MessageTypeEnum.Error
                    };
                }
            }
            taskInstance.IsSuccessfullyCompleted = true;
            TaskInstanceStop(taskInstance);

            if (elementsResult.Any(x =>x.Errors!=null && x.Errors.Count() > 0))
            {
                taskInstance.HasWarnings++;
                taskInstance.IsSuccessfullyCompleted = true;
                TaskInstanceStop(taskInstance);

                // All elements was executed but errors occurred
                return new TaskExecuteResultModel
                {
                    Message = "Task executed with errors.",
                    IsSuccessfullyCompleted = true,
                    Errors = GetErrorsFromResults(elementsResult),
                    SourceId = taskToExecute.Id.ToString(),
                    MessageType = MessageTypeEnum.Warning
                };
            }

            taskInstance.IsSuccessfullyCompleted = true;
            TaskInstanceStop(taskInstance);

            return new TaskExecuteResultModel
            {
                Message = $"Task Completed. {elementsToExecute.Count()} elements executed.",
                IsSuccessfullyCompleted = true,
                SourceId = taskToExecute.Id.ToString(),
                MessageType = MessageTypeEnum.Info
            };
        }

        private static string[] GetErrorsFromResults <T> (List<T> elementsResult) where T : IExecuteResult
        {
            return elementsResult.Where(x => x.Errors != null).SelectMany(x => x.Errors).ToArray();
        }

        #endregion

        /// <summary>
        /// Executes the element.
        /// </summary>
        /// <param name="mainObject">The context (from the Main Object).</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns></returns>
        public IExtensionExecuteResult ExecuteElement(IMainObjectModel mainObject, IExecutableElementModel executableElement, ITaskInstanceModel taskInstance)
        {
            if (mainObject == null) return new ExtensionExecuteResultModel
            {
                IsSuccessfullyCompleted = false,
                Message = $"Can not execute the Element.",
                Errors = new string[] { "Execution context cannot be null." },
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
                return executeElement(mainObject, executableElement, taskInstance);
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

        /// <summary>
        /// Executes the task.
        /// </summary>
        /// <param name="taskToExecute">The task to execute.</param>
        /// <param name="jobInstance">The job instance.</param>
        /// <returns></returns>
        public ITaskExecuteResult ExecuteTask(ITaskModel taskToExecute, IJobInstanceModel jobInstance)
        {
            if (taskToExecute.MainObject == null) return new TaskExecuteResultModel
            {
                Message = $"Cannot execute the Task '{taskToExecute.Id}'.",
                IsSuccessfullyCompleted = false,
                Errors = new string[] { "The Main Object can not be null." },
                SourceId = taskToExecute.Id.ToString(),
                MessageType = MessageTypeEnum.Error                
            };

            try
            {
                return executeTask(taskToExecute, jobInstance);
            }
            catch (Exception ex)
            {
                return new TaskExecuteResultModel
                {
                    IsSuccessfullyCompleted = false,
                    Message = $"Error executing the Task'{taskToExecute.Id}'.",
                    Errors = new string[] { $"Error executing the Task. {ex.Message}" },
                    SourceId = taskToExecute.Id.ToString(),
                    MessageType = MessageTypeEnum.Fatal
                };
            }
        }

        /// <summary>
        /// Executes the job.
        /// </summary>
        /// <param name="jobToExecute">The job to execute.</param>
        /// <returns></returns>
        public IJobExecuteResult ExecuteJob(IJobModel jobToExecute)
        {
            var jobInstance = JobInstanceStart(jobToExecute);
            var tasksToExecute = jobToExecute.Tasks.Where(x => x.IsActive);
            var taskResults = new List<ITaskExecuteResult>();
            foreach (var task in tasksToExecute)
            {
                var currentTaskResult = ExecuteTask(task, jobInstance);
                taskResults.Add(currentTaskResult);

                if (currentTaskResult.MessageType == MessageTypeEnum.Error && task.StopParentIfErrorOccurs)
                {
                    jobInstance.HasErrors++;
                    // we have to stop the job and send back an error result
                    return new JobExecuteResultModel
                    {
                        Message = $"Job Failed. The task '{task.Name}' ({task.Id}) failed to execute and aborts the parent job.",
                        IsSuccessfullyCompleted = false,
                        Errors = GetErrorsFromResults(taskResults),
                        SourceId = jobToExecute.Id.ToString(),
                        MessageType = MessageTypeEnum.Error
                    };
                }

                if (currentTaskResult.MessageType == MessageTypeEnum.Warning && task.StopParentIfWarningOccurs)
                {
                    // we have to stop the job and send back an error result
                    jobInstance.HasErrors++;
                    return new JobExecuteResultModel
                    {
                        Message = $"Job Failed. The task '{task.Name}' ({task.Id}) has at least a warn and aborts the parent task.",
                        IsSuccessfullyCompleted = false,
                        Errors = GetErrorsFromResults(taskResults),
                        SourceId = jobToExecute.Id.ToString(),
                        MessageType = MessageTypeEnum.Error
                    };
                }
            }
      

            if (taskResults.Any(x =>x!=null && x.Errors.Count() > 0))
            {
                // All tasks was executed but errors occurred
                jobInstance.HasWarnings++;
                jobInstance.IsSuccessfullyCompleted = true;
                JobInstanceStop(jobInstance);

                return new JobExecuteResultModel
                {
                    Message = "Job executed with errors.",
                    IsSuccessfullyCompleted = true,
                    Errors = GetErrorsFromResults(taskResults),
                    SourceId = jobToExecute.Id.ToString(),
                    MessageType = MessageTypeEnum.Warning
                };
            }

            jobInstance.IsSuccessfullyCompleted = true;
            JobInstanceStop(jobInstance);

            return new JobExecuteResultModel
            {
                Message = $"Job Completed. {tasksToExecute.Count()} tasks executed.",
                IsSuccessfullyCompleted = true,
                SourceId = jobToExecute.Id.ToString(),
                MessageType = MessageTypeEnum.Info
            };

        }
    }
}
