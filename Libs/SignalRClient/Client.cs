using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Ban3.Infrastructures.SignalRClient
{
    public class Client
    {
        static HubConnection hubConnection;

        static string SignalRUri = Common.Config.AppConfiguration?
           ["SignalR:Endpoint"] + "";

        static Client()
        {
            if (hubConnection == null)
            {
                hubConnection = new HubConnectionBuilder()
                    .WithUrl(new Uri(SignalRUri))
                    .WithAutomaticReconnect()
                    .Build();

                hubConnection.On<Notify>("ReceiveMessage", (notify) =>
                {
                    if (ReceivedNotify != null)
                        ReceivedNotify(notify);
                });
            }
        }

        public static async Task Send(Notify notify)
        {
            try
            {
                if (hubConnection.State != HubConnectionState.Connected)
                    await hubConnection.StartAsync();

                await hubConnection.InvokeAsync("HandleOthersMessage", notify);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Action<Notify> ReceivedNotify;
    }
}

