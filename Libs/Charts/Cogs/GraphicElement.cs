//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs;

/// 
public class GraphicElement
    : GeneralComponent
{
    /// <summary>
    /// Must be specified when define a graphic element at the first time.
    /// Optional values:
    /// image, text, circle, sector, ring, polygon, polyline, rect, line, bezierCurve, arc, group,
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.GraphicElementType? Type { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("@action", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.GraphicElementAction? Action { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
    public int? X { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
    public int? Y { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("rotate", NullValueHandling = NullValueHandling.Ignore)]
    public int? Rotate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("scaleX", NullValueHandling = NullValueHandling.Ignore)]
    public int? ScaleX { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("scaleY", NullValueHandling = NullValueHandling.Ignore)]
    public int? ScaleY { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("originX", NullValueHandling = NullValueHandling.Ignore)]
    public int? OriginX { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("originY", NullValueHandling = NullValueHandling.Ignore)]
    public int? OriginY { get; set; }

    /// <summary>
    /// You can specify that all properties have transition animations turned on with `'all'', 
    /// or you can specify a single property or an array of properties.
    /// </summary>
    [JsonProperty("transition", NullValueHandling = NullValueHandling.Ignore)]
    public object? Transition { get; set; }

    /// 
    [JsonProperty("enterFrom", NullValueHandling = NullValueHandling.Ignore)]
    public object? EnterFrom { get; set; }

    /// 
    [JsonProperty("leaveTo", NullValueHandling = NullValueHandling.Ignore)]
    public object? LeaveTo { get; set; }

    /// 
    [JsonProperty("enterAnimation", NullValueHandling = NullValueHandling.Ignore)]
    public Animation? EnterAnimation { get; set; }

    /// 
    [JsonProperty("updateAnimation", NullValueHandling = NullValueHandling.Ignore)]
    public Animation? UpdateAnimation { get; set; }

    /// 
    [JsonProperty("leaveAnimation", NullValueHandling = NullValueHandling.Ignore)]
    public Animation? LeaveAnimation { get; set; }

    /// 
    [JsonProperty("keyframeAnimation", NullValueHandling = NullValueHandling.Ignore)]
    public Animation? KeyframeAnimation { get; set; }

    /// 
    [JsonProperty("bounding", NullValueHandling = NullValueHandling.Ignore)]
    public string? Bounding { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("info", NullValueHandling = NullValueHandling.Ignore)]
    public object? Info { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("ignore", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Ignore { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("draggable", NullValueHandling = NullValueHandling.Ignore)]
    public object? Draggable { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("diffChildrenByName", NullValueHandling = NullValueHandling.Ignore)]
    public bool? DiffChildrenByName { get; set; }
}