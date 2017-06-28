using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Models.Elements;
using bS.Sked.Models.Interfaces.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Modules
{
    public abstract class ModuleInitializerBase : IExtensionModuleInitializer
    {
        protected IRepository<IPersisterEntity> _repository;
        protected string[] _supportedElements;

        public ModuleInitializerBase(IRepository<IPersisterEntity> repository)
        {
            _repository = repository;
        }

        public string[] SupportedElements
        {
            get
            {
                return _supportedElements;
            }
            set
            {
                _supportedElements = value;
            }
        }

        public abstract bool InitContextModels();

        public abstract bool InitContextTypes();
              
        public virtual bool InitElementTypes()
        {
            try
            {
                var transaction = _repository.BeginTransaction();

                var query = _repository.GetQuery<IElementTypeModel>();
                foreach (var elementType in _supportedElements)
                {
                    if (!query.Any(x => x.PersistingId == elementType)) initElementType(elementType, query);
                }

                transaction.Commit();

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        protected virtual void initElementType(string elementTypePID, IQueryable<IElementTypeModel> query)
        {
            var newElementType = new ElementTypeModel
            {
                PersistingId = elementTypePID,
                IsActive = true,
                Position = (query.Any()) ? query.Max(x=> x.Position) + 1 : 0,
                Name = elementTypePID
            };
            _repository.Add(newElementType);
        }

    }
}
