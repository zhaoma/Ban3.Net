using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 周期时段定义
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/recurrencerange
/// </summary>
public class RecurrenceRange
{
    /// <summary>
    /// 类型（开始时间/终止时间）
    /// The recurrence range. The possible values are: endDate, noEnd, numbered. Required.
    /// 
    /// endDate:Event repeats on all the days that fit the corresponding recurrence pattern between the startDate and endDate inclusive.
    /// (type, startDate, endDate)Repeat event in the date range between June 1, 2017 and June 15, 2017.	
    /// noEnd:Event repeats on all the days that fit the corresponding recurrence pattern beginning on the startDate.
    /// (type, startDate)Repeat event in the date range starting on June 1, 2017 indefinitely.
    /// numbered:Event repeats for the numberOfOccurrences based on the recurrence pattern beginning on the startDate.
    /// (type, startDate, numberOfOccurrences)Repeat event in the date range starting on June 1, 2017, for 10 occurrences.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// 开始时间
    /// The date to start applying the recurrence pattern. 
    /// The first occurrence of the meeting may be this date or later, depending on the recurrence pattern of the event. 
    /// Must be the same value as the start property of the recurring event. 
    /// Required.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "startDate")]
    public DateTime StartDate { get; set; }

    /// <summary>
    /// 结束时间
    /// The date to stop applying the recurrence pattern. 
    /// Depending on the recurrence pattern of the event, the last occurrence of the meeting may not be this date. 
    /// Required if type is endDate.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "endDate")]
    public DateTime? EndDate { get; set; }

    /// <summary>
    /// 时区设置
    /// Time zone for the startDate and endDate properties. 
    /// Optional. If not specified, the time zone of the event is used.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "recurrenceTimeZone")]
    public string RecurrenceTimeZone { get; set; }

    /// <summary>
    /// 重复次数
    /// The number of times to repeat the event. 
    /// Required and must be positive if type is numbered.
    /// </summary>
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "numberOfOccurrences")]
    public int NumberOfOccurrences { get; set; }
}
