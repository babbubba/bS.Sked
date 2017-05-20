using bS.Sked.Model.Interfaces.Services;
using Common.Logging;

namespace bS.Sked.Services
{
    public class WindowsServiceService : IService
    {
        private readonly Wrapper.SignalRClient.SignalRClient messageClient;
        static ILog log = LogManager.GetLogger<WindowsServiceService>();

        public WindowsServiceService(Wrapper.SignalRClient.SignalRClient messageClient)
        {
            this.messageClient = messageClient;
        }

        public bool StartService(bool debug = false)
        {
            //Send message to WMC
            var message = new Model.Extra.Wrapper.SignalRClient.SignalRClientCommand
            {
                SignalServerHub = "DashboardHub",
                SignalServerHubMethodToCall = "BroadcastMessage",
                SignalServerHubMethodParameters = null
            };

            //messageClient.SendMessage(message);
            messageClient.SendMessage(message);

            return true;
        }


    }
}
