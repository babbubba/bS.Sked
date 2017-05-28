using bS.Sked.Models.Interfaces.MainObjects;
using FluentNHibernate.Mapping;
using System;

namespace bS.Sked.Models.MainObjects.Base
{
    public class MainObjectBaseModel : IMainObjectModel
    {
        public virtual DateTime CreationDate { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IMainObjectTypeModel MainObjectType { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
    }

    class MainObjectBaseModelMap : ClassMap<MainObjectBaseModel>
    {
        public MainObjectBaseModelMap()
        {
            Table(nameof(MainObjects));
            Id(x => x.Id).GeneratedBy.GuidComb().Column("Id");
            Map(x => x.CreationDate);
            Map(x => x.Description);
            Map(x => x.IsActive);
            References<MainObjectTypeModel>(x => x.MainObjectType);
            Map(x => x.Name);
            Map(x => x.UpdateDate);
        }

    }
}
