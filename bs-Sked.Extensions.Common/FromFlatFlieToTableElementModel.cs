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
        public string SourceFile { get; set; }
        public int SkipFirstRows { get; set; }
        public string SeparatorValue { get; set; }
        public int LimitToRows { get; set; }
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
