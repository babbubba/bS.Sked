using bS.Sked.Model.Elements.Base;
using bS.Sked.Model.Interfaces.Elements.Properties;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.Extensions.Common
{
    public class FromTableToFileElementModel : ExecutableElementBaseModel, IInputTableObject, IOutputFileObject
    {
        public virtual int SkipFirstRows { get; set; }
        public virtual int LimitToRows { get; set; }

        public virtual ITableObject InTableObject { get; set; }
        public virtual IFileObject OutFileObject { get; set; }
    }

    class FromTableToFileElementModelMap : SubclassMap<FromTableToFileElementModel>
    {
        public FromTableToFileElementModelMap()
        {
            DiscriminatorValue(CommonInitializer.fromTableToFile);
            Map(x => x.SkipFirstRows);
            Map(x => x.LimitToRows);
        }
    }
}
