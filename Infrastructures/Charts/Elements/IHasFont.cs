//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Elements;

/// <summary>
/// 字体部分
/// </summary>
public interface IHasFont
{
    /// <summary>
    /// text color. If set as 'inherit', the color will assigned as visual color, such as series color.
    /// </summary>
    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    string? Color { get; set; }

    /// <summary>
    /// font style.
    /// </summary>
    [JsonProperty("fontStyle", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ECharts.FontStyle? FontStyle { get; set; }

    /// <summary>
    /// font thick weight.
    /// </summary>
    [JsonProperty("fontWeight", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ECharts.FontWeight? FontWeight { get; set; }

    /// <summary>
    /// font family.
    /// Can also be 'serif' , 'monospace', ...
    /// </summary>
    [JsonProperty("fontFamily", NullValueHandling = NullValueHandling.Ignore)]
    string? FontFamily { get; set; }

    /// <summary>
    /// font size.
    /// </summary>
    [JsonProperty("fontSize", NullValueHandling = NullValueHandling.Ignore)]
    int? FontSize { get; set; }

    /// <summary>
    /// Horizontal alignment of text, automatic by default.
    /// </summary>
    [JsonProperty("align", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ECharts.Align? Align { get; set; }

    /// <summary>
    /// Vertical alignment of text, automatic by default.
    /// </summary>
    [JsonProperty("verticalAlign", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ECharts.VerticalAlign? VerticalAlign { get; set; }

    /// <summary>
    /// Line height of the text fragment.
    /// If lineHeight is not set in rich, lineHeight in parent level will be used.
    /// </summary>
    [JsonProperty("lineHeight", NullValueHandling = NullValueHandling.Ignore)]
    int? LineHeight { get; set; }
}