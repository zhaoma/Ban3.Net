//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 13:22
//  function:	Timeline.cs
//  reference:	https://echarts.apache.org/en/option.html#timeline
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Components;

/// <summary>
/// timeline component, which provides functions like switching and playing between multiple ECharts options.
/// </summary>
public class Timeline
    : GeneralComponent, IHasSymbol
{

    /// <summary>
    /// This attribute has only one valid value as slider by now. 
    /// You don't have to change it.
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    public string? Type { get; set; } = "slider";

    /// <summary>
    /// Type of axis, whose values may be:
    /// 'value' Numeric axis, which is suitable for continuous data.
    /// 'category' Category axis, which is suitable for category data.
    /// 'time' Time axis, which is suitable for continuous time data. 
    /// Compared with value axis, time axis is equipped with time formatting function 
    /// and has a different method when calculating axis ticks. 
    /// For example, for time axis, axis ticks may vary in choosing unit as month, week, date, or hour 
    /// based on the range of data.
    /// </summary>
    [JsonProperty("axisType", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.AxisType? AxisType { get; set; } = ECharts.AxisType.Time;

    /// <summary>
    /// Indicates which is the currently selected item. For instance, 
    /// if currentIndex is 0, it indicates that the currently selected item is timeline.data[0] (namely, using options[0]).
    /// </summary>
    [JsonProperty("currentIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int? CurrentIndex { get; set; }

    /// <summary>
    /// Whether to play automatically.
    /// </summary>
    [JsonProperty("autoPlay", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AutoPlay { get; set; } = true;

    /// <summary>
    /// Whether supports playing reversely.
    /// </summary>
    [JsonProperty("rewind", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Rewind { get; set; } = true;

    /// <summary>
    /// Whether to loop playing.
    /// </summary>
    [JsonProperty("loop", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Loop { get; set; } = true;

    /// <summary>
    /// Indicates play speed (gap time between two state), whose unit is millisecond.
    /// </summary>
    [JsonProperty("playInterval", NullValueHandling = NullValueHandling.Ignore)]
    public int? PlayInterval { get; set; }

    /// <summary>
    /// Whether the view updates in real time during dragging the control dot.
    /// </summary>
    [JsonProperty("realtime", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Realtime { get; set; }

    /// <summary>
    /// When initializing, a switchableOption corresponding to the current time tick are 
    /// merged into baseOption to form the finalOption. 
    /// Each time the current tick changed, 
    /// the new switchableOption corresponding to the new time tick are merged into the finalOption.
    /// There are two merging strategy.
    /// By default, use NORMAL_MERGE.
    /// If timeline.replaceMerge is set, use REPLACE_MERGE. 
    /// </summary>
    [JsonProperty("replaceMerge", NullValueHandling = NullValueHandling.Ignore)]
    public object? ReplaceMerge { get; set; }

    /// <summary>
    /// Position of the play button, whose valid values are 'left' and 'right'.
    /// </summary>
    [JsonProperty("controlPosition", NullValueHandling = NullValueHandling.Ignore)]
    public ECharts.Position? ControlPosition { get; set; }

    /// <summary>
    /// timeline space around content. 
    /// </summary>
    [JsonProperty("padding", NullValueHandling = NullValueHandling.Ignore)]
    public object? Padding { get; set; }

    /// <summary>
    /// The layout orientation of legend.
    /// </summary>
    [JsonProperty("orient"), JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Orient? Orient { get; set; }

    /// <summary>
    /// Whether to put the timeline component reversely, 
    /// which makes the elements in the front to be at the end.
    /// </summary>
    [JsonProperty("inverse"), JsonConverter(typeof(StringEnumConverter))]
    public bool? Inverse { get; set; }

    #region IHasSymbol

    /// 
    public object? Symbol { get; set; }

    /// 
    public object? SymbolSize { get; set; }

    /// 
    public int? SymbolRotate { get; set; }

    /// 
    public bool? SymbolKeepAspect { get; set; }

    /// 
    public object? SymbolOffset { get; set; }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
    public LineStyle? LineStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public Labels.Label? Label { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? ItemStyle { get; set; }

    /// <summary>
    /// Style of the selected item (checkpoint).
    /// </summary>
    [JsonProperty("checkpointStyle", NullValueHandling = NullValueHandling.Ignore)]
    public CheckpointStyle? CheckpointStyle { get; set; }

    /// <summary>
    /// The style of control button, which includes: play button, previous button, and next button.
    /// </summary>
    [JsonProperty("controlStyle", NullValueHandling = NullValueHandling.Ignore)]
    public ControlStyle? ControlStyle { get; set; }

    /// <summary>
    /// Styles of line, labels and symbols in progress.
    /// </summary>
    [JsonProperty("progress", NullValueHandling = NullValueHandling.Ignore)]
    public Progress? Progress { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Emphasis { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public IEnumerable<string>? Data { get; set; }
}