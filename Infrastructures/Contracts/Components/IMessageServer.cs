//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components.Entries.MessageServer;
using System;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Components.Services;

/// <summary>
/// 消息服务
/// </summary>
public interface IMessageServer
{
    /// <summary>
    /// 发布通知
    /// </summary>
    /// <param name="notify"></param>
    /// <returns></returns>
    Task<bool> Publish(INotify notify);

    /// <summary>
    /// 收听
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> Subscribe(Action<INotify> action);
}
