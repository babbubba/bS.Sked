using bS.Sked.Model.Interfaces.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
using bS.Sked.Model.Interfaces.DTO;
using Common.Logging;

namespace bS.Sked.Model.Modules
{
    /// <summary>
    /// The base class for all the Extension Modules. This permits the common Extensions functionality to work in the executers.
    /// </summary>
    /// <seealso cref="bS.Sked.Model.Interfaces.Modules.IExtensionModule" />
    public abstract class ModuleBase : IExtensionModule
    {
        protected static ILog log = LogManager.GetLogger<ModuleBase>();

        /// <summary>
        /// The supported element types strings array. You have to populate it in the constructor of the derived class.
        /// </summary>
        protected string[] supportedElementTypes;
        /// <summary>
        /// The implemented element types strings array. You have to populate it in the constructor of the derived class.
        /// </summary>
        protected string[] implementedElementTypes;

        public ModuleBase()
        {
        }


        /// <summary>
        /// Determines whether the specified executable element persisting identifier is supported by the module (final class) that implements this interface.
        /// </summary>
        /// <param name="executableElementPersistingId">The executable element persisting identifier.</param>
        /// <returns>
        /// <c>true</c> if the specified executable element persisting identifier is supported by the module (final class) that implements this interface; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsSupported(string executableElementPersistingId)
        {
            return supportedElementTypes?.Contains(executableElementPersistingId) ?? false;
        }
        /// <summary>
        /// Determines whether the specified executable element persisting identifier is implemented by the module (final class) that implements this interface.
        /// </summary>
        /// <param name="executableElementPersistingId">The executable element persisting identifier.</param>
        /// <returns>
        /// <c>true</c> if the specified executable element persisting identifier is implemented by the module (final class) that implements this interface; otherwise, <c>false</c>.
        /// </returns>
        public virtual bool IsImplemented(string executableElementPersistingId)
        {
            return implementedElementTypes?.Contains(executableElementPersistingId) ?? false;
        }


        /// <summary>
        /// Executes the specified executable element in the specified extension's context.
        /// </summary>
        /// <param name="context">The extension's context.</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns>
        /// The result of the execution.
        /// </returns>
        public abstract IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement, IElementInstanceModel elementInstance);


        /// <summary>
        /// Get the element with the id and the persistent id specified.
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <param name="elementPID">The element pid.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public abstract IExecutableElementBaseViewModel ElementGet(string elementId, string elementPID);
        /// <summary>
        /// Adds the specified executable element to the database.
        /// </summary>
        /// <param name="elementPID">The element persisting identifier.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public abstract IExecutableElementBaseViewModel ElementAdd(string elementPID, IDictionary<string, IField> properties);
        /// <summary>
        /// Edits the specified executable element in the database.
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <param name="elementPID">The element persisting identifier.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        public abstract IExecutableElementBaseViewModel ElementEdit(string elementId, string elementPID, IDictionary<string, IField> properties);
        /// <summary>
        /// Deletes the specified executable element from the database..
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <param name="elementPID">The element persisting identifier.</param>
        public abstract void ElementDelete(string elementId, string elementPID);

     
    }
}
