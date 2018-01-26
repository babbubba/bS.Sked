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
using bS.Sked.Model.Interfaces.Tasks;
using bS.Sked.Model.Tasks;
using bS.Sked.Model.Jobs;

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

        [TestMethod()]
        public void TaskExecuteTest()
        {
            var taskToExecute = CompositionRoot.CompositionRoot.Instance().Resolve<IRepository<IPersisterEntity>>().GetQuery<ITaskModel>().Single(x => x.Id == Guid.Parse("c08e93dd-ac82-4f13-8a62-a7c7011a05ac"));
            var result = engine.ExecuteTask(taskToExecute, new JobInstanceModel { PersistingFullPath = @"C:\temp\jobdiprova" });
        }
    }
}