using bS.Sked.Model.Interfaces.Entities.Base;
using FluentNHibernate.Mapping;
using System;

namespace bS.Sked.Model.Elements.Base
{
    public abstract class ExecutableInstanceModel : IExecutableInstanceModel
    {
        public virtual DateTime? EndTime { get; set; }

        public virtual int HasErrors { get; set; }

        public virtual int HasWarnings { get; set; }

        public virtual Guid Id { get; set; }

        public virtual bool IsSuccessfullyCompleted { get; set; }

        public virtual DateTime LastExecution { get; set; }

        public virtual string PersistingFullPath { get; set; }

        public virtual int Progress { get; set; }

        public virtual DateTime? StartTime { get; set; }
    }

    class ExecutableInstanceModelMap : ClassMap<ExecutableInstanceModel>
    {
        public ExecutableInstanceModelMap()
        {
            Table("Instances");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.EndTime);
            Map(x => x.HasErrors);
            Map(x => x.HasWarnings);
            Map(x => x.IsSuccessfullyCompleted);
            Map(x => x.LastExecution);
            Map(x => x.PersistingFullPath);
            Map(x => x.Progress);
            Map(x => x.StartTime);
            DiscriminateSubClassesOnColumn("InstanceType");
        }
    }
}
