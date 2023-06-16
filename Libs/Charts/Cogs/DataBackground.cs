//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 数据阴影的样式
/// </summary>
public class DataBackground
{
    /// <summary>
    /// 阴影的线条样式
    /// </summary>
    [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
    public LineStyle? LineStyle { get; set; }

    /// <summary>
    /// 阴影的填充样式
    /// </summary>
    [JsonProperty("areaStyle", NullValueHandling = NullValueHandling.Ignore)]
    public AreaStyle? AreaStyle { get; set; }
}