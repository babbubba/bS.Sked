using bS.Wrapper.SignalRClient.Interfaces;
using bS.Wrapper.SignalRClient.Model.Interfaces;
using Common.Logging;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace bS.Wrapper.SignalRClient
{
    public class SignalRClient : ISignalRClient
    {
        static ILog log = LogManager.GetLogger<SignalRClient>();

        private readonly ISignalRClientContext context;

        public SignalRClient(ISignalRClientContext context)
        {
            this.context = context;
        }

        public async Task SendMessageAsync(ISignalRClientCommand command)
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
