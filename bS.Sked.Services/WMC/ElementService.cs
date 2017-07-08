using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
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

        public void AddNewElement(IExecutableElementBaseViewModel element)
        {

        }
    }
}
