using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 小组成员
/// </summary>
public class Membership
{
    /// <summary>
    /// 小组成员
    /// </summary>
    [DataMember]
    public List<ContactGroupMembership> ContactGroupMembership { get; set; }

    /// <summary>
    /// 域成员
    /// </summary>
    [DataMember]
    public List<DomainMembership> DomainMembership { get; set; }
}
