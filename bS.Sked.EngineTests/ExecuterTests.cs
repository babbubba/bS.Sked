/* 
 Questa unit test usa il composition root del progetto WMC (quindi la stessa identica situazione senza dover duplicare nulla).
 Tuttavia il composition root usa alcuni valori come la stringa di connessione che risiedono nel file di configurazione. Quindi
 è necessario usare un file app.config in questa unit test. Volendo si può usare un db differente da quello di WMC nella unit test.
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using bS.Sked.WMC;
using bS.Sked.Model.Interfaces.Modules;
using bS.Sked.Model.Interfaces.Elements;
using bS.Sked.Model.Elements;
using bS.Sked.ViewModel.Interfaces.Elements.Base;
using bs.Sked.Mapping;
using bS.Sked.Model.Interfaces.Entities.Base;
using bS.Sked.Data.Interfaces;
using System;

namespace bS.Sked.Engine.Tests
{
    [TestClass()]
    public class ExecuterTests
    {
        private Executer engine;

        [TestInitialize]
        public void Init()
        {
            CompositionRootConfig.RegisterComponents();
            engine = CompositionRoot.CompositionRoot.Instance().Resolve<Executer>();
            Mapping.RegisterMappings();
        }

        //Se gira questo vuol dire che funziona quasi tutto!
        [TestMethod()]
        public void ExecuteElementTest()
        {
            var mainObjects = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExtensionContext>>();
            var mainObjectToExecute = mainObjects.Single(x => x.GetType().Name.Contains("CommonMainObjectModel"));

        //    var initElements = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExtensionModuleInitializer>>();
        ////    var elements = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExecutableElementModel>>();
        // //   var elementToExecute = elements.Single(x=>x.GetType().Name.Contains("FromFlatFlieToTableElementModel"));
        //    //elementToExecute.ElementType = new ElementTypeModel
        //    //{
        //    //    PersistingId = "Common.FromFlatFileToTable"
        //    //};
           
        //    var elementViewModels = CompositionRoot.CompositionRoot.Instance().Resolve<IEnumerable<IExecutableElementBaseViewModel>>();
        //    var elementViewModel = elementViewModels.Single(x => x.GetType().Name.Contains("FromFlatFlieToTableElementViewModel"));

            var elementToExecute = CompositionRoot.CompositionRoot.Instance().Resolve<IRepository<IPersisterEntity>>().GetQuery<IExecutableElementModel>().FirstOrDefault();//.Single(x => x.Id == Guid.Parse("0e743f20-a89b-436a-8c5d-a7ad000a78ee"));
            engine.ExecuteElement(mainObjectToExecute, elementToExecute);
        }
    }
}