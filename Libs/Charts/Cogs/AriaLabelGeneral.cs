//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    对于图表的整体性描述
//  reference:https://echarts.apache.org/zh/option.html#aria.label.general
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 
/// </summary>
public class AriaLabelGeneral
{
    /// <summary>
    /// 如果图表存在 title.text，则采用 withTitle。
    /// 其中包括模板变量：{title}：将被替换为图表的 title.text。
    /// </summary>
    [JsonProperty("withTitle", NullValueHandling = NullValueHandling.Ignore)]
    public string? WithTitle { get; set; }

    /// <summary>
    /// 如果图表不存在 title.text，则采用 withoutTitle。
    /// </summary>
    [JsonProperty("withoutTitle", NullValueHandling = NullValueHandling.Ignore)]
    public string? WithoutTitle { get; set; }
}
