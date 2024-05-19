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
    /// 同步日历组
    /// </summary>
    /// <param name="owner"></param>
    /// <returns></returns>
    public List<CalendarGroup> SyncGroups(Owner owner)
    {
        return new List<CalendarGroup>();
    }

    /// <summary>
    /// 提交日历组
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="group"></param>
    /// <returns></returns>
    public bool PostGroup(Owner owner, CalendarGroup group)
    {
        return true;
    }

    /// <summary>
    /// 清除日历组
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="group"></param>
    /// <returns></returns>
    public bool RemoveGroup(Owner owner, CalendarGroup group)
    {
        return true;
    }
}
