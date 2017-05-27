using bS.Sked.CompositionRoot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.WinService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            InitCompositionRoot();

            //var service = new bS.Sked.Services.WindowsServiceService();
           


            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WinServiceImpl()
            };
            ServiceBase.Run(ServicesToRun);
        }

       static void InitCompositionRoot()
        {

            CompositionRoot.CompositionRoot.Instance()
                .RegisterInstance<
                    Model.Extra.Wrapper.SignalRClient.SignalRClientContext,
                    Model.Extra.Wrapper.SignalRClient.Interfaces.ISignalRClientContext>(   
                new Model.Extra.Wrapper.SignalRClient.SignalRClientContext {  SignalServerUrl = "http://localhost:55393/signalr" });

            CompositionRoot.CompositionRoot.Instance().Register<Wrapper.SignalRClient.SignalRClient, Model.Extra.Wrapper.SignalRClient.Interfaces.ISignalRClient>();
            CompositionRoot.CompositionRoot.Instance().Register <Services.WindowsServiceService, Model.Services.Interfaces.IWindowsServiceService> ();

            CompositionRoot.CompositionRoot.Instance().BuildContainer();
        }
    }
}
