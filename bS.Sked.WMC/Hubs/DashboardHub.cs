﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace bS.Sked.WMC.Hubs
{
    [HubName("DashboardHub")]
    public class DashboardHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }

        public void BroadcastMessage(Model.WMC.MessageModel messageModel)
        {
            Clients.All.broadcastMessage(messageModel);
        }
    }


  

}