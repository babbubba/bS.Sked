using bS.Sked.Model.Modules;
using System;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Data.Interfaces;
using bS.Sked.Models.Interfaces.Elements;
using System.Linq;
using bS.Sked.Models.Elements;
using bS.Sked.Extensions.Common;

namespace bS.Sked.Extensions.Common
{
    public class CommonInitializer : ModuleInitializerBase
    {
        public static string fromFlatFlieToTable = "from-flat-flie-to-table";
        public static string fromDbQueryToTabke = "from-db-query-to-table";
        public static string fromTableToFile = "from-table-to-flie";

        public CommonInitializer(IRepository<IPersisterEntity> repository) : base(repository)
        {
            _supportedElements = new string[]
           {
                fromFlatFlieToTable,
                fromDbQueryToTabke,
                fromTableToFile
           };
        }

        public override bool InitContextModels()
        {
            throw new NotImplementedException();
        }

        public override bool InitContextTypes()
        {
            throw new NotImplementedException();
        }

       
    }
}
