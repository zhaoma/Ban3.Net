//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts =  Ban3.Infrastructures.Charts.Enums;
namespace  Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 提示框组件
/// </summary>
public class Tooltip
    : IHasBorder
{
    /// <summary>
    /// Whether to show label.
    /// </summary>
    [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Show { get; set; }

    /// <summary>
    /// 触发类型
    /// </summary>
    [JsonProperty("trigger", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Trigger? Trigger { get; set; }

    /// <summary>
    /// 坐标轴指示器配置项。
    /// </summary>
    [JsonProperty("axisPointer", NullValueHandling = NullValueHandling.Ignore)]
    public AxisPointer? AxisPointer { get; set; }

    /// <summary>
    /// 是否显示提示框浮层，默认显示。
    /// 只需tooltip触发事件或显示axisPointer而不需要显示内容时可配置该项为false。
    /// </summary>
    [JsonProperty("showContent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ShowContent { get; set; }

    /// <summary>
    /// 是否永远显示提示框内容，
    /// 默认情况下在移出可触发提示框区域后 一定时间 后隐藏，
    /// 设置为 true 可以保证一直显示提示框内容。
    /// </summary>
    [JsonProperty("alwaysShowContent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AlwaysShowContent { get; set; }

    /// <summary>
    /// 提示框触发的条件
    /// </summary>
    [JsonProperty("triggrOn", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Trigger? TriggerOn { get; set; }

    /// <summary>
    /// 浮层显示的延迟，单位为 ms，默认没有延迟，也不建议设置。在 triggerOn 为 'mousemove' 时有效。
    /// </summary>
    [JsonProperty("showDelay", NullValueHandling = NullValueHandling.Ignore)]
    public int? ShowDelay { get; set; }

    /// <summary>
    /// 浮层隐藏的延迟，单位为 ms，在 alwaysShowContent 为 true 的时候无效。
    /// </summary>
    [JsonProperty("hideDelay", NullValueHandling = NullValueHandling.Ignore)]
    public int? HideDelay { get; set; }

    /// <summary>
    /// 鼠标是否可进入提示框浮层中，默认为false，如需详情内交互，如添加链接，按钮，可设置为 true。
    /// </summary>
    [JsonProperty("enterable", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Enterable { get; set; }

    /// <summary>
    /// 浮层的渲染模式，默认以 'html 即额外的 DOM 节点展示 tooltip；
    /// 此外还可以设置为 'richText' 表示以富文本的形式渲染，
    /// 渲染的结果在图表对应的 Canvas 中，这对于一些没有 DOM 的环境（如微信小程序）有更好的支持。
    /// </summary>
    [JsonProperty("renderMode", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.RenderMode? RenderMode { get; set; }

    /// <summary>
    /// 是否将 tooltip 框限制在图表的区域内。
    /// 当图表外层的 dom 被设置为 'overflow: hidden'，或者移动端窄屏，
    /// 导致 tooltip 超出外界被截断时，此配置比较有用。
    /// </summary>
    [JsonProperty("confine", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Confine { get; set; }

    /// <summary>
    /// 是否将 tooltip 的 DOM 节点添加为 HTML 的 body 的子节点。
    /// 只有当 renderMode 为 'html' 是有意义的。
    /// </summary>
    [JsonProperty("appendToBody", NullValueHandling = NullValueHandling.Ignore)]
    public bool? AppendToBody { get; set; }

    /// <summary>
    /// 指定 tooltip 的 DOM 节点的 CSS 类。（只在 html 模式下生效）。
    /// </summary>
    [JsonProperty("className", NullValueHandling = NullValueHandling.Ignore)]
    public string? ClassName { get; set; }

    /// <summary>
    /// 提示框浮层的移动动画过渡时间，单位是 s，设置为 0 的时候会紧跟着鼠标移动。
    /// </summary>
    [JsonProperty("transitionDuration", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? TransitionDuration { get; set; }

    /// <summary>
    /// 提示框浮层的位置，默认不设置时位置会跟随鼠标的位置。
    /// Array 通过数组表示提示框浮层的位置，支持数字设置绝对位置，百分比设置相对位置。 position: [10, 10] position: ['50%', '50%']
    /// Function 回调函数，格式如下： (point: Array, params: Object|Array.Object, dom: HTMLDomElement, rect: Object, size: Object) => Array
    /// inside
    /// top
    /// left
    /// right
    /// bottom
    /// </summary>
    [JsonProperty("position", NullValueHandling = NullValueHandling.Ignore)]
    public object? Position { get; set; }

    /// <summary>
    /// 刻度标签的内容格式器，支持字符串模板和回调函数两种形式。
    /// </summary>
    [JsonProperty("formatter", NullValueHandling = NullValueHandling.Ignore)]
    public object? Formatter { get; set; }

    /// <summary>
    /// tooltip 中数值显示部分的格式化回调函数。
    /// </summary>
    [JsonProperty("valueFormatter", NullValueHandling = NullValueHandling.Ignore)]
    public string? ValueFormatter { get; set; }

    #region IHasBorder

    /// 
    public string? BackgroundColor { get; set; }

    /// 
    public string? BorderColor { get; set; }

    /// 
    public ECharts.BorderType? BorderType { get; set; }

    /// 
    public int? BorderWidth { get; set; }

    /// 
    public object? BorderRadius { get; set; }

    ///
    public int? BorderDashOffset { get; set; }

    ///
    public ECharts.BorderCap? BorderCap { get; set; }

    ///
    public ECharts.BorderJoin? BorderJoin { get; set; }

    ///
    public int? BorderMiterLimit { get; set; }

    /// 
    public object? Padding { get; set; }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("textStyle", NullValueHandling = NullValueHandling.Ignore)]
    public TextStyle? TextStyle { get; set; }

    /// <summary>
    /// 额外附加到浮层的 css 样式。如下为浮层添加阴影的示例：
    /// extraCssText: 'box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);'
    /// </summary>
    [JsonProperty("extraCssText", NullValueHandling = NullValueHandling.Ignore)]
    public string? ExtraCssText { get; set; }

    /// <summary>
    /// 多系列提示框浮层排列顺序
    /// </summary>
    [JsonProperty("order", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Order? Order { get; set; }
}