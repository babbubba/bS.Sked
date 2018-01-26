using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.MainObjects;
using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.Interfaces.Tasks;
using bS.Sked.Model.MainObjects.Base;
using bS.Sked.Model.Tasks;
using bS.Sked.Services.Base;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
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

        public ITaskModel TaskAdd(string taskName, string description = null)
        {
            var newTask = new TaskModel
            {
                Name = taskName,
                Description = description
            };

            _repository.Add(newTask);

            return newTask;
        }

        public ITaskModel MainObjectSet(string taskId, string mainObjectId)
        {
            var t = _repository.BeginTransaction();
            var task = _repository.GetQuery<ITaskModel>().Single(x => x.Id == Guid.Parse(taskId));
            var mainObject = _repository.GetQuery<IMainObjectModel>().Single(x => x.Id == Guid.Parse(mainObjectId));
            task.MainObject = mainObject;
            t.Commit();
            return task;
        }

        public ITaskModel ElementToTaskAdd(string taskId, string elementId)
        {
            var t = _repository.BeginTransaction();
            var task = _repository.GetQuery<ITaskModel>().Single(x => x.Id == Guid.Parse(taskId));
            var element = _repository.GetQuery<IExecutableElementModel>().Single(x => x.Id == Guid.Parse(elementId));
            task.Elements.Add(element);
            t.Commit();
            return task;
        }

        public IExecutableMainObjectBaseViewModel MainObjectCreate(string mainObjecPersistingId, IDictionary<string, Model.Interfaces.DTO.IField> properties)
        {
            var module = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExtensionModule>>().SingleOrDefault(x => x.IsImplemented(mainObjecPersistingId));
            return module.MainObjectAdd(mainObjecPersistingId, properties);
        }
    }
}
