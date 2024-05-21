//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 个人事件
/// </summary>
public class ContactEvent : MetaBase, IZero
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
