using Microsoft.VisualStudio.TestTools.UnitTesting;
using bS.Sked.Data;
using bS.Sked.Data.Interfaces;

namespace bS.Sked.Services.WMC.Tests
{
    [TestClass()]
    public class LeftSidebarServiceTests
    {
        private LeftSidebarService service;

        [TestInitialize]
        public void init()
        {
            // Context and Unit Of Work
            CompositionRoot.CompositionRoot.Instance().RegisterInstance(new DataContextConfigInfo { ConnectionString = @"Server = localhost; Database = eork3v2; User ID = root; Password = beibub1;", ExtraDllModelFolders = @"C:\eOrk3\PLUGINS\" });
            CompositionRoot.CompositionRoot.Instance().Register<ObjectContextImpl, IObjectContext>();
            CompositionRoot.CompositionRoot.Instance().Register<UnitOfWork, IUnitOfWork>();

            //Repositories
            CompositionRoot.CompositionRoot.Instance().RegisterGeneric(typeof(RepositoryBase<>), typeof(IRepository<>));


            CompositionRoot.CompositionRoot.Instance().Register<LeftSidebarService>();
            CompositionRoot.CompositionRoot.Instance().BuildContainer();

            service = CompositionRoot.CompositionRoot.Instance().Resolve<LeftSidebarService>();
        }

        [TestMethod()]
        public void LeftSidebarServiceTest()
        {
            var r = service.Items();
        }
    }
}