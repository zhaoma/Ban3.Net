//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CalendarServer;
using Ban3.Infrastructures.Contracts.Enums;
using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;

public interface IEventOnMicrosoft
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    string Id { get; set; }

    /// <summary>
    /// 事件对象版本标识
    /// 每次事件更改时，ChangeKey 也将更改。这样，Exchange 可以将更改应用于该对象的正确版本。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "changeKey")]
    string ChangeKey { get; set; }

    /// <summary>
    /// 事件类别
    /// </summary>
    [JsonProperty("categories", NullValueHandling = NullValueHandling.Ignore)]
    IEnumerable<string> Categories { get; set; }

    /// <summary>
    /// The start time zone that was set when the event was created. 
    /// A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
    /// </summary>
    [JsonProperty("originalStartTimeZone", NullValueHandling = NullValueHandling.Ignore)]
    string OriginalStartTimeZone { get; set; }

    /// <summary>
    /// The end time zone that was set when the event was created. 
    /// A value of tzone://Microsoft/Customindicates that a legacy custom time zone was set in desktop Outlook.
    /// </summary>
    [JsonProperty("originalEndTimeZone", NullValueHandling = NullValueHandling.Ignore)]
    string OriginalEndTimeZone { get; set; }

    /// <summary>
    /// 由不同日历间的所有事件实例共享的唯一标识符。 只读。
    /// </summary>
    [JsonProperty("iCalUId", NullValueHandling = NullValueHandling.Ignore)]
    string iCalUId { get; set; }

    /// <summary>
    /// 事件开始时间（即提醒警报发生时间）之前的分钟数。
    /// </summary>
    [JsonProperty("reminderMinutesBeforeStart", NullValueHandling = NullValueHandling.Ignore)]
    int ReminderMinutesBeforeStart { get; set; }

    /// <summary>
    /// 是否设置提醒警告
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isReminderOn")]
    bool IsReminderOn { get; set; }

    /// <summary>
    /// 是否有附件
    /// </summary>
    [JsonProperty("hasAttachments", NullValueHandling = NullValueHandling.Ignore)]
    bool HasAttachments { get; set; }

    /// <summary>
    /// 隐藏参与者
    /// </summary>
    [JsonProperty("hideAttendees", NullValueHandling = NullValueHandling.Ignore)]
    bool HideAttendees { get; set; }

    /// <summary>
    /// 事件主题文本(MS)
    /// 对应GOOGLE中的summary
    /// </summary>
    [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
    string Subject { get; set; }

    /// <summary>
    /// 事件导语(MS)
    /// 与事件相关联的邮件预览。文本格式。
    /// </summary>
    [JsonProperty("bodyPreview", NullValueHandling = NullValueHandling.Ignore)]
    string BodyPreview { get; set; }

    /// <summary>
    /// 事件的重要性
    /// 可取值为：low、normal、high。
    /// </summary>
    [JsonProperty("importance", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    Importance Importance { get; set; }

    /// <summary>
    /// 信息敏感度
    /// 可能的值是：normal、personal、private、confidential。
    /// </summary>
    [JsonProperty("sensitivity", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    Sensitivity Sensitivity { get; set; }

    /// <summary>
    /// 事件持续事件是否为一整天
    /// </summary>
    [JsonProperty("isAllDay", NullValueHandling = NullValueHandling.Ignore)]
    bool IsAllDay { get; set; }

    /// <summary>
    /// 事件是否被取消
    /// </summary>
    [JsonProperty("isCancelled", NullValueHandling = NullValueHandling.Ignore)]
    bool IsCancelled { get; set; }


    [JsonProperty("isDraft", NullValueHandling = NullValueHandling.Ignore)]
    bool IsDraft { get; set; }

    /// <summary>
    /// 事件发送者是否是组织者
    /// </summary>
    [JsonProperty("isOrganizer", NullValueHandling = NullValueHandling.Ignore)]
    bool IsOrganizer { get; set; }

    /// <summary>
    /// 请求响应
    /// 如果发件人希望接收事件被接受或拒绝时的响应，则设置为 true。
    /// </summary>
    [JsonProperty("responseRequested", NullValueHandling = NullValueHandling.Ignore)]
    bool ResponseRequested { get; set; }

    /// <summary>
    /// 项目类别
    /// </summary>
    [JsonProperty("seriesMasterId", NullValueHandling = NullValueHandling.Ignore)]
    string SeriesMasterId { get; set; }

    /// <summary>
    /// 状态显示
    /// 要显示的状态。 可取值为：free、tentative、busy、oof、workingElsewhere、unknown。
    /// </summary>
    [JsonProperty("showAs", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ShowAs ShowAs { get; set; }

    /// <summary>
    /// 事件类型
    /// 事件类型。 可取值为 singleInstance、occurrence、exception、seriesMaster。 
    /// 单实例、事件、异常、序列主机
    /// 只读。
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    EventType Type { get; set; }

    /// <summary>
    /// 链接地址
    /// 要在 Outlook Web App 中打开事件的 URL。(MS)
    /// </summary>
    [JsonProperty("weblink", NullValueHandling = NullValueHandling.Ignore)]
    string Weblink { get; set; }

    /// <summary>
    /// 在线会议的url
    /// </summary>
    [JsonProperty("onlineMeetingUrl", NullValueHandling = NullValueHandling.Ignore)]
    string OnlineMeetingUrl { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("IsOnlineMeeting", NullValueHandling = NullValueHandling.Ignore)]
    bool IsOnlineMeeting { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("onlineMeetingProvider", NullValueHandling = NullValueHandling.Ignore)]
    string OnlineMeetingProvider { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("allowNewTimeProposals", NullValueHandling = NullValueHandling.Ignore)]
    bool AllowNewTimeProposals { get; set; }

    /// <summary>
    /// 事件响应状态
    /// </summary>
    [JsonProperty("responseStatus", NullValueHandling = NullValueHandling.Ignore)]
    IResponseStatus? ResponseStatus { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
    IItemBody Body { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
    ITime Start { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
    ITime End { get; set; }

    /// <summary>
    /// 发生地点
    /// </summary>
    [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
    ILocation? Location { get; set; }

    /// <summary>
    /// The locations where the event is held or attended from. 
    /// The location and locations properties always correspond with each other. 
    /// If you update the location property, any prior locations in the locations collection 
    /// would be removed and replaced by the new location value.
    /// </summary>
    [JsonProperty("locations", NullValueHandling = NullValueHandling.Ignore)]
    IEnumerable< ILocation>? Locations { get; set; }

    /// <summary>
    /// 组织者
    /// </summary>
    [JsonProperty("organizer", NullValueHandling = NullValueHandling.Ignore )]
    IOrganizer Organizer { get; set; }

    /// <summary>
    /// 事件的定期模式，频次与时间设置
    /// </summary>
    [JsonProperty("recurrence",NullValueHandling = NullValueHandling.Ignore )]
    IRecurrence? Recurrence { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("attendees", NullValueHandling = NullValueHandling.Ignore)]
    IEnumerable<Attendee>? Attendees { get; set; }

    /// <summary>
    /// 创建时间
    /// 时间戳类型表示使用 ISO 8601 格式的日期和时间信息，并且始终处于 UTC 时间。例如，2014 年 1 月 1 日午夜 UTC 如下所示：'2014-01-01T00:00:00Z'
    /// </summary>
    [JsonProperty("createdDateTime",NullValueHandling = NullValueHandling.Ignore)]
    DateTime CreatedDateTime { get; set; }

    /// <summary>
    /// 时间戳
    /// </summary>
    [JsonProperty("lastModifiedDateTime",NullValueHandling = NullValueHandling.Ignore)]
    DateTime LastModifiedDateTime { get; set; }

    /// <summary>
    /// A custom identifier specified by a client app for the server to avoid redundant POST 
    /// operations in case of client retries to create the same event. 
    /// This is useful when low network connectivity causes the client to time out before 
    /// receiving a response from the server for the client's prior create-event request. 
    /// After you set transactionId when creating an event, you cannot change transactionId in a subsequent update. 
    /// This property is only returned in a response payload if an app has set it. Optional.
    /// </summary>
    [JsonProperty("transactionId", NullValueHandling = NullValueHandling.Ignore)]
    string TransactionId { get; set; }
}
