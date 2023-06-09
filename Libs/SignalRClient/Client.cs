using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Ban3.Infrastructures.SignalRClient
{
    public class Client
    {
        static HubConnection? _hubConnection;

        static string _signalRUri = Common.Config.AppConfiguration?
           ["SignalR:Endpoint"] + "";

        static Client()
        {
            _hubConnection ??= new HubConnectionBuilder()
                .WithUrl(new Uri(_signalRUri))
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
                //ex;
            }
        }

        public static Action<Notify> ReceivedNotify;
    }
}

