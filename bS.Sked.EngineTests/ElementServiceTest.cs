using bs.Sked.Mapping;
using bS.Sked.Extensions.Common.ViewModel;
using bS.Sked.Services.WMC;
using bS.Sked.WMC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void AddNewElement()
        {
            var vM = new FromFlatFlieToTableElementViewModel
            {
                 InFileObjectFileFullPath = @"c:\test\input.csv",
                  SeparatorValue = ";",
                   SkipStartingRows = 1,
                    Name = "Importa da file csv di prova",
                     ElementTypePersistingId = "Common.FromFlatFileToTable"
                      

            };

            elementService.AddNewElement(vM);

        }

    }

}
