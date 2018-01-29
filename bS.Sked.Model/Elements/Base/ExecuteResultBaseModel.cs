using bS.Sked.Model.Interfaces.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bS.Sked.Model.Interfaces.Entities.Base;
using FluentNHibernate.Mapping;
using bS.Sked.Model.Interfaces.Elements;

namespace bS.Sked.Model.Elements.Base
{
    public abstract class ExecuteResultBaseModel : IExecuteResultBaseModel
    {
        public ExecuteResultBaseModel()
        {
            CreationDate = DateTime.UtcNow;
        }

        public virtual bool IsSuccessfullyCompleted { get; set; }
        public virtual string Message { get; set; }
        public virtual string[] Errors { get; set; }
        public virtual string[] Warns { get; set; }
        public virtual string SourceId { get; set; }
        public virtual MessageTypeEnum MessageType { get; set; }
        public virtual Guid Id { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
    }

    class ExecuteResultBaseModelMap : ClassMap<ExecuteResultBaseModel>
    {
        public ExecuteResultBaseModelMap()
        {
            Table("InstanceMessages");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.IsSuccessfullyCompleted);
            Map(x => x.Message);
            Map(x => x.Errors);
            Map(x => x.Warns);
            Map(x => x.SourceId);
            Map(x => x.MessageType);
            Map(x => x.CreationDate);
            Map(x => x.UpdateDate);
            DiscriminateSubClassesOnColumn("InstanceMessageType");
        }
    }
}
