//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components.Entries.MailServer;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.Components;

/// <summary>
/// 邮件发送服务
/// </summary>
public interface IMailServer
{
    /// <summary>
    /// 同步发送
    /// </summary>
    /// <param name="account"></param>
    /// <param name="mail"></param>
    /// <returns></returns>
    bool Send(IAccount account, IMail mail);

    /// <summary>
    /// 异步发送
    /// </summary>
    /// <param name="account"></param>
    /// <param name="mail"></param>
    /// <returns></returns>
    Task<bool> SendAsync(IAccount account, IMail mail);
}
