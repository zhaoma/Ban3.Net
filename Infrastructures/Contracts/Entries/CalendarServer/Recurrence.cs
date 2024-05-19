//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials.Calendars;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 周期定义
/// MS：https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/patternedrecurrence
/// GOOGLE：List of RRULE, EXRULE, RDATE and EXDATE lines for a recurring event, as specified in RFC5545. 
/// Note that DTSTART and DTEND lines are not allowed in this field; 
/// event start and end times are specified in the start and end fields. 
/// This field is omitted for single events or instances of recurring events.
/// http://tools.ietf.org/html/rfc5545#section-3.8.5
/// </summary>
public class Recurrence: IRecurrence
{
    /// <summary>
    /// 事件频率
    /// The frequency of an event.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "pattern")]
    public IRecurrencePattern? Pattern { get; set; }

    /// <summary>
    /// 事件周期
    /// The duration of an event.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "range")]
    public IRecurrenceRange? Range { get; set; }
}
