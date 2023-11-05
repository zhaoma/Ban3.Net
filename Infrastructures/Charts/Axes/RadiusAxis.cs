// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Axes;

/// <summary>
/// 极坐标系的径向轴
/// https://echarts.apache.org/zh/option.html#radiusAxis.id
/// </summary>
public class RadiusAxis
    : GeneralAxis
{
    /// <summary>
    /// 角度轴所在的极坐标系的索引，默认使用第一个极坐标系。
    /// </summary>
    [JsonProperty("polarIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int PolarIndex { get; set; }
}
