using System;

namespace bS.Sked.Model.Interfaces.Entities.Base
{
    public interface IHistoricalEntity
    {
        /// <summary>
        /// Gets or sets the creation date of the object.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        DateTime CreationDate { get; set; }
        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        DateTime? UpdateDate { get; set; }
    }
}
