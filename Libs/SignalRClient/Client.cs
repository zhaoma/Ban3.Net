using System;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

namespace Ban3.Infrastructures.SignalRClient
{
    public class Client
    {
        HubConnection hubConnection;

        string SignalRUri = Infrastructures.Common.Config.AppConfiguration?
           ["SignalR:Url"] + "";

        public Client()
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

        public async void Send(Notify notify)
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

        public Action<Notify> ReceivedNotify;
    }
}

