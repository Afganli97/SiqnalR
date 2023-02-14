using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SiqnalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task Send(string user, string message)
        {
            await this.Clients.All.SendAsync("Send", message, user, $"{DateTime.Now.ToShortTimeString()}");
        }

        public async Task SendToUsers(IReadOnlyList<string> users, string message, string user)
        {
            await this.Clients.Users(users).SendAsync("SendToUsers",user, message, $"{DateTime.Now.ToShortTimeString()}");
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}