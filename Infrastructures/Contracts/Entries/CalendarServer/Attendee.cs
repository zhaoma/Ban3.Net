using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 参与者(事件定义中参与者部分)
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/attendee
/// https://developers.google.com/calendar/v3/reference/events#resource-representations
/// </summary>
public class Attendee
{
    /// <summary>
    /// 类型
    /// The attendee type: required, optional, resource.(MS)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Type { get; set; }

    /// <summary>
    /// 邮箱地址
    /// Includes the name and SMTP address of the attendee.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public EmailAddress EmailAddress { get; set; }

    /// <summary>
    /// 响应/回应
    /// The attendee's response (none, accepted, declined, etc.) for the event and date-time that the response was sent.(MS)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public ResponseStatus Status { get; set; }

    /// <summary>
    /// 额外的参与者
    /// Number of additional guests. Optional. The default is 0.(GOOGLE)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public int AdditionalGuests { get; set; }

    /// <summary>
    /// 参与者的反应内容(GOOGLE)
    /// The attendee's response comment. 
    /// Optional.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Comment { get; set; }

    /// <summary>
    /// 姓名(GOOGLE)
    /// The attendee's name, if available. 
    /// Optional.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string DisplayName { get; set; }

    /// <summary>
    /// 邮箱(GOOGLE)
    /// The attendee's email address, if available. This field must be present when adding an attendee. 
    /// It must be a valid email address as per RFC5322.
    /// Required when adding an attendee.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Email { get; set; }

    /// <summary>
    /// 参与者个人资料ID(GOOGLE)
    /// The attendee's Profile ID, if available. 
    /// It corresponds to the id field in the People collection of the Google+ API
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string Id { get; set; }

    /// <summary>
    /// 参与者是否可选(GOOGLE)
    /// Whether this is an optional attendee. Optional. The default is False.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool Optional { get; set; }

    /// <summary>
    /// 出席者是否为活动组织者(GOOGLE)
    /// Whether the attendee is the organizer of the event. Read-only. The default is False.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool Organizer { get; set; }

    /// <summary>
    /// 是否资源(GOOGLE)
    /// Whether the attendee is a resource. Can only be set when the attendee is added to the event for the first time. 
    /// Subsequent modifications are ignored. Optional. The default is False.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool Resource { get; set; }

    /// <summary>
    /// 响应信息(GOOGLE)
    /// The attendee's response status. Possible values are:
    /// "needsAction" - The attendee has not responded to the invitation.
    /// "declined" - The attendee has declined the invitation.
    /// "tentative" - The attendee has tentatively accepted the invitation.
    /// "accepted" - The attendee has accepted the invitation.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string ResponseStatus { get; set; }

    /// <summary>
    /// 事件是否是日历副本(GOOGLE)
    /// Whether this entry represents the calendar on which this copy of the event appears. Read-only. The default is False.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public bool Self { get; set; }
}
