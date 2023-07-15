//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Cogs;

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