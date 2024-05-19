using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;

public interface IAttendeeOnMicrosoft
{
    /// <summary>
    /// 邮箱地址
    /// Includes the name and SMTP address of the attendee.
    /// </summary>
    [JsonProperty("emailAddress", NullValueHandling = NullValueHandling.Ignore)]
    IEmailAddress? EmailAddress { get; set; }

    /// <summary>
    /// 响应/回应
    /// The attendee's response (none, accepted, declined, etc.) for the event and date-time that the response was sent.(MS)
    /// </summary>
    [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
    IResponseStatus? Status { get; set; }

    /// <summary>
    /// 类型
    /// The attendee type: required, optional, resource.(MS)
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    AttendeeType Type { get; set; }
}
