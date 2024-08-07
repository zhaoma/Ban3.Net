﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace Ban3.Infrastructures.Contracts.Materials.Calendars;

/// <summary>
/// 重复周期定义
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/recurrencepattern
/// </summary>
public interface IRecurrencePattern : IZero
{
    /// <summary>
    /// 重复类型
    /// The recurrence pattern type: daily, weekly, absoluteMonthly, relativeMonthly, absoluteYearly, relativeYearly. Required.
    /// 
    /// daily:Event repeats based on the number of days specified by interval between occurrences.
    /// (type, interval) Repeat event every 3 days.
    /// weekly:Event repeats on the same day or days of the week, based on the number of weeks between each set of occurrences.
    /// (type, interval, daysOfWeek, firstDayOfWeek) Repeat event Monday and Tuesday of every other week.
    /// absoluteMonthly:Event repeats on the specified day of the month (e.g. the 15th), based on the number of months between occurrences.
    /// (type, interval, dayOfMonth)Repeat event quarterly (every 3 months) on the 15th.
    /// relativeMonthly:Event repeats on the specified day or days of the week, in the same relative position in the month, based on the number of months between occurrences.
    /// (type, interval, daysOfWeek)Repeat event on the second Thursday or Friday every three months.
    /// absoluteYearly:Event repeats on the specified day and month, based on the number of years between occurrences.
    /// (type, interval, dayOfMonth, month)Repeat event on the 15th of March every 3 years.
    /// relativeYearly:Event repeats on the specified day or days of the week, in the same relative position in a specific month of the year, based on the number of years between occurrences.
    /// (type, interval, daysOfWeek, month)Repeat event on the second Thursday or Friday of every November every 3 years.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    RecurrencePatternType Type { get; set; }

    /// <summary>
    /// 间隔
    /// The number of units between occurrences, where units can be in days, weeks, months, or years, depending on the type. Required.
    /// </summary>
    int Interval { get; set; }

    /// <summary>
    /// 某月(按年重复)
    /// The month in which the event occurs.  This is a number from 1 to 12.
    /// </summary>
    int Month { get; set; }

    /// <summary>
    /// 某日(按年/按月重复)
    /// The day of the month on which the event occurs. Required if type is absoluteMonthly or absoluteYearly.
    /// </summary>
    int DayOfMonth { get; set; }

    /// <summary>
    /// 每周中的几日
    /// The possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. 
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    List<DayOfWeek>? DaysOfWeek { get; set; }

    /// <summary>
    /// 每周开始于
    /// The first day of the week. The possible values are: sunday, monday, tuesday, wednesday, thursday, friday, saturday. 
    /// Default is sunday. Required if type is weekly.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    DayOfWeek FirstDayOfWeek { get; set; }

    /// <summary>
    /// Specifies on which instance of the allowed days specified in daysOfsWeek the event occurs, counted from the first instance in the month. 
    /// The possible values are: first, second, third, fourth, last. Default is first.
    /// </summary>
    string Index { get; set; }
}
