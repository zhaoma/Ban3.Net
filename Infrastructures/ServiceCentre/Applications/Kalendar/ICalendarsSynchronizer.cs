// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Kalendar;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Kalendar;

public interface ICalendarsSynchronizer
{
    Task<bool> TrySaveGroup(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        ICalendarGroup calendarGroup
    );

    Task<bool> TryRetrieveGroups(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        out IEnumerable<ICalendarGroup> calendarGroups );

    Task<bool> TryDeleteGroup(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        ICalendarGroup calendarGroup
    );

    Task<bool> TrySaveCalendar(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        ICalendar calendar
    );

    Task<bool> TryRetrieveCalendars(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        out IEnumerable<ICalendar> calendars );

    Task<bool> TryDeleteCalendar(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        ICalendar calendar
    );

    Task<bool> TrySaveEvent(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        ICalendarEvent calendarEvent
    );

    Task<bool> TryRetrieveEvents(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        out IEnumerable<ICalendarEvent> calendarEvents );

    Task<bool> TryDeleteEvent(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        ICalendarEvent calendarEvent
    );
}