using bS.Sked.Models.Interfaces.Jobs;
using System;
using System.Collections.Generic;
using bS.Sked.Models.Interfaces.Elements;
using bS.Sked.Models.Interfaces.Tasks;
using bS.Sked.Models.Interfaces.Triggers;
using FluentNHibernate.Mapping;
using bS.Sked.Models.Elements;
using bS.Sked.Models.Tasks;
using bS.Sked.Models.Triggers;

namespace bS.Sked.Models.Jobs
{
    public class JobModel : IJobModel
    {
        public virtual DateTime CreationDate { get; set; }
        public virtual string Description { get; set; }
        public virtual IEmailComponentModel EmailComponent { get; set; }
        public virtual Guid Id { get; set; }
        public virtual IList<IJobInstanceModel> Instances { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsExecuting { get; set; }
        public virtual DateTime LastExecution { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime? NextExecutionDate { get; set; }
        public virtual int Position { get; set; }
        public virtual IList<ITaskModel> Tasks { get; set; }
        public virtual IList<ITriggerModel> Triggers { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
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
        }

    }
}
