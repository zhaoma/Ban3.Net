// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Styles;

/// <summary>
/// https://echarts.apache.org/en/option.html#series-treemap.itemStyle
/// </summary>
public class ItemStyle
    : GeneralStyle
{
    /// <summary>
    /// Gaps between child nodes.
    /// </summary>
    [JsonProperty("gapWidth", NullValueHandling = NullValueHandling.Ignore)]
    public int? GapWidth { get; set; }
    
}