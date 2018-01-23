using AutoMapper;
using bS.Sked.CompositionRoot;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.Interfaces.DTO;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Services.Base;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Services.WMC
{
    public class ElementService : ServiceBase
    {
        private IRepository<IPersisterEntity> _repository;

        public ElementService(IRepository<IPersisterEntity> repository)
        {
            _repository = repository;
        }



        //Element All, Get, Add, Update, Delete
        public List<IExecutableElementBaseViewModel> ElementAll()
        {
            var elements = _repository.GetQuery<ExecutableElementBaseModel>();
            var elementsVM = AutoMapper.Mapper.Map<List<IExecutableElementBaseViewModel>>(elements);
            return elementsVM;
        }
        public IExecutableElementBaseViewModel ElementGet(string elementId, string elementPID)
        {
            var module = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExtensionModule>>().SingleOrDefault(x => x.IsImplemented(elementPID));
            return module.ElementGet(elementId, elementPID);
        }

        public IExecutableElementBaseViewModel ElementAdd(string elementPID, IDictionary<string, IField> fields)
        {
            var module = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExtensionModule>>().SingleOrDefault(x=>x.IsImplemented(elementPID));
            return module.ElementAdd(elementPID, fields);
        }

        public IExecutableElementBaseViewModel ElementEdit(string elementId, string elementPID, IDictionary<string, IField> fields)
        {
            var module = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExtensionModule>>().SingleOrDefault(x => x.IsImplemented(elementPID));
            return module.ElementEdit(elementId, elementPID, fields);
        }

        public void ElementDelete(string elementId, string elementPID)
        {
            var module = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExtensionModule>>().SingleOrDefault(x => x.IsImplemented(elementPID));
            module.ElementDelete(elementId, elementPID);
        }



    }
}
