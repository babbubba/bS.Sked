using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Interfaces.Entities.Base
{
    /// <summary>
    /// Base message returned by Extensions, Element, Task and Job after execution.
    /// </summary>
    public interface IExecuteResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is successfully completed.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is successfully completed; otherwise, <c>false</c>.
        /// </value>
        bool IsSuccessfullyCompleted { get; set; }
        /// <summary>
        /// Gets or sets the resultant message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        string Message { get; set; }
        /// <summary>
        /// Gets or sets the errors (optional).
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        string[] Errors { get; set; }

        /// <summary>
        /// Gets or sets the source identifier for the specified object executed.
        /// </summary>
        /// <value>
        /// The source identifier.
        /// </value>
        string SourceId { get; set; }


    }
}
