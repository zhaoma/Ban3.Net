using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 成员关系
/// </summary>
public class ContactGroupMembership
{
    /// <summary>
    /// 联系组Id
    /// </summary>
    [DataMember]
    public string ContactGroupId { get; set; }
}
