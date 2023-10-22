using System.Collections.Generic;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Kalendar;

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
    out IEnumerable<ICalendar> calendars);
}