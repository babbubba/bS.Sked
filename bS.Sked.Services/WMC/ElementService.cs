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

        public IExecutableElementBaseViewModel AddNewElement(string elementPID, IDictionary<string, IField> parameters)
        {
            var module = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExtensionModule>>().SingleOrDefault(x=>x.IsImplemented(elementPID));
            //return module.AddNewElement(element);
            return module.AddElement(elementPID, parameters);
            //  Mapper.Map<ExecutableElementBaseModel>(element);

        }
    }
}
