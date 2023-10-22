using System;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 消息接口
/// </summary>
public interface IMessagesHelper
{
    /// <summary>
    /// 消息推送
    /// </summary>
    /// <param name="messageHub">路由</param>
    /// <param name="messageBody">消息</param>
    /// <returns></returns>
    Task<bool> TryPublish(IMessageHub messageHub, IMessageBody messageBody);

    /// <summary>
    /// 消息订阅
    /// </summary>
    /// <param name="messageHub">路由</param>
    /// <param name="action">消息</param>
    /// <returns></returns>
    Task<bool> TrySubscribe(IMessageHub messageHub, Action<IMessageBody> action);
}

