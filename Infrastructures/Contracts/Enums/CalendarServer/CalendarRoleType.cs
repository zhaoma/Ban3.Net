//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

public enum CalendarRoleType
{
    /// <summary>
    /// Calendar isn't shared with the user.
    /// </summary>
    None,

    /// <summary>
    /// User is a recipient who can view free/busy status of the owner on the calendar.
    /// </summary>
    FreeBusyRead,

    /// <summary>
    /// User is a recipient who can view free/busy status, and titles and locations of the events on the calendar.
    /// </summary>
    LimitedRead,

    /// <summary>
    /// User is a recipient who can view all the details of the events on the calendar, except for the owner's private events.
    /// </summary>
    Read,

    /// <summary>
    /// User is a recipient who can view all the details (except for private events) and edit events on the calendar.
    /// </summary>
    Write,

    /// <summary>
    /// User is a delegate who has write access but can't view information of the owner's private events on the calendar.
    /// </summary>
    DelegateWithoutPrivateEventAccess,

    /// <summary>
    /// User is a delegate who has write access and can view information of the owner's private events on the calendar.
    /// </summary>
    DelegateWithPrivateEventAccess,

    /// <summary>
    /// User has custom permissions to the calendar.
    /// </summary>
    Custom
}
