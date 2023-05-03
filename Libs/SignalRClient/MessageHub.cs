using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.SignalRClient
{
    public class MessageHub
        : Hub
    {
        public async Task HandleAllMessage(Notify notify)
        {
            await Clients.All.SendAsync("ReceiveMessage", notify);
        }

        public async Task HandleOthersMessage(Notify notify)
        {
            await Clients.Others.SendAsync("ReceiveMessage", notify);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ConnectMessage", Context.ConnectionId, "connected");
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.SendAsync("ConnectMessage", Context.ConnectionId, exception);
        }
    }
}

