//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CalendarServer;
using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;
public interface IEventOnGoogle : IZero
{
    /// <summary>
    /// 选择自己是否可被邀请（GOOGLE）
    /// Whether anyone can invite themselves to the event (currently works for Google+ events only). Optional. 
    /// The default is False.
    /// </summary>
    bool AnyoneCanAddSelf { get; set; }

    /// <summary>
    /// 附件
    /// </summary>
    IEnumerable<Attachment>? Attachments { get; set; }

    /// <summary>
    /// 参会者是否被遗漏(google)
    /// </summary>
    bool AttendeesOmitted { get; set; }

    /// <summary>
    /// 
    /// </summary>
    IEnumerable<Attendee>? Attendees { get; set; }

    /// <summary>
    /// 事件颜色id(google)
    /// </summary>
    string ColorId { get; set; }

    /// <summary>
    /// 事件创建时间(google)
    /// </summary>
    DateTime Created { get; set; }

    /// <summary>
    /// 事件创建者(google)
    /// </summary>
    IOrganizer Creator { get; set; }

    /// <summary>
    /// 
    /// </summary>
    string Description { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    ITime End { get; set; }

    /// <summary>
    /// 资源的 ETag。
    /// </summary>
    string Etag { get; set; }

    /// <summary>
    /// 
    /// </summary>
    EventType EventType { get; set; }

    /// <summary>
    /// 扩展事件的小工具
    /// </summary>
    Gadget? Gadget { get; set; }

    /// <summary>
    /// 额外的参与者是否能够邀请别人(GOOGLE)
    /// </summary>
    bool GuestsCanInviteOthers { get; set; }

    bool GuestsCanModify { get; set; }

    /// <summary>
    /// 参与者之间是否可见(GOOGLE)
    /// </summary>
    bool GuestsCanSeeOtherGuests { get; set; }

    /// <summary>
    /// 与该事件相关的链接
    /// </summary>
    string HangoutLink { get; set; }

    /// <summary>
    /// 事件的链接
    /// </summary>
    string HtmlLink { get; set; }


    /// <summary>
    /// 由不同日历间的所有事件实例共享的唯一标识符。 只读。
    /// </summary>
    string iCalUId { get; set; }

    /// <summary>
    /// 结束时间未指定
    /// </summary>
    bool EndTimeUnspecified { get; set; }

    /// <summary>
    /// 
    /// </summary>
    string Id { get; set; }

    /// <summary>
    /// 资源类型
    /// </summary>
    string Kind { get; set; }

    /// <summary>
    /// 发生地点
    /// </summary>
    ILocation? Location { get; set; }

    /// <summary>
    /// 事件字段锁定
    /// </summary>
    bool Locked { get; set; }

    /// <summary>
    /// 组织者
    /// </summary>
    IOrganizer Organizer { get; set; }

    /// <summary>
    /// 创建事件时设置的开始时间
    /// </summary>
    ITime OriginalStartTime { get; set; }

    /// <summary>
    /// 私有事件副本
    /// </summary>
    bool PrivateCopy { get; set; }

    /// <summary>
    /// 事件的定期模式，频次与时间设置
    /// </summary>
    IRecurrence? Recurrence { get; set; }

    /// <summary>
    /// 提醒设置
    /// </summary>
    Reminders? Reminders { get; set; }

    /// <summary>
    /// 日历顺序编号
    /// </summary>
    int Sequence { get; set; }

    /// <summary>
    /// 
    /// </summary>
    string Source { get; set; }

    /// <summary>
    /// 开始时间
    /// </summary>
    ITime Start { get; set; }

    /// <summary>
    /// 事件状态
    /// Status of the event. Optional. Possible values are:
    /// "confirmed" - The event is confirmed. This is the default status.
    /// "tentative" - The event is tentatively confirmed.
    /// "cancelled" - The event is cancelled (deleted). The list method returns cancelled events only on incremental sync (when syncToken or updatedMin are specified) or if the showDeleted flag is set to true. The get method always returns them.
    /// 确定、暂定、取消
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    EventStatus Status { get; set; }

    /// <summary>
    /// 
    /// </summary>
    string Summary { get; set; }

    /// <summary>
    /// 事件透明，事件是否阻止日历上的时间。
    /// Whether the event blocks time on the calendar. Optional. Possible values are:
    /// "opaque" - Default value.The event does block time on the calendar.This is equivalent to setting Show me as to Busy in the Calendar UI.
    /// "transparent" - The event does not block time on the calendar.This is equivalent to setting Show me as to Available in the Calendar UI.
    /// 不透明(阻止)、透明(不阻止)
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    EventTransparency? Transparency { get; set; }

    /// <summary>
    /// 
    /// </summary>
    DateTime Updated { get; set; }

    /// <summary>
    /// 事件的可见性
    /// Visibility of the event. Optional. Possible values are:
    /// "default" - Uses the default visibility for events on the calendar.This is the default value.
    /// "public" - The event is public and event details are visible to all readers of the calendar.
    /// "private" - The event is private and only event attendees may view event details.
    /// "confidential" - The event is private. This value is provided for compatibility reasons.
    /// 默认、公共、私有、机密
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    EventVisibility? Visibility { get; set; }
}
