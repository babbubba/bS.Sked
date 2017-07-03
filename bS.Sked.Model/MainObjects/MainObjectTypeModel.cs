using bS.Sked.Models.Interfaces.MainObjects;
using System;
using System.Collections.Generic;
using bS.Sked.Models.Interfaces.Elements;
using FluentNHibernate.Mapping;
using bS.Sked.Models.Elements;

namespace bS.Sked.Models.MainObjects
{
    public class MainObjectTypeModel : IMainObjectTypeModel
    {
        public virtual string Description { get; set; }
        public virtual Guid Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string Name { get; set; }
        public virtual string PersistingId { get; set; }
        public virtual string InputProperties { get; set; }
        public virtual string OutputProperties { get; set; }
        public virtual IList<IElementTypeModel> SupportedElementTypes { get; set; }
    }
    class MainObjectTypeModelMap : ClassMap<MainObjectTypeModel>
    {
        public MainObjectTypeModelMap()
        {
            Table("MainObjectTypes");
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.Description);
            Map(x => x.IsActive);
            Map(x => x.Name);
            Map(x => x.PersistingId);
            Map(x => x.InputProperties);
            Map(x => x.OutputProperties);
            HasMany<ElementTypeModel>(x => x.SupportedElementTypes);

        }
    }
}