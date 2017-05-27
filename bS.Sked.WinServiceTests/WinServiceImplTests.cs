using Microsoft.VisualStudio.TestTools.UnitTesting;
using bS.Sked.CompositionRoot;
using bS.Sked.Model.Services.Interfaces;
using System;
using bS.Sked.Model.Extra.Wrapper.SignalRClient.Interfaces;
using System.Threading.Tasks;

namespace bS.Sked.WinService.Tests
{
    [TestClass()]
    public class WinServiceImplTests
    {
        [TestInitialize]
        public void InitCompositionRoot()
        {
            CompositionRoot.CompositionRoot.Instance()
                .RegisterInstance<
                    Model.Extra.Wrapper.SignalRClient.SignalRClientContext, ISignalRClientContext>(
                new Model.Extra.Wrapper.SignalRClient.SignalRClientContext { SignalServerUrl = "http://localhost:55393/signalr" });

            CompositionRoot.CompositionRoot.Instance().Register<Wrapper.SignalRClient.SignalRClient, Model.Extra.Wrapper.SignalRClient.Interfaces.ISignalRClient>();
            CompositionRoot.CompositionRoot.Instance().Register<Services.WindowsServiceService, Model.Services.Interfaces.IWindowsServiceService>();

            CompositionRoot.CompositionRoot.Instance().BuildContainer();
        }

        [TestMethod()]
        public void WinServiceSendMessageTest()
        {


        }
    }
}