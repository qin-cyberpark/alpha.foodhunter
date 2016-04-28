using System;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace FoodHunterAlpha
{
    public class CenterHub : Hub
    {
        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }
    }
}