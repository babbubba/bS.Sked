using bS.Sked.Models.Interfaces.Triggers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using bS.Sked.Models.Interfaces.Jobs;
using bS.Sked.Models.Jobs;

namespace bS.Sked.Models.Triggers
{
    public abstract class TriggerModel : ITriggerModel
    {
        public virtual  DateTime CreationDate { get; set; }

        public virtual string Description { get; set; }

        public virtual Guid Id { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual IList<IJobModel> Jobs { get; set; }

        public virtual DateTime LastExecution { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime? NextExecutionDate { get; set; }

        public virtual ITriggerTypeModel TriggerType { get; set; }

        public virtual DateTime? UpdateDate { get; set; }

        public abstract string GetCron();
    }


    class TriggerModelMap : ClassMap<TriggerModel>
    {
        public TriggerModelMap()
        {
            Table(nameof(Triggers));
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.CreationDate);
            Map(x => x.Description);
            HasManyToMany<JobModel>(x => x.Jobs).Inverse().Table("JobsTriggers");
            Map(x => x.IsActive);
            Map(x => x.LastExecution);
            Map(x => x.Name);
            Map(x => x.NextExecutionDate);
            References<TriggerTypeModel>(x => x.TriggerType);
            Map(x => x.UpdateDate);

        }
    }
}
