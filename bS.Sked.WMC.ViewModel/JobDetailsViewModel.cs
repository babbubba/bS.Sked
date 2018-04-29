using System;
using System.Collections.Generic;
using System.Text;

namespace bS.Sked.WMC.ViewModel
{
    public class JobDetailsViewModel
    {
        /// <summary>
        /// Gets or sets the creation date of the object.
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public virtual DateTime CreationDate { get; set; }
        /// <summary>
        /// Gets or sets a short description for the object.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public virtual string Description { get; set; }
        /// <summary>
        /// Gets or sets the email component.
        /// </summary>
        /// <value>
        /// The email component.
        /// </value>
        public virtual string EmailComponentId { get; set; }
        public virtual string Id { get; set; }
  
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsActive { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is executing.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is executing; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsExecuting { get; set; }
        /// <summary>
        /// Gets or sets the last execution time of this object.
        /// </summary>
        /// <value>
        /// The last execution.
        /// </value>
        public virtual DateTime LastExecution { get; set; }
        /// <summary>
        /// Gets or sets the friendly name for the object.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public virtual string Name { get; set; }
        /// <summary>
        /// Gets or sets the next execution date.
        /// </summary>
        /// <value>
        /// The next execution date.
        /// </value>
        public virtual DateTime? NextExecutionDate { get; set; }
        /// <summary>
        /// Gets or sets the position in a collection.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public virtual int Position { get; set; }
        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        //public virtual IList<ITaskModel> Tasks { get; set; }
        /// <summary>
        /// Gets or sets the triggers.
        /// </summary>
        /// <value>
        /// The triggers.
        /// </value>
        //public virtual IList<ITriggerModel> Triggers { get; set; }
        /// <summary>
        /// Gets or sets the update date.
        /// </summary>
        /// <value>
        /// The update date.
        /// </value>
        public virtual DateTime? UpdateDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [send mail on success].
        /// </summary>
        /// <value>
        /// <c>true</c> if [send mail on success]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool SendMailOnSuccess { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [send mail on warning].
        /// </summary>
        /// <value>
        /// <c>true</c> if [send mail on warning]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool SendMailOnWarning { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [send mail on error].
        /// </summary>
        /// <value>
        /// <c>true</c> if [send mail on error]; otherwise, <c>false</c>.
        /// </value>
        public virtual bool SendMailOnError { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is debug.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is debug; otherwise, <c>false</c>.
        /// </value>
        public virtual bool IsDebug { get; set; }

        public virtual List<TaskTeaserViewModel> Tasks { get; set; }
    }
}
