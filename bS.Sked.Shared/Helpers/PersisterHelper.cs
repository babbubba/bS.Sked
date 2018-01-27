using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Shared.Helpers
{
    public class PersisterHelper
    {
        private readonly IRepository<IPersisterEntity> _repository;

        public PersisterHelper(IRepository<IPersisterEntity> repository)
        {
            _repository = repository;
        }


        public  IExecutableElementBaseViewModel addNewElementGeneric<ViewModel, Model>(IExecutableElementBaseViewModel element)
            where Model : class, IPersisterEntity
            where ViewModel : IExecutableElementBaseViewModel
        {
            var model = AutoMapper.Mapper.Map<Model>(element);
            _repository.Add(model);
            element = AutoMapper.Mapper.Map<ViewModel>(model);
            return element;
        }
        public  IExecutableElementBaseViewModel editElementGeneric<ViewModel, Model>(ViewModel vm)
               where Model : class, IPersisterEntity
            where ViewModel : IExecutableElementBaseViewModel
        {
            var model = _repository.GetQuery<IExecutableElementModel>().Single(x => x.Id == Guid.Parse(vm.Id));
            AutoMapper.Mapper.Map(vm, model);
            _repository.Update(model);
            vm = AutoMapper.Mapper.Map<ViewModel>(model);
            return vm;
        }
        public void deleteElementGeneric<ViewModel, Model>(ViewModel vm)
               where Model : class, IPersisterEntity
            where ViewModel : IExecutableElementBaseViewModel
        {
            var model = _repository.GetQuery<IExecutableElementModel>().Single(x => x.Id == Guid.Parse(vm.Id));
            _repository.Delete(model);
        }
        public  IExecutableMainObjectBaseViewModel addNewMainObjectGeneric<ViewModel, Model>(IExecutableMainObjectBaseViewModel mainObject)
            where Model : class, IPersisterEntity
            where ViewModel : IExecutableMainObjectBaseViewModel
        {
            var model = AutoMapper.Mapper.Map<Model>(mainObject);
            _repository.Add(model);
            mainObject = AutoMapper.Mapper.Map<ViewModel>(model);
            return mainObject;
        }
    }
}
