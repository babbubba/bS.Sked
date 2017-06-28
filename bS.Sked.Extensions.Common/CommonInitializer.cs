using bS.Sked.Model.Modules;
using System;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Data.Interfaces;
using bS.Sked.Models.Interfaces.Elements;
using System.Linq;
using bS.Sked.Models.Elements;
using bS.Sked.Extensions.Common;
using bS.Sked.Models.Interfaces.MainObjects;
using bS.Sked.Models.MainObjects;

namespace bS.Sked.Extensions.Common
{
    public class CommonInitializer : ModuleInitializerBase
    {
        public static string commonMainObject = "common";
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
            try
            {
                var transaction = _repository.BeginTransaction();

                var query = _repository.GetQuery<IMainObjectTypeModel>();
                if (!query.Any(x => x.PersistingId == commonMainObject))
                {
                    var newCommonMainObjectType = new MainObjectTypeModel
                    {
                        Description = "Common Element plugin.",
                        IsActive = true,
                        Name = "Common",
                        PersistingId = commonMainObject
                    };

                    var queryElementTypes = _repository.GetQuery<IElementTypeModel>();

                    foreach (var suppertedElement in SupportedElements)
                    {
                        newCommonMainObjectType.SupportedElementTypes.Add(queryElementTypes.SingleOrDefault(x => x.PersistingId == suppertedElement));
                    }

                    _repository.Add(newCommonMainObjectType);
                }

                transaction.Commit();

            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }


}
}
