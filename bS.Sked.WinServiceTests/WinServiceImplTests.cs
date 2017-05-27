using Microsoft.VisualStudio.TestTools.UnitTesting;
using bS.Wrapper.SignalRClient.Model;
using bS.Wrapper.SignalRClient.Model.Interfaces;
using bS.Wrapper.SignalRClient.Interfaces;
using bS.Sked.Model.Services.Interfaces;
using bS.Sked.Services;

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
                   SignalRClientContext, ISignalRClientContext>(
                new SignalRClientContext { SignalServerUrl = "http://localhost:55393/signalr" });

            CompositionRoot.CompositionRoot.Instance().Register<Wrapper.SignalRClient.SignalRClient, ISignalRClient>();
            CompositionRoot.CompositionRoot.Instance().Register<WindowsServiceService, IWindowsServiceService>();

            CompositionRoot.CompositionRoot.Instance().BuildContainer();
        }

        [TestMethod()]
        public void WinServiceSendMessageTest()
        {


        }
    }
}