using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.MainObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Modules
{
    public abstract class ExecutableActionBase
    {
        protected readonly string pid;
        private readonly string name;
        private readonly string description;
        private readonly string inputProperties;
        private readonly string outputProperties;
        protected readonly IRepository<IPersisterEntity> repository;

        public ExecutableActionBase(IRepository<IPersisterEntity> repository, string pid, string name, string description,
            string InputProperties, string OutputProperties)
        {
            if (string.IsNullOrWhiteSpace(pid))
            {
                throw new ArgumentException("message", nameof(pid));
            }

            this.pid = pid;
            this.name = name;
            this.description = description;
            inputProperties = InputProperties;
            outputProperties = OutputProperties;
            this.repository = repository;
        }
        /// <summary>
        /// Determines whether the specified executable element persisting identifier is supported by the ExecutableAction (final class) that implements this interface.
        /// </summary>
        /// <param name="executableElementPid">The executable element pid.</param>
        /// <returns>
        ///   <c>true</c> if the specified executable element persisting identifier is supported by the ExecutableAction (final class) that implements this interface; otherwise, <c>false</c>.
        /// </returns>

        public virtual bool IsSupported(string executableElementPid)
        {
            return pid == executableElementPid;
        }

        /// <summary>
        /// Determines whether the specified executable element persisting identifier is implemented by the ExecutableAction (final class) that implements this interface.
        /// </summary>
        /// <param name="executableElementPid">The executable element pid.</param>
        /// <returns>
        ///   <c>true</c> if the specified executable element persisting identifier is implemented by the ExecutableAction (final class) that implements this interface; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsImplemented(string executableElementPid)
        {
            return pid == executableElementPid;
        }
        public  abstract void Execute();

        /// <summary>
        /// Executes the specified executable element in the specified extension's context.
        /// </summary>
        /// <param name="context">The extension's context.</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns>
        /// The result of the execution.
        /// </returns>
        public abstract IExecuteResultBaseModel Execute(IMainObjectModel context, IExecutableElementModel executableElement, IElementInstanceModel elementInstance);

        protected void InitElementType(IQueryable<IElementTypeModel> query)
        {
            var newElementType = new ElementTypeModel
            {
                PersistingId = pid,
                IsActive = true,
                Position = (query.Any()) ? query.Max(x => x.Position) + 1 : 0,
                Name = name,
                Description = description,
                InputProperties = inputProperties,
                OutputProperties = outputProperties
            };
            
            repository.Add(newElementType);

        }

        //CRUD Elements
        protected T GetElement<T>(string id) where T : class, IPersisterEntity
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException("Element id is mandatory.", nameof(id));
            }
            var idGuid = new Guid();
            if (!Guid.TryParse(id, out idGuid))
              {
                throw new ArgumentException("Element id has to be a valid Guid.", nameof(id));
            }

            var element = repository.GetQuery<T>().SingleOrDefault(x=>x.Id == idGuid);

            return element;
        }

        protected T CreateElement<T>(string elementJson) where T : class, IPersisterEntity
        {
            if (string.IsNullOrWhiteSpace(elementJson))
            {
                throw new ArgumentException("The Element in Json format is mandatory.", nameof(elementJson));
            }

            T result;

            try
            {
                result = JsonConvert.DeserializeObject<T>(elementJson);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("The Element in Json format is not a valid Json.", nameof(elementJson), ex);
            }

            repository.Add(result);
            return result;
        }
    }
}
