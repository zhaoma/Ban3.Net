//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    极坐标系的角度轴
//  reference:	    https://echarts.apache.org/en/option.html#angleAxis
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Ban3.Infrastructures.Charts.Elements;

namespace Ban3.Infrastructures.Charts.Axes;

/// <summary>
/// 极坐标系的角度轴
/// The angle axis in Polar Coordinate.
/// </summary>
public class AngleAxis
    : GeneralAxis
{
    /// <summary>
    /// 角度轴所在的极坐标系的索引，默认使用第一个极坐标系。
    /// </summary>
    [JsonProperty("polarIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int? PolarIndex { get; set; }

    /// <summary>
    /// 起始刻度的角度，默认为 90 度，即圆心的正上方。0 度为圆心的正右方。
    /// </summary>
    [JsonProperty("startAngle", NullValueHandling = NullValueHandling.Ignore)]
    public int? StartAngle { get; set; } = 90;

    /// <summary>
    /// 刻度增长是否按顺时针，默认顺时针。
    /// </summary>
    [JsonProperty("clockwise", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Clockwise { get; set; } = true;
}
