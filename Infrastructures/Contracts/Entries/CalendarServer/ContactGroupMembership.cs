//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 成员关系
/// </summary>
public class ContactGroupMembership
{
    /// <summary>
    /// 联系组Id
    /// </summary>
    
    public string ContactGroupId { get; set; }
}
