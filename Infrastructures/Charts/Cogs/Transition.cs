// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class Transition
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("enabled", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("seriesKey", NullValueHandling = NullValueHandling.Ignore)]
    public string? SeriesKey { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("divideShape", NullValueHandling = NullValueHandling.Ignore)]
    public ECharts.DivideShape? DivideShape { get; set; }
}