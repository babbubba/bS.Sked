using bS.Sked.Model.Services.Interfaces;
using Common.Logging;
using System;

namespace bS.Sked.Services
{
    public class WindowsServiceService : IService
    {
        static ILog log = LogManager.GetLogger<WindowsServiceService>();

        public WindowsServiceService()
        {
        }

        public bool StartService(bool debug = false)
        {
            try
            {
                var clientContext = new Model.Extra.Wrapper.SignalRClient.SignalRClientContext
                {
                    SignalServerUrl = "http://localhost:55393/signalr"
                };
                var client = new Wrapper.SignalRClient.SignalRClient(clientContext);

                // Send message to WMC SignalR Server
                var messageModel = new Model.WMC.MessageModel
                {
                    Date = DateTime.Now,
                    Message = "Windows service started.",
                    MessageId = "12",
                    Severity = "DEBUG",
                    SeverityId = 1
                };

                var command = new Model.Extra.Wrapper.SignalRClient.SignalRClientCommand
                {
                    SignalServerHub = "DashboardHub",
                    SignalServerHubMethodToCall = "BroadcastMessage",
                    SignalServerHubMethodParameters = new object[] { messageModel }
                };

                //messageClient.SendMessage(message);
                client.SendMessage(command);
            }
            catch (Exception ex)
            {
                log.Fatal($"Error Starting Windows Service: {ex.GetBaseException().Message}");
                return false;
            }

            return true;
        }


    }
}
