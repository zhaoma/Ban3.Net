//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials.Calendars;
using System;
using System.Collections.Generic;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 重复周期定义
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/recurrencepattern
/// </summary>
public class RecurrencePattern : IRecurrencePattern
{
    public RecurrencePatternType Type { get; set; }

    public int Interval { get; set; }

    public int Month { get; set; }

    public int DayOfMonth { get; set; }

    public List<DayOfWeek>? DaysOfWeek { get; set; }

    public DayOfWeek FirstDayOfWeek { get; set; } = DayOfWeek.Sunday;

    public string Index { get; set; }
}
