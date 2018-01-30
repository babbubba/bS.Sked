using System;

namespace bS.Sked.Model.Interfaces.Entities.Base
{
    public interface IExecutableEntity
    {
        /// <summary>
        /// Gets or sets the last execution time of this object.
        /// </summary>
        /// <value>
        /// The last execution.
        /// </value>
        DateTime LastExecution { get; set; }
    }
}
