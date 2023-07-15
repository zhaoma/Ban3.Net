using System;
using Ban3.Infrastructures.SignalRClient.Entries;

namespace Ban3.Infrastructures.SignalRClient;

public static class Helper
{
    /// <summary>
    /// 发布消息
    /// </summary>
    /// <param name="notify"></param>
    public static async void SendBySignalR(this Notify notify)
    {
        await Client.Send(notify);
    }

    /// <summary>
    /// 收听消息
    /// </summary>
    /// <param name="action"></param>
    public static void BindToSignalR(this Action<Notify> action)
    {
        Client.ReceivedNotify = action;
    }
}

