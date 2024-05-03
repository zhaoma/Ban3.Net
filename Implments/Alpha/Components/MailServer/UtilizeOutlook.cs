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
    public bool Send(IAccount account, IMail mail) {  return false; }

    public Task<bool> SendAsync(IAccount account, IMail mail) { return Task.FromResult(true); }
}
