//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 13:23
//  function:	Graphic.cs
//  reference:	https://echarts.apache.org/en/option.html#graphic
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Cogs;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Components;

/// <summary>
/// graphic component enables creating graphic elements in ECharts.
/// </summary>
public class Graphic
{
    /// 
    [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
    public string? Id { get; set; }

    /// 
    [JsonProperty("elements", NullValueHandling = NullValueHandling.Ignore)]
    public GraphicElement[]? Elements { get; set; }
}

