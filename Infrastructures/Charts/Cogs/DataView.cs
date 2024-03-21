// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using System;

namespace Ban3.Infrastructures.Charts.Cogs;

/// <summary>
/// 数据视图工具，可以展现当前图表所用的数据，编辑后可以动态更新。
/// https://echarts.apache.org/zh/option.html#toolbox.feature.dataView
/// </summary>
public class DataView
{
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

    ///
    [JsonProperty("readOnly", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ReadOnly { get; set; } = true;

    /// <summary>
    /// (option:Object) => HTMLDomElement|string
    /// </summary>
    [JsonProperty("optionToContent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? OptionToContent { get; set; } = true;

    /// <summary>
    /// (container:HTMLDomElement, option:Object) => Object
    /// </summary>
    [JsonProperty("contentToOption", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ContentToOption { get; set; } = true;

    /// <summary>
    /// There are 3 names in data view, which are ['data view', 'turn off' and 'refresh'].
    /// </summary>
    [JsonProperty("lang", NullValueHandling = NullValueHandling.Ignore)]
    public Array? Lang { get; set; }

    /// <summary>
    /// 保存的图片背景色，默认使用 backgroundColor，如果backgroundColor不存在的话会取白色。
    /// </summary>
    [JsonProperty("backgroundColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? BackgroundColor { get; set; }

    ///
    [JsonProperty("textareaColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? TextareaColor { get; set; }

    ///
    [JsonProperty("textareaBorderColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? TextareaBorderColor { get; set; }

    ///
    [JsonProperty("textColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? TextColor { get; set; }

    ///
    [JsonProperty("buttonColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? ButtonColor { get; set; }

    ///
    [JsonProperty("buttonTextColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? ButtonTextColor { get; set; }
}
