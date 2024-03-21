// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ban3.Infrastructures.Charts.Elements;

public class GeneralData
    : IHasSymbol
{
    public GeneralData(){}

    public GeneralData(
        string name,
        object? coord,
        object? value,
        object? symbol,
        object? symbolSize,
        GeneralStyle? itemStyle)
    {
        Name = name;
        Coord = coord;
        Value = value;
        Symbol = symbol;
        SymbolSize = symbolSize;
        ItemStyle = itemStyle;
    }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    /// <summary>
    /// Special label types, are used to label maximum value, minimum value and so on.
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Enums.DataType? Type { get; set; }

    /// <summary>
    /// Available when using type it is used to assign maximum value and minimum value in dimensions,
    /// it could be 0 (xAxis, radiusAxis), 1 (yAxis, angleAxis), and use the first value axis dimension by default.
    /// </summary>
    [JsonProperty("valueIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int? ValueIndex { get; set; }

    /// <summary>
    /// Works only when type is assigned. It is used to state the dimension used to calculate maximum value or minimum value.
    /// It may be the direct name of a dimension, like x, or angle for line charts, or open, or close for candlestick charts.
    /// </summary>
    [JsonProperty("valueDim", NullValueHandling = NullValueHandling.Ignore)]
    public int? ValueDim { get; set; }

    /// <summary>
    /// Coordinates of the starting point or ending point, whose format depends on the coordinate of the series.
    /// It can be x, and y for rectangular coordinates, or radius, and angle for polar coordinates.
    /// e.g. coord: [5, 33.4], means [xAxis,yAxis]
    /// </summary>
    [JsonProperty("coord", NullValueHandling = NullValueHandling.Ignore)]
    public object? Coord { get; set; }

    /// <summary>
    /// X position according to container, in pixel.
    /// </summary>
    [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
    public int? X { get; set; }

    /// <summary>
    /// Y position according to container, in pixel.
    /// </summary>
    [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
    public int? Y { get; set; }

    /// <summary>
    /// at x at given value, which only works for single data item.
    /// </summary>
    [JsonProperty("xAxis", NullValueHandling = NullValueHandling.Ignore)]
    public object? XAxis { get; set; }

    /// <summary>
    /// at y at given value, which only works for single data item.
    /// </summary>
    [JsonProperty("yAxis", NullValueHandling = NullValueHandling.Ignore)]
    public object? YAxis { get; set; }

    /// <summary>
    /// Label value, which can be ignored.
    /// </summary>
    [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
    public object? Value { get; set; }

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
    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public Label? Label { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("itemStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? ItemStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("lineStyle", NullValueHandling = NullValueHandling.Ignore)]
    public LineStyle? LineStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Emphasis { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("blur", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Blur { get; set; }

}