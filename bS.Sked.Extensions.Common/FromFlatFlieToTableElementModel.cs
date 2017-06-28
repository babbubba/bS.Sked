using bS.Sked.Models.Elements.Base;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Extensions.Common
{
    public class FromFlatFlieToTableElementModel : ExecutableElementBaseModel
    {
        public virtual string SourceFile { get; set; }
        public virtual int SkipFirstRows { get; set; }
        public virtual string SeparatorValue { get; set; }
        public virtual int LimitToRows { get; set; }
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
