//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// Visibility of the event.
/// </summary>
public enum EventVisibility
{
    /// <summary>
    /// Uses the default visibility for events on the calendar.This is the default value.
    /// </summary>
    Default,

    /// <summary>
    /// The event is public and event details are visible to all readers of the calendar.
    /// </summary>
    Public,

    /// <summary>
    /// The event is private and only event attendees may view event details.
    /// </summary>
    Private,

    /// <summary>
    /// The event is private. This value is provided for compatibility reasons.
    /// </summary>
    Confidential
}
