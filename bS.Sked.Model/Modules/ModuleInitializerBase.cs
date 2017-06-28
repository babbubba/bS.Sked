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
        protected Dictionary<string,string> _supportedElements;

        public ModuleInitializerBase(IRepository<IPersisterEntity> repository)
        {
            _repository = repository;
        }

        public Dictionary<string, string> SupportedElements
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
                    if (!query.Any(x => x.PersistingId == elementType.Key)) initElementType(elementType, query);
                }

                transaction.Commit();

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        protected virtual void initElementType(KeyValuePair<string,string> elementType, IQueryable<IElementTypeModel> query)
        {
            var newElementType = new ElementTypeModel
            {
                PersistingId = elementType.Key,
                IsActive = true,
                Position = (query.Any()) ? query.Max(x => x.Position) + 1 : 0,
                Name = elementType.Value
            };
            _repository.Add(newElementType);
        }

    }
}
