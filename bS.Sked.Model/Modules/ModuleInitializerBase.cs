using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Interfaces.Elements;
using Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Modules
{
    public abstract class ModuleInitializerBase : IExtensionModuleInitializer
    {
        private static ILog log = LogManager.GetLogger<ModuleInitializerBase>();

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
           

        public abstract bool InitContextTypes();

        public virtual bool InitElementTypes()
        {
            try
            {
                var transaction = _repository.BeginTransaction();

                var query = _repository.GetQuery<IElementTypeModel>();
                foreach (var elementType in _supportedElements)
                {
                    if (!query.Any(x => x.PersistingId == elementType.Key)) InitElementType(elementType.Key, elementType.Value, query);
                }

                transaction.Commit();

            }
            catch (Exception ex)
            {
                log.Error("Error initializing element types.", ex);
                return false;
            }
            return true;
        }

        protected virtual void InitElementType(string elementTypePID, string elementTypeName, IQueryable<IElementTypeModel> query)
        {
            var newElementType = new ElementTypeModel
            {
                PersistingId = elementTypePID,
                IsActive = true,
                Position = (query.Any()) ? query.Max(x => x.Position) + 1 : 0,
                Name = elementTypeName
            };
            _repository.Add(newElementType);
        }

    }
}
