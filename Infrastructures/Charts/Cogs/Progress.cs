// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;
using Ban3.Infrastructures.Charts.Labels;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class Progress
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
    public LineStyle? LineStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? ItemStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public Label? Label { get; set; }
}