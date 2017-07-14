﻿using bs.Sked.Mapping;
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
            var parameters = new Dictionary<string, IField>();
            parameters.Add("InFileObjectFileFullPath", new Field(@"c:\test\input.csv"));
            parameters.Add("SeparatorValue", new Field(";"));
            parameters.Add("SkipStartingRows", new Field(1));
            parameters.Add("Name", new Field("Importa da file csv di prova"));
            parameters.Add("ElementTypePersistingId", new Field("Common.FromFlatFileToTable"));
            parameters.Add("Description", new Field(""));
            parameters.Add("IsActive", new Field(true));
            parameters.Add("LimitToRows", new Field(0));
            parameters.Add("ParentId", new Field(""));
            parameters.Add("Position", new Field(111));
            parameters.Add("StopParentIfErrorOccurs", new Field(true));
            parameters.Add("StopParentIfWarningOccurs", new Field(false));

            var res = elementService.AddNewElement("Common.FromFlatFileToTable", parameters);
        }
    }
}
