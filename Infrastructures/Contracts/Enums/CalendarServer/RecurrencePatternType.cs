//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 
/// </summary>
public enum RecurrencePatternType
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("daily")]
    Daily,
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("weekly")]
    Weekly,
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("absoluteMonthly")]
    AbsoluteMonthly,
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("relativeMonthly")]
    RelativeMonthly,
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("absoluteYearly")]
    AbsoluteYearly,
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("relativeYearly")]
    RelativeYearly
}
