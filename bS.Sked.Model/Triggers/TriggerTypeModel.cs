using bS.Sked.Model.Interfaces.Triggers;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Triggers
{
   public  class TriggerTypeModel : ITriggerTypeModel
    {
        public virtual string Description { get; set; }

        public virtual Guid Id { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string Name { get; set; }

        public virtual string PersistingId { get; set; }

        public virtual int Position { get; set; }
    }

    class TriggerTypeModelMap : ClassMap<TriggerTypeModel>
    {
        public TriggerTypeModelMap()
        {
            Table("TriggerTypes");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.Description);
            Map(x => x.IsActive);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.PersistingId).Not.Nullable().Unique();
            Map(x => x.Position).Not.Nullable();
        }
    }
}
