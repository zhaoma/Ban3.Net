// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Axes;

/// <summary>
/// 单轴。可以被应用到散点图中展现一维数据。
/// https://echarts.apache.org/en/option.html#singleAxis
/// </summary>
public class SingleAxis
    : GeneralAxis, IHasPosition
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="data"></param>
    public SingleAxis(ECharts.AxisType type, object? data)
    {
        Type = type;
        Data = data;
    }

    #region IHasPosition

    /// 
    public object? Left { get; set; }

    /// 
    public object? Top { get; set; }

    /// 
    public object? Right { get; set; }

    /// 
    public object? Bottom { get; set; }

    ///
    public object? Width { get; set; }

    /// 
    public object? Height { get; set; }

    #endregion

    /// <summary>
    /// The layout orientation of legend.
    /// </summary>
    [JsonProperty("orient", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Orient? Orient { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
    public Tooltip? Tooltip { get; set; }
}
