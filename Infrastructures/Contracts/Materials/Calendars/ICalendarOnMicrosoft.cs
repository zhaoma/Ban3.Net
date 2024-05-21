//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using Ban3.Infrastructures.Contracts.Entries.CalendarServer;
using Newtonsoft.Json.Serialization;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;

/// <summary>
/// 日历信息
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/calendar
/// </summary>
public interface ICalendarOnMicrosoft : IZero
{
    /// <summary>
    /// Represent the online meeting service providers that can be used to create online meetings in this calendar. 
    /// Possible values are: unknown, skypeForBusiness, skypeForConsumer, teamsForBusiness.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "allowedOnlineMeetingProviders")]
    [JsonConverter(typeof(StringEnumConverter))]
    List<OnlineMeetingProviderType>? AllowedOnlineMeetingProviders { get; set; }

    /// <summary>
    ///日历编辑
    /// True if the user can write to the calendar, false otherwise. 
    /// This property is true for the user who created the calendar. 
    /// This property is also true for a user who has been shared a calendar and granted write access.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "canEdit")]
    bool CanEdit { get; set; }

    /// <summary>
    /// 日历分享
    /// True if the user has the permission to share the calendar, false otherwise. 
    /// Only the user who created the calendar can share it.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "canShare")]
    bool CanShare { get; set; }

    /// <summary>
    /// 日历私人主题
    /// True if the user can read calendar items that have been marked private, false otherwise.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "canViewPrivateItems")]
    bool CanViewPrivateItems { get; set; }

    /// <summary>
    /// 日历颜色主题
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "color")]
    [JsonConverter(typeof(StringEnumConverter))]
    CalendarColor Color { get; set; }

    /// <summary>
    /// The default online meeting provider for meetings sent from this calendar. 
    /// Possible values are: unknown, skypeForBusiness, skypeForConsumer, teamsForBusiness.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "defaultOnlineMeetingProvider")]
    [JsonConverter(typeof(StringEnumConverter))]
    OnlineMeetingProviderType? DefaultOnlineMeetingProvider { get; set; }

    /// <summary>
    /// The calendar color, expressed in a hex color code of three hexadecimal values, 
    /// each ranging from 00 to FF and representing the red, green, 
    /// or blue components of the color in the RGB color space. 
    /// If the user has never explicitly set a color for the calendar, 
    /// this property is empty. Read-only.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "hexColor")]
    string HexColor { get; set; }

    /// <summary>
    /// The calendar's unique identifier. 
    /// Read-only.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "id")]
    string Id { get; set; }

    /// <summary>
    /// 日历版本标识
    /// Identifies the version of the calendar object. 
    /// Every time the calendar is changed, changeKey changes as well. 
    /// This allows Exchange to apply changes to the correct version of the object. 
    /// Read-only.
    /// 对应GOOGLE的ETag
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "changeKey")]
    string ChangeKey { get; set; }

    /// <summary>
    /// true if this is the default calendar where new events are created by default, false otherwise.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isDefaultCalendar")]
    bool IsDefaultCalendar { get; set; }

    /// <summary>
    /// Indicates whether this user calendar can be deleted from the user mailbox.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isRemovable")]
    bool IsRemovable { get; set; }

    /// <summary>
    /// Indicates whether this user calendar supports tracking of meeting responses. 
    /// Only meeting invites sent from users' primary calendars support tracking of meeting responses.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "isTallyingResponses")]
    bool IsTallyingResponses { get; set; }

    /// <summary>
    /// 日历名称(MS)
    /// The calendar name.
    /// 对应GOOGLE的SUMMARY
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "name")]
    string Name { get; set; }

    /// <summary>
    /// 日历拥有者信息
    /// If set, this represents the user who created or added the calendar. 
    /// For a calendar that the user created or added, the owner property is set to the user. 
    /// For a calendar shared with the user, the owner property is set to the person who shared that calendar with the user.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "owner")]
    EmailAddress? Owner { get; set; }
}
