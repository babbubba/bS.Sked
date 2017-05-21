using Microsoft.VisualStudio.TestTools.UnitTesting;
using bS.Sked.CompositionRoot;

namespace bS.Sked.WinService.Tests
{
    [TestClass()]
    public class WinServiceImplTests
    {
        [TestMethod()]
        public void WinServiceSendMessageTest()
        {
   

            CR.SingletonInstance()
                .RegisterInstance<
                    Model.Extra.Wrapper.SignalRClient.SignalRClientContext,
                    Model.Extra.Wrapper.SignalRClient.Interfaces.ISignalRClientContext>(
                new Model.Extra.Wrapper.SignalRClient.SignalRClientContext { SignalServerUrl = "http://localhost:55393/signalr" });

            CR.SingletonInstance().Register<Wrapper.SignalRClient.SignalRClient>();
            CR.SingletonInstance().Register<Services.WindowsServiceService>();

            CR.SingletonInstance().BuildContainer();
        var  service = CR.SingletonInstance().Resolve<Services.WindowsServiceService>();
            service.StartService();
        }
    }
}