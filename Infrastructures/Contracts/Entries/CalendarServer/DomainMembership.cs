//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 域成员
/// </summary>
public class DomainMembership : IZero
{
    /// <summary>
    /// 是否在谷歌应用程序域
    /// </summary>    
    public bool InViewerDomain { get; set; }
}
