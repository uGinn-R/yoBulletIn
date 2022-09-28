using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace yoBulletIn
{
    internal class ChatHub : Hub
    {
        public async Task SendMessage(string user, string itemOwner, string message, Guid itemId)
        {
            await Clients.User(itemOwner).SendAsync("ReceiveMessage", user, message, itemId);
        }
    }
}