/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            图例组件
 * reference:           https://echarts.apache.org/en/option.html#legend
 * —————————————————————————————————————————————————————————————————————————————
 */

using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Collections.Generic;
using ECharts = Ban3.Infrastructures.Charts.Enums;
using Ban3.Infrastructures.Charts.Elements;
using Ban3.Infrastructures.Charts.Styles;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Labels;

namespace Ban3.Infrastructures.Charts.Components;

/// <summary>
/// 图例组件
/// Legend component shows symbol, color and name of different series. 
/// You can click legends to toggle displaying series in the chart.
/// </summary>
public class Legend
    : GeneralComponent, IHasBorder, IHasShadow
{
    public Legend()
    {
    }

    public Legend(IEnumerable<string> data, object? left, object? top)
    {
        Data = data;
        Left = left;
        Top = top;
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.LegendType? Type { get; set; }

    /// <summary>
    /// The layout orientation of legend.
    /// </summary>
    [JsonProperty("orient", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Orient? Orient { get; set; }

    /// <summary>
    /// Legend marker and text aligning.
    /// </summary>
    [JsonProperty("align", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Align? Align { get; set; }

    /// <summary>
    /// The distance between each legend, 
    /// horizontal distance in horizontal layout, 
    /// and vertical distance in vertical layout.
    /// </summary>
    [JsonProperty("itemGap", NullValueHandling = NullValueHandling.Ignore)]
    public int? ItemGap { get; set; }

    /// <summary>
    /// Image width of legend symbol.
    /// </summary>
    [JsonProperty("itemWidth", NullValueHandling = NullValueHandling.Ignore)]
    public int? ItemWidth { get; set; }

    /// <summary>
    /// Image height of legend symbol.
    /// </summary>
    [JsonProperty("itemHeight", NullValueHandling = NullValueHandling.Ignore)]
    public int? ItemHeight { get; set; }

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
    /// Rotation of the symbol, which can be number | 'inherit'. 
    /// If it's 'inherit', symbolRotate of the series will be used.
    /// </summary>
    [JsonProperty("symbolRotate", NullValueHandling = NullValueHandling.Ignore)]
    public int? SymbolRotate { get; set; }

    /// <summary>
    /// Formatter is used to format label of legend, 
    /// which supports string template and callback function.
    /// </summary>
    [JsonProperty("formatter", NullValueHandling = NullValueHandling.Ignore)]
    public string? Formatter { get; set; }

    /// <summary>
    /// Selected mode of legend, 
    /// which controls whether series can be toggled displaying by clicking legends. 
    /// It is enabled by default, and you may set it to be false to disable it.
    /// Besides, it can be set to 'single' or 'multiple', 
    /// for single selection and multiple selection.
    /// </summary>
    [JsonProperty("selectedMode", NullValueHandling = NullValueHandling.Ignore)]
    public bool? SelectedMode { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("inactiveColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? InactiveColor { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("inactiveBorderColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? InactiveBorderColor { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("inactiveBorderWidth", NullValueHandling = NullValueHandling.Ignore)]
    public int? InactiveBorderWidth { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("selected", NullValueHandling = NullValueHandling.Ignore)]
    public object? Selected { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("textStyle", NullValueHandling = NullValueHandling.Ignore)]
    public TextStyle? TextStyle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
    public Tooltip? Tooltip { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public string? Icon { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<string>? Data { get; set; }

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

    /// <summary>
    /// It works when legend.type is 'scroll'.
    /// dataIndex of the left top most displayed item.
    /// Although the scrolling of legend items can be controlled by calling setOption and specifying this property, 
    /// we suggest that do not control legend in this way unless necessary (setOption might be time-consuming), 
    /// but just use action legendScroll to do that.
    /// </summary>
    [JsonProperty("scrollDataIndex", NullValueHandling = NullValueHandling.Ignore)]
    public int? ScrollDataIndex { get; set; }

    /// <summary>
    /// It works when legend.type is 'scroll'.
    /// The gap between page buttons and page info text.
    /// </summary>
    [JsonProperty("pageButtonItemGap", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageButtonItemGap { get; set; } = 5;

    /// <summary>
    /// It works when legend.type is 'scroll'.
    /// The gap between page buttons and legend items.
    /// </summary>
    [JsonProperty("pageButtonGap", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageButtonGap { get; set; }

    /// <summary>
    /// The position of page buttons and page info.
    /// It works when legend.type is 'scroll'.
    /// </summary>
    [JsonProperty("pageButtonPosition"), JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Position PageButtonPosition { get; set; } = ECharts.Position.End;

    /// <summary>
    /// Page info formatter. It is '{current}/{total}' by default, 
    /// where {current} is current page number (start from 1), 
    /// and {total} is the total page number.
    /// It works when legend.type is 'scroll'.
    /// If pageFormatter is a function, it should return a string. The parameters is:
    /// {current: number,total: number}
    /// </summary>
    [JsonProperty("pageFormatter", NullValueHandling = NullValueHandling.Ignore)]
    public string? PageFormatter { get; set; }

    /// <summary>
    /// The icons of page buttons.
    /// It works when legend.type is 'scroll'.
    /// </summary>
    [JsonProperty("pageIcons", NullValueHandling = NullValueHandling.Ignore)]
    public PageIcons? PageIcons { get; set; }

    /// <summary>
    /// The color of page buttons.
    /// It works when legend.type is 'scroll'.
    /// </summary>
    [JsonProperty("pageIconColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? PageIconColor { get; set; }

    /// <summary>
    /// The color of page buttons when they are inactive.
    /// It works when legend.type is 'scroll'.
    /// </summary>
    [JsonProperty("pageIconInactiveColor", NullValueHandling = NullValueHandling.Ignore)]
    public string? PageIconInactiveColor { get; set; }

    /// <summary>
    /// The size of page buttons. It can be a number, or an array, like [10, 3], represents [width, height].
    /// It works when legend.type is 'scroll'.
    /// </summary>
    [JsonProperty("pageIconSize", NullValueHandling = NullValueHandling.Ignore)]
    public object? PageIconSize { get; set; }

    /// <summary>
    /// The text style of page info.
    /// It works when legend.type is 'scroll'.
    /// </summary>
    [JsonProperty("pageTextStyle", NullValueHandling = NullValueHandling.Ignore)]
    public TextStyle? PageTextStyle { get; set; }

    /// <summary>
    /// Whether to use animation when page scrolls.
    /// </summary>
    [JsonProperty("animation", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Animation { get; set; }

    /// <summary>
    /// Duration of the page scroll animation.
    /// </summary>
    [JsonProperty("animationDurationUpdate", NullValueHandling = NullValueHandling.Ignore)]
    public int? AnimationDurationUpdate { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Emphasis { get; set; }

    /// <summary>
    /// The selector button in the legend component. 
    /// Currently includes both a full selection and an inverse selection. 
    /// The selector button doesn't display by default, 
    /// the user can manually configure it.
    /// </summary>
    [JsonProperty("selector", NullValueHandling = NullValueHandling.Ignore)]
    public object? Selector { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("selectorLabel", NullValueHandling = NullValueHandling.Ignore)]
    public Label? SelectorLabel { get; set; }

    /// <summary>
    /// The position of the selector button, 
    /// which can be placed at the end or start of the legend component, 
    /// the corresponding values are 'end' and 'start'. 
    /// By default, when the legend is laid out horizontally, 
    /// the selector is placed at the end of it, 
    /// and when the legend is laid out vertically, 
    /// the selector is placed at the start of it.
    /// </summary>
    [JsonProperty("selectorPosition", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public ECharts.Position? SelectorPosition { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("selectorItemGap", NullValueHandling = NullValueHandling.Ignore)]
    public int? SelectorItemGap { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("selectorButtonGap", NullValueHandling = NullValueHandling.Ignore)]
    public int? SelectorButtonGap { get; set; }
}