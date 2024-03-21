// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 拖拽手柄，适用于触屏的环境。
/// </summary>
public class Handle
    : IHasShadow
{
    /// <summary>
    /// Whether to show label.
    /// </summary>
    [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Show { get; set; } = true;

    /// <summary>
    /// 手柄的图标
    /// 可以通过 'image://url' 设置为图片，其中 URL 为图片的链接，或者 dataURI。
    /// 可以通过 'path://' 将图标设置为任意的矢量路径。
    /// </summary>
    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public object? Icon { get; set; }

    /// <summary>
    /// 手柄的尺寸，可以设置单值，如 45，
    /// 也可以设置为数组：[width, height]。
    /// </summary>
    [JsonProperty("size", NullValueHandling = NullValueHandling.Ignore)]
    public object? Size { get; set; } = 45;

    /// <summary>
    /// 手柄与轴的距离。注意，这是手柄中心点和轴的距离。
    /// </summary>
    [JsonProperty("margin", NullValueHandling = NullValueHandling.Ignore)]
    public int? Margin { get; set; } = 50;

    /// <summary>
    /// 手柄颜色。
    /// text color. If set as 'inherit', the color will assigned as visual color, such as series color.
    /// </summary>
    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public string? Color { get; set; } = "#333";

    /// <summary>
    /// 手柄拖拽时触发视图更新周期，单位毫秒，调大这个数值可以改善性能，但是降低体验。
    /// </summary>
    [JsonProperty("throttle", NullValueHandling = NullValueHandling.Ignore)]
    public int? Throttle { get; set; } = 40;

    #region IHasShadow

    /// 
    public int? ShadowBlur { get; set; }

    /// 
    public string? ShadowColor { get; set; }

    /// 
    public int? ShadowOffsetX { get; set; }

    /// 
    public int? ShadowOffsetY { get; set; }

    ///
    public decimal? Opacity { get; set; }

    #endregion

}