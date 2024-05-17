//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components.Entries.HttpServer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 日历事件
/// </summary>
public class Event
{

    #region Property

    /// <summary>
    /// 所属日历标识
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "calendarId")]
    public string CalendarId { get; set; }

    /// <summary>
    /// 由不同日历间的所有事件实例共享的唯一标识符。 只读。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "iCalUId")]
    public string iCalUId { get; set; }

    /// <summary>
    /// 选择自己是否可被邀请（GOOGLE）
    /// Whether anyone can invite themselves to the event (currently works for Google+ events only). Optional. 
    /// The default is False.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "anyoneCanAddSelf")]
    public bool AnyoneCanAddSelf { get; set; }

    /// <summary>
    /// 附件
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "attachments")]
    public List<Attachment> Attachments { get; set; }

    /// <summary>
    /// 参会者是否被遗漏(google)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "attendeesOmitted")]
    public bool AttendeesOmitted { get; set; }

    /// <summary>
    /// 参与者
    /// 事件的与会者集合。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "attendees")]
    public List<Attendee> Attendees { get; set; }

    /// <summary>
    /// 事件描述信息(MS)
    /// 对应GOOGLE的description
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "body")]
    public ItemBody Body { get; set; }

    /// <summary>
    /// 事件导语(MS)
    /// 与事件相关联的邮件预览。文本格式。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "bodyPreview")]
    public string BodyPreview { get; set; }

    /// <summary>
    /// 事件类别
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "categories")]
    public List<string> Categories { get; set; }

    /// <summary>
    /// 事件对象版本标识
    /// 每次事件更改时，ChangeKey 也将更改。这样，Exchange 可以将更改应用于该对象的正确版本。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "changeKey")]
    public string ChangeKey { get; set; }

    /// <summary>
    /// 事件颜色id(google)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "colorId")]
    public string ColorId { get; set; }

    /// <summary>
    /// 事件创建时间(google)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "created")]
    public DateTime Created { get; set; }

    /// <summary>
    /// 创建时间
    /// 时间戳类型表示使用 ISO 8601 格式的日期和时间信息，并且始终处于 UTC 时间。例如，2014 年 1 月 1 日午夜 UTC 如下所示：'2014-01-01T00:00:00Z'
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "createdDateTime")]
    public DateTime CreatedDateTime { get; set; }

    /// <summary>
    /// 事件创建者(google)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "creator")]
    public Recipient Creator { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "end")]
    public Time End { get; set; }

    /// <summary>
    /// 结束时间未指定
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "endTimeUnspecified")]
    public bool EndTimeUnspecified { get; set; }

    /// <summary>
    /// The start time zone that was set when the event was created. 
    /// A value of tzone://Microsoft/Custom indicates that a legacy custom time zone was set in desktop Outlook.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "originalStartTimeZone")]
    public string OriginalStartTimeZone { get; set; }

    /// <summary>
    /// The end time zone that was set when the event was created. 
    /// A value of tzone://Microsoft/Customindicates that a legacy custom time zone was set in desktop Outlook.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "originalEndTimeZone")]
    public string OriginalEndTimeZone { get; set; }

    /// <summary>
    /// 预估耗时
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "estimateMinutes")]
    public int EstimateMinutes { get; set; }

    /// <summary>
    /// 是否有附件
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hasAttachments")]
    public bool HasAttachments { get; set; }

    /// <summary>
    /// 事件的链接
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "htmlLink")]
    public string HtmlLink { get; set; }

    /// <summary>
    /// 事件的重要性。 可取值为：low、normal、high。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "importance")]
    public string Importance { get; set; }

    /// <summary>
    /// 事件持续事件是否为一整天
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isAllDay")]
    public bool IsAllDay { get; set; }

    /// <summary>
    /// 事件是否被取消
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isCancelled")]
    public bool IsCancelled { get; set; }

    /// <summary>
    /// 事件发送者是否是组织者
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isOrganizer")]
    public bool IsOrganizer { get; set; }

    /// <summary>
    /// 是否设置提醒警告
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isReminderOn")]
    public bool IsReminderOn { get; set; }

    /// <summary>
    /// 扩展事件的小工具
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "gadgets")]
    public Gadget Gadgets { get; set; }

    /// <summary>
    /// 与该事件相关的链接
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hangoutLink")]
    public string HangoutLink { get; set; }

    /// <summary>
    /// 额外的参与者是否能够邀请别人(GOOGLE)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "guestsCanInviteOthers")]
    public bool GuestsCanInviteOthers { get; set; }

    /// <summary>
    /// 参与者之间是否可见(GOOGLE)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "guestsCanSeeOtherGuests")]
    public bool GuestsCanSeeOtherGuests { get; set; }

    /// <summary>
    /// 资源类型
    /// </summary>
    [DataMember]
    public string Kind { get; set; }

    /// <summary>
    /// 时间戳
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "lastModifiedDateTime")]
    public DateTime LastModifiedDateTime { get; set; }

    /// <summary>
    /// 发生地点
    /// </summary>
    [DataMember]
    [DisplayName("地点")]
    public Location Location { get; set; }

    /// <summary>
    /// 事件字段锁定
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "locked")]
    public bool Locked { get; set; }

    /// <summary>
    /// 在线会议的url
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "onlineMeetingUrl")]
    public string OnlineMeetingUrl { get; set; }

    /// <summary>
    /// 组织者
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "organizer")]
    public Recipient Organizer { get; set; }

    /// <summary>
    /// 私有事件副本
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "privateCopy")]
    public bool PrivateCopy { get; set; }

    /// <summary>
    /// 事件的定期模式，频次与时间设置
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "recurrence")]
    public Recurrence Recurrence { get; set; }

    /// <summary>
    /// 事件开始时间（即提醒警报发生时间）之前的分钟数。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reminderMinutesBeforeStart")]
    public int ReminderMinutesBeforeStart { get; set; }

    /// <summary>
    /// 提醒设置
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "reminders")]
    public List<Reminder> Reminders { get; set; }

    /// <summary>
    /// 请求响应
    /// 如果发件人希望接收事件被接受或拒绝时的响应，则设置为 true。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "responseRequested")]
    public bool ResponseRequested { get; set; }

    /// <summary>
    /// 事件响应状态
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "responseStatus")]
    public ResponseStatus ResponseStatus { get; set; }

    /// <summary>
    /// 信息敏感度
    /// 可能的值是：normal、personal、private、confidential。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sensitivity")]
    public string Sensitivity { get; set; }

    /// <summary>
    /// 项目类别
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "seriesMasterId")]
    public string SeriesMasterId { get; set; }

    /// <summary>
    /// 日历顺序编号
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sequence")]
    public int Sequence { get; set; }

    /// <summary>
    /// 状态显示
    /// 要显示的状态。 可取值为：free、tentative、busy、oof、workingElsewhere、unknown。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "showAs")]
    public string ShowAs { get; set; }

    /// <summary>
    /// 创建事件文档的链接
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "sources")]
    public Source Sources { get; set; }

    /// <summary>
    /// 创建事件时设置的开始时间
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "originalStartTime")]
    public Time OriginalStartTime { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "start")]
    public Time Start { get; set; }

    /// <summary>
    /// 事件状态
    /// Status of the event. Optional. Possible values are:
    /// "confirmed" - The event is confirmed. This is the default status.
    /// "tentative" - The event is tentatively confirmed.
    /// "cancelled" - The event is cancelled (deleted). The list method returns cancelled events only on incremental sync (when syncToken or updatedMin are specified) or if the showDeleted flag is set to true. The get method always returns them.
    /// 确定、暂定、取消
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "status")]
    public string Status { get; set; }

    /// <summary>
    /// 事件主题文本(MS)
    /// 对应GOOGLE中的summary
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "subject")]
    public string Subject { get; set; }

    /// <summary>
    /// 事件透明，事件是否阻止日历上的时间。
    /// Whether the event blocks time on the calendar. Optional. Possible values are:
    /// "opaque" - Default value.The event does block time on the calendar.This is equivalent to setting Show me as to Busy in the Calendar UI.
    /// "transparent" - The event does not block time on the calendar.This is equivalent to setting Show me as to Available in the Calendar UI.
    /// 不透明(阻止)、透明(不阻止)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "transparency")]
    public string Transparency { get; set; }

    /// <summary>
    /// 事件类型
    /// 事件类型。 可取值为 singleInstance、occurrence、exception、seriesMaster。 
    /// 单实例、事件、异常、序列主机
    /// 只读。
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// 事件的可见性
    /// Visibility of the event. Optional. Possible values are:
    /// "default" - Uses the default visibility for events on the calendar.This is the default value.
    /// "public" - The event is public and event details are visible to all readers of the calendar.
    /// "private" - The event is private and only event attendees may view event details.
    /// "confidential" - The event is private. This value is provided for compatibility reasons.
    /// 默认、公共、私有、机密
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "visibility")]
    public string Visibility { get; set; }

    /// <summary>
    /// 链接地址
    /// 要在 Outlook Web App 中打开事件的 URL。(MS)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "weblink")]
    public string Weblink { get; set; }

    /// <summary>
    /// 数据
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "originalData")]
    public string OriginalData { get; set; }

    #endregion
}
