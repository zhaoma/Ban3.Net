//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Enums.Kalendar;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Kalendar;

/// <summary>
/// 提醒方式
/// (MS)没有列表只有一个ReminderMinutesBeforeStart
/// https://developers.google.com/calendar/v3/reference/events#resource-representations
/// </summary>
public interface ICalendarReminder
{
    /// <summary>
    /// 提醒方法
    /// </summary>
    [JsonProperty( "method" )]
    [JsonConverter( typeof( StringEnumConverter ) )]
    ReminderMethod Method { get; set; }

    /// <summary>
    /// 提前分钟数
    /// Number of minutes before the start of the event when the reminder should trigger. Valid values are between 0 and 40320 (4 weeks in minutes).
    /// Required when adding a reminder.
    /// </summary>
    [JsonProperty( "minutes" )]
    int Minutes { get; set; }

    /// <summary>
    /// 默认提醒是否适用于该事件
    /// Whether the default reminders of the calendar apply to the event.
    /// </summary>
    [JsonProperty( NullValueHandling = NullValueHandling.Ignore, PropertyName = "useDefault" )]
    bool UseDefault { get; set; }
}