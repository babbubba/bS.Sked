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
    public class FromDbQueryToTableElementModel : ExecutableElementBaseModel, IOutputTableObject
    {
        public virtual string Query { get; set; }
        public virtual string ODBCConnectionString { get; set; }
        public virtual int SkipFirstRows { get; set; }
        public virtual int LimitToRows { get; set; }

        #region Properties
        public virtual ITableObject OutTableObject { get; set; } 
        #endregion
    }


    class FromDbQueryToTableElementModelMap : SubclassMap<FromDbQueryToTableElementModel>
    {
        public FromDbQueryToTableElementModelMap()
        {
            DiscriminatorValue(CommonInitializer.fromDbQueryToTable);
            Map(x => x.Query);
            Map(x => x.ODBCConnectionString);
            Map(x => x.SkipFirstRows);
            Map(x => x.LimitToRows);
        }
    }
}
