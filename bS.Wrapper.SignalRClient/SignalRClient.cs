using bS.Sked.Model.Extra.Wrapper.SignalRClient.Interfaces;
using Common.Logging;
using Microsoft.AspNet.SignalR.Client;
using System;

namespace bS.Wrapper.SignalRClient
{
    public class SignalRClient
    {
        static ILog log = LogManager.GetLogger<SignalRClient>();

        private readonly ISignalRClientContext context;

        public SignalRClient(ISignalRClientContext context)
        {
            this.context = context;
        }

        public async void SendMessage(ISignalRClientCommand command)
        {
            try
            {
                using (var hubConnection = new HubConnection($"{context.SignalServerUrl}", useDefaultUrl: false))
                {
                    var proxy = hubConnection.CreateHubProxy(command.SignalServerHub);

                    await hubConnection.Start();

                    await proxy.Invoke(command.SignalServerHubMethodToCall, command.SignalServerHubMethodParameters);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"Error sending message to SignlR Server (Url: {context.SignalServerUrl})";
                log.Error(errorMessage, ex);
                throw new ApplicationException(errorMessage); //Do not throw the stack exception
            }
        }
    }
}
