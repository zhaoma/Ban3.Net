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
/// 文字描边
/// </summary>
public interface IHasTextBorder
{
    /// <summary>
    /// Stroke color of the text.
    /// </summary>
    [JsonProperty("txtBorderColor", NullValueHandling = NullValueHandling.Ignore)]
    string? TextBorderColor { get; set; }

    /// <summary>
    /// Stroke line width of the text.
    /// </summary>
    [JsonProperty("txtBorderWidth", NullValueHandling = NullValueHandling.Ignore)]
    int? TextBorderWidth { get; set; }

    /// <summary>
    /// border type.
    /// </summary>
    [JsonProperty("txtBorderType", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    ECharts.BorderType? TextBorderType { get; set; }

    /// <summary>
    /// To set the line dash offset. With borderType , 
    /// we can make the line style more flexible.
    /// </summary>
    [JsonProperty("txtBorderDashOffset", NullValueHandling = NullValueHandling.Ignore)]
    int? TextBorderDashOffset { get; set; }
}