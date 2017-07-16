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

        [TestMethod]
        public void EditFromFlatFileToTableElement()
        {
            var parameters = new Dictionary<string, IField>
            {
                { "InFileObjectFileFullPath", @"c:\test\input2.csv" },
                { "InFileObjectId", "2fbf4b27-d4d5-424d-9328-a7b20110a8f2"},
                { "SeparatorValue", ";" },
                { "SkipStartingRows", 1 },
                { "Name", "Importa da file csv di prova editato" },
                { "ElementTypePersistingId", "Common.FromFlatFileToTable" },
                { "IsActive", true },
                { "Position", 2 },
                { "StopParentIfErrorOccurs", false }
            };

            var res = elementService.EditElement("3494c596-1412-4f53-8531-a7b2010aa7d2", "Common.FromFlatFileToTable", parameters);
        }
    }


}
