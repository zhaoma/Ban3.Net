﻿using Ban3.Infrastructures.Contracts.Entries.CalendarServer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Implements.Alpha.Applications;

public partial class CalendarServer
{
    /// <summary>
    /// 同步事件
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="calendar"></param>
    /// <returns></returns>
    public List<Event> SyncEvents(Owner owner, Calendar calendar)
    {
        return new List<Event>();
    }

    /// <summary>
    /// 提交事件
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="event"></param>
    /// <returns></returns>
    public bool PostEvent(Owner owner, Event @event)
    {
        return true;
    }

    /// <summary>
    /// 清除事件
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="event"></param>
    /// <returns></returns>
    public bool RemoveEvent(Owner owner, Event @event)
    {
        return true;
    }

}
