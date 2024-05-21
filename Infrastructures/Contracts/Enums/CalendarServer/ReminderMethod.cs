//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 提醒方法
/// </summary>
public enum ReminderMethod
{
    /// <summary>
    /// Reminders are sent via email.
    /// </summary>
    Email,

    /// <summary>
    /// Reminders are sent via SMS.These are only available for G Suite customers.
    /// Requests to set SMS reminders for other account types are ignored.
    /// </summary>
    Sms,

    /// <summary>
    /// Reminders are sent via a UI popup.
    /// </summary>
    Popup
}
