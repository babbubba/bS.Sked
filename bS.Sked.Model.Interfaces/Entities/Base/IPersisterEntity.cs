using System;

namespace bS.Sked.Model.Interfaces.Entities.Base
{
    public interface IPersisterEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier (GUID).
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        Guid Id { get; set; }
    }
}
