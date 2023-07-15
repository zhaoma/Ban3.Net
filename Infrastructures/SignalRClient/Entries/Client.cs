using System;
using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.SignalR.Client;
#nullable enable
namespace Ban3.Infrastructures.SignalRClient.Entries;

public class Client
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Helper));

    static HubConnection? _hubConnection;

    static string _signalRUri = Common.Config.GetValue("SignalR:Endpoint") + "";

    static Client()
    {
        _hubConnection ??=
            _signalRUri.ToLower().StartsWith("http")
            ?
             new HubConnectionBuilder()
                .WithUrl(new Uri(_signalRUri))
                .WithAutomaticReconnect()
                .Build()
            : new HubConnectionBuilder()
                .WithUrl(_signalRUri)
                .WithAutomaticReconnect()
                .Build();

        _hubConnection.On<Notify>("ReceiveMessage", (notify) =>
        {
            if (ReceivedNotify != null)
                ReceivedNotify(notify);
        });
    }

    public static async Task Send(Notify notify)
    {
        try
        {
            if (_hubConnection?.State != HubConnectionState.Connected)
                await _hubConnection!.StartAsync();

            await _hubConnection.InvokeAsync("HandleOthersMessage", notify);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }
    }

    public static Action<Notify>? ReceivedNotify;
}

