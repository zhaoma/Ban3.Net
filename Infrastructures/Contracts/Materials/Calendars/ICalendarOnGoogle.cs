//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;

/// <summary>
/// 日历信息
/// https://developers.google.com/calendar/v3/reference/calendars#resource
/// </summary>
public interface ICalendarOnGoogle: IZero
{
    /// <summary>
    /// 此日历的会议属性，例如允许举行哪些类型的会议。
    /// </summary>
    [JsonProperty("conferenceProperties", NullValueHandling = NullValueHandling.Ignore)]
    IConferenceProperty? ConferenceProperties { get; set; }

    /// <summary>
    /// 日历描述(GOOGLE)
    /// </summary>
    [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
    string Description { get; set; }

    /// <summary>
    /// 资源的 ETag。
    /// </summary>
    [JsonProperty("etag", NullValueHandling = NullValueHandling.Ignore)]
    string Etag { get; set; }

    /// <summary>
    /// 日历的标识符。要检索 ID，请调用 calendarList.list() 方法。
    /// </summary>
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    string Id { get; set; }

    /// <summary>
    /// 资源类型（“calendar#calendar”）。
    /// </summary>
    [JsonProperty("kind", NullValueHandling = NullValueHandling.Ignore)]
    string Kind { get; set; }

    /// <summary>
    /// 地理位置(GOOGLE)
    /// Geographic location of the calendar as free-form text. 
    /// Optional.
    /// </summary>
    [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
    string Location { get; set; }

    /// <summary>
    /// 日历的标题。
    /// </summary>
    [JsonProperty("summary", NullValueHandling = NullValueHandling.Ignore)]
    string Summary { get; set; }

    /// <summary>
    /// 日历的时区。（格式为 IANA 时区数据库名称，例如“欧洲/苏黎世”。）可选。
    /// </summary>
    [JsonProperty("timeZone", NullValueHandling = NullValueHandling.Ignore)]
    string TimeZone { get; set; }
}
