//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials.Calendars;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 周期时段定义
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/recurrencerange
/// </summary>
public class RecurrenceRange : IRecurrenceRange
{
    [JsonConverter(typeof(StringEnumConverter))]
    public RecurrenceRangeType Type { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string RecurrenceTimeZone { get; set; }

    public int? NumberOfOccurrences { get; set; }
}
