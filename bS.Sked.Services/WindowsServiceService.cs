using bS.Sked.Model.Services.Interfaces;
using Common.Logging;
using System;

namespace bS.Sked.Services
{
    public class WindowsServiceService : IWindowsServiceService
    {
        private readonly Model.Extra.Wrapper.SignalRClient.Interfaces.ISignalRClient client;
        static ILog log = LogManager.GetLogger<WindowsServiceService>();

        public WindowsServiceService(Model.Extra.Wrapper.SignalRClient.Interfaces.ISignalRClient client)
        {
            this.client = client;
        }

        public bool StartService(bool debug = false)
        {
            try
            {
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
                client.SendMessageAsync(command);
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
