using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Interfaces.Tasks;
using System;
using System.Collections.Generic;
using bS.Sked.Model.Interfaces.Jobs;
using bS.Sked.Model.Interfaces.MainObjects;
using FluentNHibernate.Mapping;
using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.MainObjects.Base;
using bS.Sked.Model.Jobs;

namespace bS.Sked.Model.Tasks
{
    public class TaskModel : ITaskModel
    {
        public virtual DateTime CreationDate { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<IExecutableElementModel> Elements { get; set; }
        public virtual Guid Id { get; set; }
        public virtual IList<ITaskInstanceModel> Instances { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual DateTime LastExecution { get; set; }
        public virtual IMainObjectModel MainObject { get; set; }
        public virtual string Name { get; set; }
        public virtual IJobModel ParentJob { get; set; }
        public virtual int Position { get; set; }
        public virtual bool StopParentIfErrorOccurs { get; set; }
        public virtual bool StopParentIfWarningOccurs { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
    }

    class TaskModelMap : ClassMap<TaskModel>
    {
        public TaskModelMap()
        {
            Table(nameof(Tasks));
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.CreationDate);
            Map(x => x.Description);
            HasMany<ExecutableElementBaseModel>(x=> x.Elements);
            HasMany<TaskInstanceModel>(x => x.Instances);//.KeyColumn("fkTaskId");
            Map(x => x.IsActive);
            Map(x => x.LastExecution);
            References<MainObjectBaseModel>(x => x.MainObject);
            Map(x => x.Name);
            References<JobModel>(x => x.ParentJob);
            Map(x => x.Position);
            Map(x => x.StopParentIfErrorOccurs);
            Map(x => x.StopParentIfWarningOccurs);
            Map(x => x.UpdateDate);
        }

    }
}
