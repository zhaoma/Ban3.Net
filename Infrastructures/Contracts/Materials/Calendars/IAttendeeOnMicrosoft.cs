//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;

public interface IAttendeeOnMicrosoft : IZero
{
    /// <summary>
    /// 邮箱地址
    /// Includes the name and SMTP address of the attendee.
    /// </summary>
    IEmailAddress? EmailAddress { get; set; }

    /// <summary>
    /// 响应/回应
    /// The attendee's response (none, accepted, declined, etc.) for the event and date-time that the response was sent.(MS)
    /// </summary>
    IResponseStatus? Status { get; set; }

    /// <summary>
    /// 类型
    /// The attendee type: required, optional, resource.(MS)
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    AttendeeType Type { get; set; }
}
