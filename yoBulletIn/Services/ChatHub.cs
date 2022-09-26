using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace yoBulletIn
{
    internal class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message, Guid itemId)
        {
            //var userId = Context.UserIdentifier;
            //var userCtxType = Context.User.Identity.AuthenticationType;
            //var userCtx = Context.User.Identity.Name;
            await Clients.All.SendAsync("ReceiveMessage", user, message, itemId);
        }
        //public Task TryAddGroup(int itemId)
        //{
        //    return Groups.AddToGroupAsync(Context.ConnectionId, itemId.ToString());
        //}

    }
}