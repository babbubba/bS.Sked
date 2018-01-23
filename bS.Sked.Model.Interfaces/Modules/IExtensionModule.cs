using bS.Sked.Model.Interfaces.DTO;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Modules
{
    /// <summary>
    /// The interface of all Extension Modules. This permits the common Extensions functionality to work in the executers.
    /// </summary>
    public interface IExtensionModule
    {
        /// <summary>
        /// Determines whether the specified executable element persisting identifier is supported by the module (final class) that implements this interface.
        /// </summary>
        /// <param name="executableElementPersistingId">The executable element persisting identifier.</param>
        /// <returns>
        ///   <c>true</c> if the specified executable element persisting identifier is supported by the module (final class) that implements this interface; otherwise, <c>false</c>.
        /// </returns>
        bool IsSupported(string executableElementPersistingId);
        /// <summary>
        /// Determines whether the specified executable element persisting identifier is implemented by the module (final class) that implements this interface.
        /// </summary>
        /// <param name="executableElementPersistingId">The executable element persisting identifier.</param>
        /// <returns>
        ///   <c>true</c> if the specified executable element persisting identifier is implemented by the module (final class) that implements this interface; otherwise, <c>false</c>.
        /// </returns>
        bool IsImplemented(string executableElementPersistingId);
        /// <summary>
        /// Executes the specified executable element in the specified extension's context.
        /// </summary>
        /// <param name="context">The extension's context.</param>
        /// <param name="executableElement">The executable element.</param>
        /// <returns>The result of the execution.</returns>
        IExtensionExecuteResult Execute(IExtensionContext context, IExecutableElementModel executableElement);

        /// <summary>
        /// Adds the specified executable element to the database.
        /// </summary>
        /// <param name="elementPID">The element persisting identifier.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        IExecutableElementBaseViewModel AddElement(string elementPID, IDictionary<string, IField> properties);
        /// <summary>
        /// Edits the specified executable element in the database.
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <param name="elementPID">The element persisting identifier.</param>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        IExecutableElementBaseViewModel EditElement(string elementId, string elementPID, IDictionary<string, IField> properties);
        /// <summary>
        /// Deletes the specified executable element from the database..
        /// </summary>
        /// <param name="elementId">The element identifier.</param>
        /// <param name="elementPID">The element persisting identifier.</param>
        void DeleteElement(string elementId, string elementPID);

    }
}
