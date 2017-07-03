using System;
using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.Elements.Properties;
using bS.Sked.Model.Interfaces.Elements.Properties;
using FluentNHibernate.Mapping;

namespace bS.Sked.Extensions.Common
{
    public class FromFlatFlieToTableElementModel : ExecutableElementBaseModel, IInputFileObject, IOutputTableObject
    {
        public virtual string SourceFile { get; set; }
        public virtual int SkipFirstRows { get; set; }
        public virtual string SeparatorValue { get; set; }
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
            DiscriminatorValue(CommonInitializer.fromFlatFlieToTable);
            Map(x => x.SourceFile);
            Map(x => x.SkipFirstRows);
            Map(x => x.SeparatorValue);
            Map(x => x.LimitToRows);
        }
    }

}
