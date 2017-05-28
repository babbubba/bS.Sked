using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using bS.Sked.Model.WMC;

namespace bS.Sked.WMC.Hubs
{
    [HubName("MessagesHub")]
    public class MessagesHub : Hub
    {
        public void SendMessage(MessageModel messageModel)
        {
            Clients.All.sendMessage(messageModel);
        }
        public void SendPoupup(MessageModel messageModel)
        {
            Clients.All.broadcastMessage(messageModel);
        }
    }
}