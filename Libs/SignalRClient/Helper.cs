using System;
using log4net;
using Microsoft.AspNetCore.SignalR.Client;

namespace Ban3.Infrastructures.SignalRClient
{
	public static class Helper
    {
	    public static async void SendBySignalR(this Notify notify)
        {
            await Client.Send(notify);
        }

        public static void BindToSignalR(this Action<Notify> action)
        {
            Client.ReceivedNotify = action;
        }
    }
}

