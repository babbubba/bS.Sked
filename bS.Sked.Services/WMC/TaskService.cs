using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.MainObjects;
using bS.Sked.Model.Interfaces.Tasks;
using bS.Sked.Model.Tasks;
using bS.Sked.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Services.WMC
{
  public   class TaskService : ServiceBase
    {
        private IRepository<IPersisterEntity> _repository;

        public TaskService(IRepository<IPersisterEntity> repository)
        {
            _repository = repository;
        }

        public ITaskModel AddNewTask(string taskName)
        {
            var newTask = new TaskModel
            {
                Name = taskName
            };

            _repository.Add(newTask);

            return newTask;
        }

        public ITaskModel SetMainObject(string taskId, IMainObjectModel mainObject)
        {
            var t = _repository.BeginTransaction();
            var task = _repository.GetQuery<ITaskModel>().Single(x => x.Id == Guid.Parse(taskId));
            task.MainObject = mainObject;
            t.Commit();
            return task;
        }

        public ITaskModel AddElementToTask(string taskId, string elementId)
        {
            var t = _repository.BeginTransaction();
            var task = _repository.GetQuery<ITaskModel>().Single(x => x.Id == Guid.Parse(taskId));
            var element = _repository.GetQuery<IExecutableElementModel>().Single(x => x.Id == Guid.Parse(elementId));
            task.Elements.Add(element);
            t.Commit();
            return task;
        }
    }
}
