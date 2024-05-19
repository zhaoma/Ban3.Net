//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Runtime.Serialization;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 个人事件
/// </summary>
public class ContactEvent : MetaBase
{
    /// <summary>
    /// 事件日期
    /// </summary>
    
    public DateTime Date { get; set; }

    /// <summary>
    /// 事件类型
    /// </summary>
    
    public string Type { get; set; }

    /// <summary>
    /// 事件的翻译
    /// </summary>
    
    public string FormattedType { get; set; }
}
