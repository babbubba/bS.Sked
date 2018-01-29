using bS.Sked.Model.Interfaces.Elements.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace bS.Sked.Model.Elements.Properties
{
    public class TableObjectModel : ITableObjectModel
    {
        public TableObjectModel()
        {
            Table = new DataTable("table");
        }

        public DataTable Table { get ; set ; }
    }
}
