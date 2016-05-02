using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodHunterAlpha
{
    public class MessageCenter
    {
        private static IHubContext _context;
        static MessageCenter()
        {
            _context = GlobalHost.ConnectionManager.GetHubContext<CenterHub>();
        }

        // This method is invoked by a Timer object.
        public static void LoadOrderQueue()
        {
            _context.Clients.All.loadOrderQueue();
        }
    }
}