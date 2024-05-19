//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 小组成员
/// </summary>
public class Membership
{
    /// <summary>
    /// 小组成员
    /// </summary>
    
    public List<ContactGroupMembership>? ContactGroupMembership { get; set; }

    /// <summary>
    /// 域成员
    /// </summary>
    
    public List<DomainMembership>? DomainMembership { get; set; }
}
