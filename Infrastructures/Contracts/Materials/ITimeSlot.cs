using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Materials;

/// <summary>
/// Represents a time slot for a meeting.
/// https://learn.microsoft.com/en-us/graph/api/resources/timeslot?view=graph-rest-1.0
/// </summary>
public interface ITimeSlot
{
    /// <summary>
    /// 开始时间
    /// </summary>
    [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
    ITime Start { get; set; }

    /// <summary>
    /// 结束时间
    /// </summary>
    [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
    ITime End { get; set; }
}
