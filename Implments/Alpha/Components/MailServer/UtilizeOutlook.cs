//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components;
using Ban3.Infrastructures.Components.Entries.MailServer;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Components.MailServer;

/// <summary>
/// 
/// </summary>
public class UtilizeOutlook:IMailServer
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    /// <param name="mail"></param>
    /// <returns></returns>
    public bool Send(Account account, Mail mail) {  return false; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="account"></param>
    /// <param name="mail"></param>
    /// <returns></returns>
    public Task<bool> SendAsync(Account account, Mail mail) { return Task.FromResult(true); }
}
