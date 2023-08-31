//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

public class IconEmphasis
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("iconStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? IconStyle { get; set; }
}
