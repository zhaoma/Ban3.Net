//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/16 13:24
//  function:	Calendar.cs
//  reference:	https://echarts.apache.org/en/option.html#calendar
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Styles;
using Ban3.Infrastructures.Charts.Lines;
using Ban3.Infrastructures.Charts.Labels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Components;

/// <summary>
/// Calendar coordinates.
/// In ECharts, we are very creative to achieve the calendar chart, 
/// by using the calendar coordinates to achieve the calendar chart, 
/// as shown in the following example, 
/// we can use calendar coordinates in heatmap, scatter, effectScatter, and graph.
/// </summary>
public class Calendar
    : GeneralComponent
{
    /// <summary>
    /// Required, range of Calendar coordinates, support multiple formats.
    /// one year range: 2017
    /// one month range: '2017-02'
    /// a range range: ['2017-01-02', '2017-02-23']
    /// note: they will be identified as ['2017-01-01', '2017-02-01']  range: ['2017-01', '2017-02']
    /// </summary>
    [JsonProperty("range", NullValueHandling = NullValueHandling.Ignore)]
    public object? Range { get; set; }

    /// <summary>
    /// The size of each rect of calendar coordinates, can be set to a single value or array,
    /// the first element is width and the second element is height.
    /// Support setting self-adaptation: auto, the default width and height to be 20.
    /// </summary>
    [JsonProperty("cellSize", NullValueHandling = NullValueHandling.Ignore)]
    public object? CellSize { get; set; }


    [JsonProperty("orient", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Orient? Orient { get; set; }


    [JsonProperty("splitLine"), JsonConverter(typeof(StringEnumConverter))]
    public SplitLine? SplitLine { get; set; }


    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? ItemStyle { get; set; }


    [JsonProperty("dayLabel", NullValueHandling = NullValueHandling.Ignore)]
    public Label? DayLabel { get; set; }


    [JsonProperty("monthLabel", NullValueHandling = NullValueHandling.Ignore)]
    public Label? MonthLabel { get; set; }


    [JsonProperty("yearLabel", NullValueHandling = NullValueHandling.Ignore)]
    public Label? YearLabel { get; set; }


    [JsonProperty("silent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Silent { get; set; }
}