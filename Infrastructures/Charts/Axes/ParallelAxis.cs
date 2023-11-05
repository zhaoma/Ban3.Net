// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Axes;

/// <summary>
/// This component is the coordinate axis for parallel coordinate.
/// https://echarts.apache.org/en/option.html#parallelAxis
/// </summary>
public class ParallelAxis
    : GeneralAxis
{
    /// <summary>
    /// Dimension index of coordinate axis.
    /// dim defines which dimension (which row) of data would map to this axis.
    /// Started from 0. For example, if the dim of coordinate axis is 1, 
    /// it indicates that the second row of data would map to this axis.
    /// </summary>
    [JsonProperty("dim", NullValueHandling = NullValueHandling.Ignore)]
    public int? Dim { get; set; }

    /// <summary>
    /// It is used to define which coordinate the axis should map to.
    /// If there is only one parallel coordinate, 
    /// you don't have to configure it, whose default value is 0.
    /// </summary>
    [JsonProperty("parallelIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int? ParallelIndex { get; set; }

    /// <summary>
    /// Whether to refresh view when brush-selecting axis. If is set to be false, 
    /// view is updated after brush-selecting action ends.
    /// When data amount is large, 
    /// it is suggested to set to be false to avoid efficiency problems.
    /// </summary>
    [JsonProperty("realtime", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Realtime { get; set; }

    /// <summary>
    /// Area selecting is available on axes.
    /// </summary>
    [JsonProperty("areaSelectStyle", NullValueHandling = NullValueHandling.Ignore)]
    public SelectStyle? AreaSelectStyle { get; set; }
}
