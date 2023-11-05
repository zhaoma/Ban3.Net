// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 标签的统一布局配置
/// </summary>
public class LabelLayout
{
    /// <summary>
    /// 是否隐藏重叠的标签。
    /// </summary>
    [JsonProperty("hideOverlap", NullValueHandling = NullValueHandling.Ignore)]
    public bool? HideOverlap { get; set; }

    /// <summary>
    /// 在标签重叠的时候是否挪动标签位置以防止重叠。
    /// 目前支持配置为：
    /// 'shiftX' 水平方向依次位移，在水平方向对齐时使用
    /// 'shiftY' 垂直方向依次位移，在垂直方向对齐时使用
    /// </summary>
    [JsonProperty("moveOverlap", NullValueHandling = NullValueHandling.Ignore)]
    public ECharts.MoveOverlap? MoveOverlap { get; set; }

    /// <summary>
    /// 标签的 x 位置。支持绝对的像素值或者'20%'这样的相对值。
    /// </summary>
    [JsonProperty("x", NullValueHandling = NullValueHandling.Ignore)]
    public object? X { get; set; }

    /// <summary>
    /// 标签的 y 位置。支持绝对的像素值或者'20%'这样的相对值。
    /// </summary>
    [JsonProperty("y", NullValueHandling = NullValueHandling.Ignore)]
    public object? Y { get; set; }

    /// <summary>
    /// 标签在 x 方向上的像素偏移。可以和x一起使用。
    /// </summary>
    [JsonProperty("dx", NullValueHandling = NullValueHandling.Ignore)]
    public int? DX { get; set; }

    /// <summary>
    /// 标签在 y 方向上的像素偏移。可以和y一起使用
    /// </summary>
    [JsonProperty("dy", NullValueHandling = NullValueHandling.Ignore)]
    public int? DY { get; set; }

    /// <summary>
    /// 标签旋转角度。
    /// </summary>
    [JsonProperty("rotate", NullValueHandling = NullValueHandling.Ignore)]
    public int? Rotate { get; set; }

    /// <summary>
    /// Width of legend component. Adaptive by default.
    /// </summary>
    [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
    public object Width { get; set; } = "auto";

    /// <summary>
    /// Height of legend component. Adaptive by default.
    /// </summary>
    [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
    public object Height { get; set; } = "auto";

    /// <summary>
    /// 标签水平对齐方式。可以设置'left', 'center', 'right'。
    /// </summary>
    [JsonProperty("align", NullValueHandling = NullValueHandling.Ignore)]
    public ECharts.Align? Align { get; set; }

    /// <summary>
    /// 标签垂直对齐方式。可以设置'top', 'middle', 'bottom'。
    /// </summary>
    [JsonProperty("verticalAlign", NullValueHandling = NullValueHandling.Ignore)]
    public ECharts.VerticalAlign? VerticalAlign { get; set; }

    /// <summary>
    /// The text size of the label.
    /// </summary>
    [JsonProperty("fontSize", NullValueHandling = NullValueHandling.Ignore)]
    public int? FontSize { get; set; } = 12;

    /// <summary>
    /// 标签是否可以允许用户通过拖拽二次调整位置。
    /// </summary>
    [JsonProperty("draggable", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Draggable { get; set; }

    /// <summary>
    /// 标签引导线三个点的位置。格式为：[[x, y], [x, y], [x, y]]
    /// 在饼图中常用来微调已经计算好的引导线，其它情况一般不建议设置。
    /// </summary>
    [JsonProperty("labelLinePoints", NullValueHandling = NullValueHandling.Ignore)]
    public object? LabelLinePoints { get; set; }
}