// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Hybird;

using System.Threading.Tasks;

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