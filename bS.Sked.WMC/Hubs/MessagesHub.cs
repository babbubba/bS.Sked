using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace bS.Sked.WMC.Hubs
{
    [HubName("DashboardHub")]
    public class MessagesHub : Hub
    {
        public void SendMessage(Model.WMC.MessageModel messageModel)
        {
            Clients.All.broadcastMessage(messageModel);
        }
        public void SendPoupup(Model.WMC.MessageModel messageModel)
        {
            Clients.All.broadcastMessage(messageModel);
        }
    }
}