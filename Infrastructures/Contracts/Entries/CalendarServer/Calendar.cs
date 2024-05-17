//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 日历
/// </summary>
public class Calendar
{

    #region Peroperty

    /// <summary>
    /// 用户在日历的有效角色
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "accessRole")]
    public string AccessRole { get; set; }

    /// <summary>
    /// 所在日历组
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "groupId")]
    public string GroupId { get; set; }

    /// <summary>
    /// 背景颜色
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "backgroundColor")]
    public string BackgroundColor { get; set; }

    /// <summary>
    ///日历编辑
    /// True if the user can write to the calendar, false otherwise. 
    /// This property is true for the user who created the calendar. 
    /// This property is also true for a user who has been shared a calendar and granted write access.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "canEdit")]
    public bool CanEdit { get; set; }

    /// <summary>
    /// 日历分享
    /// True if the user has the permission to share the calendar, false otherwise. 
    /// Only the user who created the calendar can share it.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "canShare")]
    public bool CanShare { get; set; }

    /// <summary>
    /// 日历私人主题
    /// True if the user can read calendar items that have been marked private, false otherwise.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "canViewPrivateItems")]
    public bool CanViewPrivateItems { get; set; }

    /// <summary>
    /// 日历版本标识
    /// Identifies the version of the calendar object. 
    /// Every time the calendar is changed, changeKey changes as well. 
    /// This allows Exchange to apply changes to the correct version of the object. 
    /// Read-only.
    /// 对应GOOGLE的ETag
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "changeKey")]
    public string ChangeKey { get; set; }

    /// <summary>
    /// 日历颜色主题
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "color")]
    public string Color { get; set; }

    /// <summary>
    /// 日历颜色ID
    /// Specifies the color theme to distinguish the calendar from other calendars in a UI. 
    /// The property values are: LightBlue=0, LightGreen=1, LightOrange=2, LightGray=3, LightYellow=4, LightTeal=5, LightPink=6, LightBrown=7, LightRed=8, MaxColor=9, Auto=-1
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "colorId")]
    public string ColorId { get; set; }

    /// <summary>
    /// 日历描述(GOOGLE)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// 此日历上默认提醒(GOOGLE)
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "defaultReminders")]
    public List<Reminder> DefaultReminders { get; set; }

    /// <summary>
    /// 是否从列表中删除这个条目
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "deleted")]
    public bool Deleted { get; set; }

    /// <summary>
    /// 前景颜色
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "foregroundColor")]
    public string ForegroundColor { get; set; }

    /// <summary>
    /// 日历是否被隐藏在列表中
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hidden")]
    public bool Hidden { get; set; }

    /// <summary>
    /// 日历类型(GOOGLE)
    /// Type of the resource ("calendar#calendar").
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "kind")]
    public string Kind { get; set; }

    /// <summary>
    /// 地理位置(GOOGLE)
    /// Geographic location of the calendar as free-form text. 
    /// Optional.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "location")]
    public string Location { get; set; }

    /// <summary>
    /// 日历名称(MS)
    /// The calendar name.
    /// 对应GOOGLE的SUMMARY
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
    public string Name { get; set; }

    ///// <summary>
    ///// 已验证用户接受此日历通知
    ///// </summary>
    //[DataMember]
    //public NotificationSettings NotificationSettings { get; set; }

    /// <summary>
    /// 源数据
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "originalData")]
    public string OriginalData { get; set; }

    /// <summary>
    /// 日历拥有者信息
    /// If set, this represents the user who created or added the calendar. 
    /// For a calendar that the user created or added, the owner property is set to the user. 
    /// For a calendar shared with the user, the owner property is set to the person who shared that calendar with the user.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "owner")]
    public EmailAddress Owner { get; set; }

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
    public string SummaryOverride { get; set; }

    /// <summary>
    /// 日历时区(GOOGLE)
    /// The time zone of the calendar. (Formatted as an IANA Time Zone Database name, e.g. "Europe/Zurich".) 
    /// Optional.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "timeZone")]
    public string TimeZone { get; set; }

    /// <summary>
    /// 事件信息
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "events")]
    public List<Event> Events { get; set; }

    #endregion
}
