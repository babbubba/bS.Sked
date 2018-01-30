using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Tasks;
using bS.Sked.Model.Interfaces.Triggers;
using System;
using System.Collections.Generic;

namespace bS.Sked.Model.Interfaces.Jobs
{
    public interface IJobModel : IPersisterEntity, IExecutableEntity, IHistoricalEntity, IToggledEntity, IDescribedEntity, IPositionalEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is executing.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is executing; otherwise, <c>false</c>.
        /// </value>
        bool IsExecuting { get; set; }
        /// <summary>
        /// Gets or sets the tasks.
        /// </summary>
        /// <value>
        /// The tasks.
        /// </value>
        IList<ITaskModel> Tasks { get; set; }
        /// <summary>
        /// Gets or sets the instances.
        /// </summary>
        /// <value>
        /// The instances.
        /// </value>
        IList<IJobInstanceModel> Instances { get; set; }
        /// <summary>
        /// Gets or sets the email component.
        /// </summary>
        /// <value>
        /// The email component.
        /// </value>
        IEmailComponentModel EmailComponent { get; set; }
        /// <summary>
        /// Gets or sets the triggers.
        /// </summary>
        /// <value>
        /// The triggers.
        /// </value>
        IList<ITriggerModel> Triggers { get; set; }
        /// <summary>
        /// Gets or sets the next execution date.
        /// </summary>
        /// <value>
        /// The next execution date.
        /// </value>
        DateTime? NextExecutionDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [send mail on success].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [send mail on success]; otherwise, <c>false</c>.
        /// </value>
        bool SendMailOnSuccess { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [send mail on warning].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [send mail on warning]; otherwise, <c>false</c>.
        /// </value>
        bool SendMailOnWarning { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether [send mail on error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [send mail on error]; otherwise, <c>false</c>.
        /// </value>
        bool SendMailOnError { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is debug.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is debug; otherwise, <c>false</c>.
        /// </value>
        bool IsDebug { get; set; }




    }
}
