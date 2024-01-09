//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

/// <summary>
/// 电子邮件接口声明
/// </summary>
public interface IMailsHelper
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="mailServer"></param>
    /// <param name="mail"></param>
    /// <returns></returns>
    Task<bool> TrySend( IMailServer mailServer, IMail mail );
}