//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 成员关系
/// </summary>
public class ContactGroupMembership : IZero
{
    /// <summary>
    /// 联系组Id
    /// </summary>
    public string ContactGroupId { get; set; }
}
