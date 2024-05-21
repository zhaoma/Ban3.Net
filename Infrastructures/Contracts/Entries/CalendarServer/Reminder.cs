//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 提醒方式
/// (MS)没有列表只有一个ReminderMinutesBeforeStart
/// https://developers.google.com/calendar/v3/reference/events#resource-representations
/// </summary>
public class Reminder : IZero
{
    /// <summary>
    /// 提醒方法
    /// The method used by this reminder. Possible values are:
    /// "email" - Reminders are sent via email.
    /// "sms" - Reminders are sent via SMS.These are only available for G Suite customers.Requests to set SMS reminders for other account types are ignored.
    /// "popup" - Reminders are sent via a UI popup.
    /// Required when adding a reminder.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public ReminderMethod Method { get; set; }

    /// <summary>
    /// 提前分钟数
    /// Number of minutes before the start of the event when the reminder should trigger. Valid values are between 0 and 40320 (4 weeks in minutes).
    /// Required when adding a reminder.
    /// </summary>
    public int Minutes { get; set; }
}
