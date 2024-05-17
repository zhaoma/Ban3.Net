using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 域成员
/// </summary>
public class DomainMembership
{
    /// <summary>
    /// 是否在谷歌应用程序域
    /// </summary>
    [DataMember]
    public bool InViewerDomain { get; set; }
}
