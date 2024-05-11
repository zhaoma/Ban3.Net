//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CalendarServer;
using System.Collections.Generic;

namespace Ban3.Implements.Alpha.Applications;

/// <summary>
/// 
/// </summary>
public partial class CalendarServer
{
    /// <summary>
    /// 同步日历
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="group"></param>
    /// <returns></returns>
    public List<Calendar> SyncCalendars(Owner owner, Group group)
    {
        return new List<Calendar>();
    }

    /// <summary>
    /// 提交日历
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public bool PostCalendar(Owner owner, Calendar calendar)
    {
        return true;
    }

    /// <summary>
    /// 清除日历
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public bool RemoveCalendar(Owner owner, Calendar calendar)
    {
        return true;
    }

}
