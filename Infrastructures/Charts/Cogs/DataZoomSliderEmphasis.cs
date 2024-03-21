// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 缩放图示
/// </summary>
public class DataZoomSliderEmphasis
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("handleStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? HandleStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("moveHandleStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? MoveHandleStyle { get; set; }
}