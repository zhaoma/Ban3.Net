// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class TreemapLevel
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public ItemStyle? ItemStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("upperLabel", NullValueHandling = NullValueHandling.Ignore)]
    public Label? UpperLabel { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Emphasis { get; set; }
}