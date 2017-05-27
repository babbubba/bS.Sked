using bS.Sked.CompositionRoot;
using bS.Wrapper.SignalRClient;
using bS.Wrapper.SignalRClient.Interfaces;
using bS.Wrapper.SignalRClient.Model;
using bS.Wrapper.SignalRClient.Model.Interfaces;
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
                .RegisterInstance<SignalRClientContext, ISignalRClientContext>(
                new SignalRClientContext { SignalServerUrl = "http://localhost:55393/signalr" });

            CompositionRoot.CompositionRoot.Instance().Register<SignalRClient, ISignalRClient>();
            CompositionRoot.CompositionRoot.Instance().Register<Services.WindowsServiceService, Model.Services.Interfaces.IWindowsServiceService>();

            CompositionRoot.CompositionRoot.Instance().BuildContainer();
        }
    }
}
