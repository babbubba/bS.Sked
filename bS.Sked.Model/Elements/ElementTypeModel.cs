using bS.Sked.Model.Interfaces.Elements;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Model.Elements
{
    public class ElementTypeModel : IElementTypeModel
    {
        public virtual string Description { get; set; }

        public virtual Guid Id { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string Name { get; set; }

        public virtual string PersistingId { get; set; }

        public virtual int Position { get; set; }

        public virtual string InputProperties { get; set; }
        public virtual string OutputProperties { get; set; }
    }

    class ElementTypeModelMap : ClassMap<ElementTypeModel>
    {
        public ElementTypeModelMap()
        {
            Table("ElementTypes");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.Description);
            Map(x => x.IsActive);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.PersistingId).Not.Nullable().Unique();
            Map(x => x.Position).Not.Nullable();
            Map(x => x.InputProperties);
            Map(x => x.OutputProperties);

        }
    }
}
