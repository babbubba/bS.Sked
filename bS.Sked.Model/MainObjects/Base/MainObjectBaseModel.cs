using bS.Sked.Model.Interfaces.MainObjects;
using FluentNHibernate.Mapping;
using System;
using bS.Sked.Model.Interfaces.Elements;
using System.Collections.Generic;

namespace bS.Sked.Model.MainObjects.Base
{
    /// <summary>
    /// Base Entity for Main Object Models
    /// </summary>
    /// <seealso cref="bS.Sked.Model.Interfaces.MainObjects.IMainObjectModel" />
    public class MainObjectBaseModel : IMainObjectModel
    {
        public MainObjectBaseModel()
        {
            Elements = new List<IExecutableElementModel>();
        }
        public virtual DateTime CreationDate { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid Id { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IMainObjectTypeModel MainObjectType { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime? UpdateDate { get; set; }
        public virtual IList<IExecutableElementModel> Elements { get; set; }

        public virtual bool FinalizeContext()
        {
            return true;
        }

        public virtual bool InitializeContext()
        {
            return true;
        }
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
