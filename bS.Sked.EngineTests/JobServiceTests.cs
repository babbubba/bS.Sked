using bs.Sked.Mapping;
using bS.Sked.Model.DTO;
using bS.Sked.Model.Interfaces.DTO;
using bS.Sked.Services.WMC;
using bS.Sked.WMC;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace bS.Sked.EngineTests
{
    [TestClass()]

    public class JobServiceTests
    {
        private JobService jobService;

        [TestInitialize]
        public void Init()
        {
            CompositionRootConfig.RegisterComponents();
            jobService = CompositionRoot.CompositionRoot.Instance().Resolve<JobService>();
            Mapping.RegisterMappings();
        }
        [TestMethod]
        public void JobAllTest()
        {
            var jobs = jobService.JobAll();
            Assert.IsNotNull(jobs);
        }

        [TestMethod]
        public void JobAddTest()
        {
            var job = jobService.JobAdd("job di prova " + DateTime.Now.ToLongTimeString());
            Assert.IsNotNull(job);
        }
    }
}
