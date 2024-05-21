//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials;
using Ban3.Infrastructures.Contracts.Materials.Calendars;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 日历信息
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/calendar
/// 
/// </summary>
public class Calendar : ICalendarOnMicrosoft, ICalendarOnGoogle, IZero
{
    /// <summary>
    /// 所在日历组
    /// </summary>
    public string GroupId { get; set; } = string.Empty;

    /// <summary>
    /// 事件信息
    /// </summary>
    public List<Event>? Events { get; set; }

    public string Id { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Etag { get; set; } = string.Empty;

    public string ChangeKey { get; set; } = string.Empty;

    public List<OnlineMeetingProviderType>? AllowedOnlineMeetingProviders { get; set; }

    public bool CanEdit { get; set; } = true;

    public bool CanShare { get; set; } = true;

    public bool CanViewPrivateItems { get; set; } = true;

    public CalendarColor Color { get; set; }

    public OnlineMeetingProviderType? DefaultOnlineMeetingProvider { get; set; }

    public string HexColor { get; set; } = string.Empty;

    public bool IsDefaultCalendar { get; set; } = true;

    public bool IsRemovable { get; set; } = true;

    public bool IsTallyingResponses { get; set; } = true;

    public string Description { get; set; }

    public string Kind { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string Summary { get; set; } = string.Empty;

    public EmailAddress? Owner { get; set; }

    public string TimeZone { get; set; } = string.Empty;

    public IConferenceProperty? ConferenceProperties { get; set; }
}
