//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 事件透明，事件是否阻止日历上的时间。
/// </summary>
public enum EventTransparency
{
    /// <summary>
    /// Default value.
    /// The event does block time on the calendar.
    /// This is equivalent to setting Show me as to Busy in the Calendar UI.
    /// </summary>
    Opaque,

    /// <summary>
    /// The event does not block time on the calendar.
    /// This is equivalent to setting Show me as to Available in the Calendar UI.
    /// </summary>
    Transparent
}
