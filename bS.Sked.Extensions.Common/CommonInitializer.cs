using bS.Sked.Model.Modules;
using System;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Data.Interfaces;
using bS.Sked.Model.Interfaces.Elements;
using System.Linq;
using bS.Sked.Model.Interfaces.MainObjects;
using bS.Sked.Model.MainObjects;
using System.Collections.Generic;
using Common.Logging;

namespace bS.Sked.Extensions.Common
{
    public class CommonInitializer : ModuleInitializerBase
    {
        private static ILog log = LogManager.GetLogger<CommonInitializer>();


        public static string commonMainObject = "Common";
        public static string fromFlatFlieToTable = "Common.FromFlatFileToTable";
        public static string fromDbQueryToTabke = "Common.FromDbQueryToTable";
        public static string fromTableToFile = "Common.FromTableToFile";

        public CommonInitializer(IRepository<IPersisterEntity> repository) : base(repository)
        {
            _supportedElements = new Dictionary<string, string>
            {
                { fromFlatFlieToTable, "From flat file to table" },
                { fromDbQueryToTabke, "From ODBC DB query to table" },
                { fromTableToFile, "From table to file" }
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
                    newCommonMainObjectType.SupportedElementTypes = new List<IElementTypeModel>();

                    foreach (var suppertedElement in SupportedElements)
                    {
                        newCommonMainObjectType.SupportedElementTypes.Add(queryElementTypes.SingleOrDefault(x => x.PersistingId == suppertedElement.Key));
                    }

                    _repository.Add(newCommonMainObjectType);
                }

                transaction.Commit();

            }
            catch (Exception ex)
            {
                log.Error("Error initializing Common Extension Main Object.", ex);
                return false;
            }
            return true;
        }


}
}
