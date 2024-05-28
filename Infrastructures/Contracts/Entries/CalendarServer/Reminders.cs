//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 提醒方式设置
/// </summary>
public class Reminders : IZero
{
    /// <summary>
    /// 默认提醒是否适用于该事件
    /// Whether the default reminders of the calendar apply to the event.
    /// </summary>
    public bool UseDefault { get; set; }

    /// <summary>
    /// 提醒方式
    /// </summary>
    public IEnumerable<Reminder>? Overrides { get; set; }
}
