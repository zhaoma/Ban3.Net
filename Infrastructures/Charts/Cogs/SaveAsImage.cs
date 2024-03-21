// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 保存为图片
/// </summary>
public class SaveAsImage
{
    /// <summary>
    /// 图片格式
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.ImageType? Type { get; set; }

    /// <summary>
    /// 保存的文件名称，默认使用 title.text 作为名称
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    /// <summary>
    /// 保存的图片背景色，默认使用 backgroundColor，如果backgroundColor不存在的话会取白色。
    /// </summary>
    [JsonProperty("backgroundColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? BackgroundColor { get; set; }

    /// <summary>
    /// 如果图表使用了 echarts.connect 对多个图表进行联动，则在导出图片时会导出这些联动的图表。
    /// 该配置项决定了图表与图表之间间隙处的填充色。
    /// </summary>
    [JsonProperty("connectedBackgroundColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? ConnectedBackgroundColor { get; set; }

    /// <summary>
    /// 保存为图片时忽略的组件列表，默认忽略工具栏
    /// </summary>
    [JsonProperty("excludeComponents", NullValueHandling = NullValueHandling.Ignore)]
    public Array? ExcludeComponents { get; set; }

    /// <summary>
    /// Whether to show label.
    /// </summary>
    [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Show { get; set; } = true;

    /// <summary>
    /// 标题文本
    /// </summary>
    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string? Title { get; set; } = "save as image";

    /// <summary>
    /// 缩放和还原的 icon path
    /// </summary>
    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public object? Icon { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("iconStyle", NullValueHandling = NullValueHandling.Ignore)]
    public GeneralStyle? IconStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public IconEmphasis? Emphasis { get; set; }

    /// <summary>
    /// Resolution ratio to save image, whose default value is that of the container. 
    /// Values larger than 1 (e.g.: 2) is supported when you need higher resolution.
    /// </summary>
    [JsonProperty("pixelRatio", NullValueHandling = NullValueHandling.Ignore)]
    public int? PixelRatio { get; set; }
}