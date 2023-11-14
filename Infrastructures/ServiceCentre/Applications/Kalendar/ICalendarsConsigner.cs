// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Kalendar;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Kalendar;

public interface ICalendarsConsigner
{
    Task<bool> TryCreateCalendar(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        ICalendar calendar
    );

    Task<bool> TryRetrieveCalendars(
        ICalendarPlatform calendarPlatform,
        ICalendarOwner calendarOwner,
        out IEnumerable<ICalendar> calendars
    );
}