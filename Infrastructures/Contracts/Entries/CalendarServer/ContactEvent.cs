using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 个人事件
/// </summary>
public class ContactEvent
{
    /// <summary>
    /// 事件日期
    /// </summary>
    [DataMember]
    public DateTime Date { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    [DataMember]
    public string Type { get; set; }

    /// <summary>
    /// 事件的翻译
    /// </summary>
    [DataMember]
    public string FormattedType { get; set; }
}
