using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace bS.Sked.WinService
{
    public partial class WinServiceImpl : ServiceBase
    {
        private string WMCBaseUrl = "http://localhost:55393";

        public WinServiceImpl()
        {
            InitializeComponent();
        }

        protected override async void OnStart(string[] args)
        {
            try
            {
                var hubConnection = new HubConnection($"{WMCBaseUrl}/signalr", useDefaultUrl: false);
                IHubProxy proxy = hubConnection.CreateHubProxy("DashboardHub");

               await hubConnection.Start();

                var messageModel = new Model.WMC.MessageModel
                {
                    Date = DateTime.Now,
                    Message = "Messaggio di prova",
                    MessageId = "12",
                    Severity = "INFO",
                    SeverityId = 0
                };
              await  proxy.Invoke("BroadcastMessage", messageModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void OnStop()
        {
        }
    }
}
