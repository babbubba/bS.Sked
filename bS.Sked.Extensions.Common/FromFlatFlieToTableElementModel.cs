using System;
using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.Elements.Properties;
using bS.Sked.Model.Interfaces.Elements.Properties;
using FluentNHibernate.Mapping;

namespace bS.Sked.Extensions.Common
{
    public class FromFlatFlieToTableElementModel : ExecutableElementBaseModel, IInputFileObject, IOutputTableObject
    {
        public virtual int SkipStartingRows { get; set; }
        public virtual char? SeparatorValue { get; set; }
        public virtual int LimitToRows { get; set; }


        #region Properties
        public virtual IFileObject InFileObject { get; set; }
        public virtual ITableObject OutTableObject { get; set; } 
        #endregion
    }

    class FromFlatFlieToTableElementModelMap : SubclassMap<FromFlatFlieToTableElementModel>
    {
        public FromFlatFlieToTableElementModelMap()
        {
            DiscriminatorValue(StaticContent.fromFlatFlieToTable);
            Map(x => x.SkipStartingRows);
            Map(x => x.SeparatorValue);
            Map(x => x.LimitToRows);
        }
    }

}
