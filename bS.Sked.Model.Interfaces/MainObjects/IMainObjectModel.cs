using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.MainObjects
{
    public interface IMainObjectModel : IPersisterEntity  , IToggledEntity, IDescribedEntity, IHistoricalEntity
    {
        IMainObjectTypeModel MainObjectType { get; set; }

        /// <summary>
        /// Initialize the context if needed. It has to be executed only the first time it has called.
        /// </summary>
        /// <returns>It returns true if initialization succes or if it was already initialized otherwise it returns false.</returns>
        bool InitializeContext();
        /// <summary>
        /// Finalizes the context.
        /// </summary>
        /// <returns></returns>
        bool FinalizeContext();

        /// <summary>
        /// Gets or sets the elements in this context.
        /// </summary>
        /// <value>
        /// The elements.
        /// </value>
        IList<Elements.IExecutableElementModel> Elements { get; set; }

    }
}
