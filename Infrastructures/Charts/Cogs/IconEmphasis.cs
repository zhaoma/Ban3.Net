// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class IconEmphasis
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("iconStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? IconStyle { get; set; }
}
