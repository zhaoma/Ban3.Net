//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Entries.Kalendar;

#nullable enable
namespace Ban3.Infrastructures.ServiceCentre.Applications.Kalendar;

/// <summary>
/// 
/// </summary>
public interface ICalendarsConsigner
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="calendarPlatform"></param>
    /// <param name="calendarOwner"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    Task<bool> TryCreateCalendar( ICalendarPlatform calendarPlatform, ICalendarOwner calendarOwner, ICalendar calendar );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="calendarPlatform"></param>
    /// <param name="calendarOwner"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryRetrieveCalendars( ICalendarPlatform calendarPlatform, ICalendarOwner calendarOwner, Action<IEnumerable<ICalendar>>? action );
}