// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Cogs;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Ban3.Infrastructures.Charts.Elements;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Axes;

/// <summary>
/// 直角坐标系 grid 中的轴
/// https://echarts.apache.org/zh/option.html#xAxis
/// </summary>
public class CartesianAxis
    : GeneralAxis
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="scale"></param>
    /// <param name="showSplitArea"></param>
    /// <param name="gridIndex"></param>
    public CartesianAxis(bool scale, bool showSplitArea, int? gridIndex = null)
    {
        Scale = scale;
        SplitArea = new SplitArea() { Show = showSplitArea };
        GridIndex = gridIndex;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="data"></param>
    /// <param name="gridIndex"></param>
    /// <param name="show"></param>
    public CartesianAxis(ECharts.AxisType type, object? data, int? gridIndex, bool? show)
    {
        Type = type;
        Data = data;
        GridIndex = gridIndex;
        Show = show;
    }

    /// <summary>
    /// The index of grid which the x axis belongs to. 
    /// Defaults to be in the first grid.
    /// </summary>
    [JsonProperty("gridIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int? GridIndex { get; set; }

    /// <summary>
    /// alignTicks turned on to automatically align ticks when multiple numeric x axes. 
    /// Only available for axes of type 'value' and 'log'.
    /// </summary>
    [JsonProperty("alignTicks", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AlignTicks { get; set; }

    /// <summary>
    /// The position of axis.
    /// top or bottom
    /// </summary>
    [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Position? Position { get; set; }

    /// <summary>
    /// Offset of x axis relative to default position. 
    /// Useful when multiple x axis has same position value.
    /// Notice: Set xAxis.axisLine.onZero to false to activate this option.
    /// </summary>
    [JsonProperty("offset", NullValueHandling = NullValueHandling.Ignore)]
    public int? Offset { get; set; }
}