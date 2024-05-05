//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CalendarServer;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Applications;

/// <summary>
/// 日历服务
/// </summary>
public interface ICalendarServer
{
    /// <summary>
    /// 同步日历组
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    List<Group> SyncGroups(Owner owner);

    /// <summary>
    /// 提交日历组
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="group"></param>
    /// <returns></returns>
    bool PostGroup(Owner owner, Group group);

    /// <summary>
    /// 清除日历组
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="group"></param>
    /// <returns></returns>
    bool RemoveGroup(Owner owner, Group group);

    /// <summary>
    /// 同步日历
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="group"></param>
    /// <returns></returns>
    List<Calendar> SyncCalendars(Owner owner,Group group);

    /// <summary>
    /// 提交日历
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    bool PostCalendar(Owner owner, Calendar calendar);

    /// <summary>
    /// 清除日历
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    bool RemoveCalendar(Owner owner, Calendar calendar);

    /// <summary>
    /// 同步事件
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    List<Event> SyncEvents(Owner owner,Calendar calendar);

    /// <summary>
    /// 提交事件
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="event"></param>
    /// <returns></returns>
    bool PostEvent(Owner owner,Event @event);

    /// <summary>
    /// 清除事件
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="event"></param>
    /// <returns></returns>
    bool RemoveEvent(Owner owner, Event @event);
}
