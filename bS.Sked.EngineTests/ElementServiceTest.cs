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
        private TaskService taskService;

        [TestInitialize]
        public void Init()
        {
            CompositionRootConfig.RegisterComponents();
            elementService = CompositionRoot.CompositionRoot.Instance().Resolve<ElementService>();
            taskService = CompositionRoot.CompositionRoot.Instance().Resolve<TaskService>();
            Mapping.RegisterMappings();
        }

        [TestMethod]
        public void AddNewFromFlatFileToTableElement()
        {
            var parameters = new Dictionary<string, IField>
            {
                { "InFileObjectFileFullPath", @"c:\test\input.csv" },
                { "SeparatorValue", ";" },
         //       { "SkipStartingDataRows", 0 },
                { "FirstRowHasHeader", true },
                { "Name", "Importa da file csv di prova" },
                { "ElementTypePersistingId", "Common.FromFlatFileToTable" },
                { "IsActive", true },
                { "Position", 112 },
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
                { "InFileObjectId", "2bcd3479-e8a4-4088-a98a-a7b00116963b"},
                { "SeparatorValue", ";" },
                { "SkipStartingRows", 1 },
                { "Name", "Importa da file csv di prova editato" },
                { "ElementTypePersistingId", "Common.FromFlatFileToTable" },
                { "IsActive", true },
                { "Position", 2 },
                { "StopParentIfErrorOccurs", false }
            };

            var res = elementService.EditElement("95d354a5-0887-416a-8205-a7b001169638", "Common.FromFlatFileToTable", parameters);
        }



        [TestMethod]
        public void AddNewTask()
        {
            var res = taskService.AddNewTask("Test Task");
        }


        [TestMethod]
        public void AddElementsToTask()
        {
            var res = taskService.AddElementToTask("c08e93dd-ac82-4f13-8a62-a7c7011a05ac", "686d7aee-1ed9-47b1-aeb2-a7b200d5f71f");
        }

        [TestMethod]
        public void AddNewMainObject()
        {
        }
    }


}
