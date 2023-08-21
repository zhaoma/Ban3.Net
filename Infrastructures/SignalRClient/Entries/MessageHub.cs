using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Ban3.Infrastructures.SignalRClient.Entries;

/// <summary>
/// 
/// </summary>
public class MessageHub
    : Hub
{
    /// <summary>
    /// 
    /// </summary>
    public async Task HandleAllMessage(Notify notify)
    {
        await Clients.All.SendAsync("ReceiveMessage", notify);
    }

    /// <summary>
    /// 
    /// </summary>
    public async Task HandleOthersMessage(Notify notify)
    {
        await Clients.Others.SendAsync("ReceiveMessage", notify);
    }

    /// <summary>
    /// 
    /// </summary>
    public override async Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("ConnectMessage", Context.ConnectionId, "connected");
    }

    /// <summary>
    /// 
    /// </summary>
    public override async Task OnDisconnectedAsync(Exception exception)
    {
        await Clients.All.SendAsync("ConnectMessage", Context.ConnectionId, exception);
    }
}
