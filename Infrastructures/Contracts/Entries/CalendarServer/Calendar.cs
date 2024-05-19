//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials.Calendars;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 日历信息
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/calendar
/// https://developers.google.com/calendar/v3/reference/calendars#resource
/// </summary>
public class Calendar: ICalendarOnMicrosoft,ICalendarOnGoogle
{
    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Etag { get; set; } = string.Empty;

    #region Peroperty

    public List<OnlineMeetingProviderType>? AllowedOnlineMeetingProviders { get; set; }

    /// <summary>
    /// 用户在日历的有效角色
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "accessRole")]
    public string AccessRole { get; set; } = string.Empty;

    /// <summary>
    /// 所在日历组
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "groupId")]
    public string GroupId { get; set; } = string.Empty;

    /// <summary>
    /// 背景颜色
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "backgroundColor")]
    public string BackgroundColor { get; set; } = string.Empty;

    public bool CanEdit { get; set; } = true;

    public bool CanShare { get; set; } = true;

    public bool CanViewPrivateItems { get; set; } = true;

    /// <summary>
    /// 日历版本标识
    /// Identifies the version of the calendar object. 
    /// Every time the calendar is changed, changeKey changes as well. 
    /// This allows Exchange to apply changes to the correct version of the object. 
    /// Read-only.
    /// 对应GOOGLE的ETag
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "changeKey")]
    public string ChangeKey { get; set; } = string.Empty;

    public CalendarColor Color { get; set; }

    /// <summary>
    /// 日历颜色ID
    /// Specifies the color theme to distinguish the calendar from other calendars in a UI. 
    /// The property values are: LightBlue=0, LightGreen=1, LightOrange=2, LightGray=3, LightYellow=4, LightTeal=5, LightPink=6, LightBrown=7, LightRed=8, MaxColor=9, Auto=-1
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "colorId")]
    [JsonConverter(typeof(StringEnumConverter))]
    public CalendarColor ColorId { get; set; }

    public OnlineMeetingProviderType? DefaultOnlineMeetingProvider { get; set; }

    public string HexColor { get; set; } = string.Empty;

    public bool IsDefaultCalendar { get; set; } = true;

    public bool IsRemovable { get; set; } = true;

    public bool IsTallyingResponses { get; set; } = true;

    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 此日历上默认提醒(GOOGLE)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "defaultReminders")]
    public List<Reminder>? DefaultReminders { get; set; }

    /// <summary>
    /// 是否从列表中删除这个条目
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "deleted")]
    public bool Deleted { get; set; }

    /// <summary>
    /// 前景颜色
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "foregroundColor")]
    public string ForegroundColor { get; set; } = string.Empty;

    /// <summary>
    /// 日历是否被隐藏在列表中
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hidden")]
    public bool Hidden { get; set; }

    public string Kind { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    ///// <summary>
    ///// 已验证用户接受此日历通知
    ///// </summary>
    //
    //public NotificationSettings NotificationSettings { get; set; }

    /// <summary>
    /// 源数据
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "originalData")]
    public string OriginalData { get; set; } = string.Empty;

    public EmailAddress? Owner { get; set; }

    /// <summary>
    /// 日历是否为认证用户设置的主日历
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "primary")]
    public bool Primary { get; set; }

    /// <summary>
    /// 日历内容是否显示在日历UI中
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "selected")]
    public bool Selected { get; set; }

    /// <summary>
    /// 已验证用户为该日历设置的摘要
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "summaryOverride")]
    public string SummaryOverride { get; set; } = string.Empty;

    public string TimeZone { get; set; } = string.Empty;

    /// <summary>
    /// 事件信息
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "events")]
    public List<Event>? Events { get; set; }

    #endregion

    public IConferenceProperty? ConferenceProperties { get; set; }
}
