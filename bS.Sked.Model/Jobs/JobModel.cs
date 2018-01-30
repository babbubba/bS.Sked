using bS.Sked.Model.Interfaces.Jobs;
using System;
using System.Collections.Generic;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Tasks;
using bS.Sked.Model.Interfaces.Triggers;
using FluentNHibernate.Mapping;
using bS.Sked.Model.Elements;
using bS.Sked.Model.Tasks;
using bS.Sked.Model.Triggers;

namespace bS.Sked.Model.Jobs
{
    public class JobModel : IJobModel
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
        public virtual IEmailComponentModel EmailComponent { get; set; }
        public virtual Guid Id { get; set; }
        /// <summary>
        /// Gets or sets the instances.
        /// </summary>
        /// <value>
        /// The instances.
        /// </value>
        public virtual IList<IJobInstanceModel> Instances { get; set; }
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
        public virtual IList<ITaskModel> Tasks { get; set; }
        /// <summary>
        /// Gets or sets the triggers.
        /// </summary>
        /// <value>
        /// The triggers.
        /// </value>
        public virtual IList<ITriggerModel> Triggers { get; set; }
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
    }

    class JobModelMap : ClassMap<JobModel>
    {
        public JobModelMap()
        {
            Table(nameof(Jobs));
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.CreationDate);
            Map(x => x.Description);
            References<EmailComponentModel>(x => x.EmailComponent);
            HasMany<JobInstanceModel>(x => x.Instances);//.KeyColumn("fkTaskId");
            Map(x => x.IsActive);
            Map(x => x.IsExecuting);
            Map(x => x.LastExecution);
            Map(x => x.Name);
            Map(x => x.NextExecutionDate);
            Map(x => x.Position);
            HasMany<TaskModel>(x => x.Tasks);
            //HasMany<TriggerModel>(x => x.Triggers);
            HasManyToMany<TriggerModel>(x => x.Triggers).Cascade.All().Table("JobsTriggers");
            Map(x => x.UpdateDate);

            Map(x => x.SendMailOnSuccess);
            Map(x => x.SendMailOnWarning);
            Map(x => x.SendMailOnError);
            Map(x => x.IsDebug);

        }

    }
}
