using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// The recurrence range.
/// </summary>
public enum RecurrenceRangeType
{
    /// <summary>
    /// Event repeats on all the days that fit the corresponding recurrence pattern 
    /// between the startDate and endDate inclusive.
    /// </summary>
    [JsonProperty("endDate")]
    EndDate,

    /// <summary>
    /// Event repeats on all the days that fit the corresponding recurrence pattern beginning on the startDate.
    /// </summary>
    [JsonProperty("noEnd")]
    NoEnd,

    /// <summary>
    /// Event repeats for the numberOfOccurrences based on the recurrence pattern beginning on the startDate.
    /// </summary>
    [JsonProperty("numbered")]
    Numbered
}
