using bs.Sked.Mapping;
using bS.Sked.Model.DTO;
using bS.Sked.Model.Interfaces.DTO;
using bS.Sked.Services.WMC;
using bS.Sked.WMC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace bS.Sked.Service.Tests
{
    [TestClass()]
    public class ElementServiceTest
    {
        private ElementService elementService;

        [TestInitialize]
        public void Init()
        {
            CompositionRootConfig.RegisterComponents();
            elementService = CompositionRoot.CompositionRoot.Instance().Resolve<ElementService>();
            Mapping.RegisterMappings();
        }

        [TestMethod]
        public void AddNewFromFlatFileToTableElement()
        {
            //var parameters = new Dictionary<string, IField>
            //{
            //    { "InFileObjectFileFullPath", new Field(@"c:\test\input.csv") },
            //    { "SeparatorValue", new Field(";") },
            //    { "SkipStartingRows", new Field(1) },
            //    { "Name", new Field("Importa da file csv di prova") },
            //    { "ElementTypePersistingId", new Field("Common.FromFlatFileToTable") },
            //    //parameters.Add("Description", new Field(""));
            //    { "IsActive", new Field(true) },
            //    //parameters.Add("LimitToRows", new Field(0));
            //    //parameters.Add("ParentId", new Field(""));
            //    { "Position", new Field(111) },
            //    { "StopParentIfErrorOccurs", new Field(true) }
            //    //parameters.Add("StopParentIfWarningOccurs", new Field(false));
            //};

            var parameters = new Dictionary<string, IField>
            {
                { "InFileObjectFileFullPath", @"c:\test\input.csv" },
                { "SeparatorValue", ";" },
                { "SkipStartingRows", 1 },
                { "Name", "Importa da file csv di prova" },
                { "ElementTypePersistingId", "Common.FromFlatFileToTable" },
                { "IsActive", true },
                { "Position", 111 },
                { "StopParentIfErrorOccurs", true }
            };
            var res = elementService.AddNewElement("Common.FromFlatFileToTable", parameters);
        }
    }


}
