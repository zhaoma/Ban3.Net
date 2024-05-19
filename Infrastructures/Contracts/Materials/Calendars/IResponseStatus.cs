//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;

/// <summary>
/// 响应状态(邀请)
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/responsestatus
/// </summary>
public interface IResponseStatus
{
    /// <summary>
    /// 响应信息
    /// The attendee's response status. Possible values are:
    /// "needsAction" - The attendee has not responded to the invitation.
    /// "declined" - The attendee has declined the invitation.
    /// "tentative" - The attendee has tentatively accepted the invitation.
    /// "accepted" - The attendee has accepted the invitation.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "response")]
    [JsonConverter(typeof(StringEnumConverter))]
    ResponseType Response { get; set; }

    /// <summary>
    /// 响应时间
    /// The date and time that the response was returned. 
    /// It uses ISO 8601 format and is always in UTC time. 
    /// For example, midnight UTC on Jan 1, 2014 would look like this: '2014-01-01T00:00:00Z'
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "time")]
    DateTime Time { get; set; }
}
