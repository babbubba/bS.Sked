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
            CR.SingletonInstance()
                .RegisterInstance<
                    Model.Extra.Wrapper.SignalRClient.SignalRClientContext, ISignalRClientContext>(
                new Model.Extra.Wrapper.SignalRClient.SignalRClientContext { SignalServerUrl = "http://localhost:55393/signalr" });

            CR.SingletonInstance().Register<Wrapper.SignalRClient.SignalRClient, Model.Extra.Wrapper.SignalRClient.Interfaces.ISignalRClient>();
            CR.SingletonInstance().Register<Services.WindowsServiceService, Model.Services.Interfaces.IWindowsServiceService>();

            CR.SingletonInstance().BuildContainer();
        }

        [TestMethod()]
        public void WinServiceSendMessageTest()
        {


        }
    }
}