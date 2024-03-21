// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Components;

/// <summary>
/// Title component, including main title and subtitle.
/// https://echarts.apache.org/en/option.html#title
/// </summary>
public class Title
    : GeneralComponent, IHasBorder, IHasShadow

{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="text"></param>
    public Title(string text)
    {
        Text = text;
    }

    /// <summary>
    /// The main title text, supporting for \n for newlines.
    /// </summary>
    [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
    public string? Text { get; set; }

    /// <summary>
    /// The hyper link of main title text.
    /// </summary>
    [JsonProperty("link", NullValueHandling = NullValueHandling.Ignore)]
    public string? Link { get; set; }

    /// <summary>
    /// Open the hyper link of main title in specified tab.
    /// 'self' opening it in current tab
    /// 'blank' opening it in a new tab
    /// </summary>
    [JsonProperty("target", NullValueHandling = NullValueHandling.Ignore)]
    public string? Target { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("textStyle", NullValueHandling = NullValueHandling.Ignore)]
    public TextStyle? TextStyle { get; set; }

    /// <summary>
    /// Subtitle text, supporting for \n for newlines.
    /// </summary>
    [JsonProperty("subtext", NullValueHandling = NullValueHandling.Ignore)]
    public string? Subtext { get; set; }

    /// <summary>
    /// The hyper link of subtitle text.
    /// </summary>
    [JsonProperty("sublink", NullValueHandling = NullValueHandling.Ignore)]
    public string? Sublink { get; set; }

    /// <summary>
    /// Open the hyper link of subtitle in specified tab, options:
    /// 'self' opening it in current tab
    /// 'blank' opening it in a new tab
    /// </summary>
    [JsonProperty("subtarget", NullValueHandling = NullValueHandling.Ignore)]
    public string? Subtarget { get; set; }

    /// <summary>
    /// 子标题样式
    /// </summary>
    [JsonProperty("subtextStyle", NullValueHandling = NullValueHandling.Ignore)]
    public TextStyle? SubtextStyle { get; set; }

    /// <summary>
    /// The horizontal align of the component (including "text" and "subtext").
    /// Optional values: 'auto', 'left', 'right', 'center'.
    /// </summary>
    [JsonProperty("textAlign", NullValueHandling = NullValueHandling.Ignore)]
    public string? TextAlign { get; set; }

    /// <summary>
    /// The vertical align of the component (including "text" and "subtext").
    /// Optional values: 'auto', 'top', 'bottom', 'middle'.
    /// </summary>
    [JsonProperty("textVerticalAlign", NullValueHandling = NullValueHandling.Ignore)]
    public string? TextVerticalAlign { get; set; }

    /// <summary>
    /// Set this to true to enable triggering events
    /// </summary>
    [JsonProperty("triggerEvent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? TriggerEvent { get; set; }

    /// <summary>
    /// The gap between the main title and subtitle.
    /// </summary>
    [JsonProperty("itemGap", NullValueHandling = NullValueHandling.Ignore)]
    public int? ItemGap { get; set; }

    #region HasBorder

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

    #region HasShadow

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
