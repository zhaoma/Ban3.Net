// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Elements;
using Newtonsoft.Json;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Components;

/// <summary>
/// Drawing grid in rectangular coordinate.
/// In a single grid, at most two X and Y axes each is allowed. 
/// Line chart, bar chart, and scatter chart (bubble chart) can be drawn in grid.
/// In ECharts 2.x, there could only be one single grid component at most in a single echarts instance. 
/// But in ECharts 3, there is no limitation.
/// https://echarts.apache.org/zh/option.html#grid
/// </summary>
public class Grid
    : GeneralComponent, IHasBorder, IHasShadow
{
    public Grid(string? left, string? right, string? height, string? top)
    {
        Left = left;
        Right = right;
        Height = height;
        Top = top;
    }

    /// <summary>
    /// Set this to false to prevent the title from showing
    /// </summary>
    [JsonProperty("containLabel", NullValueHandling = NullValueHandling.Ignore)]
    public bool? ContainLabel { get; set; }

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

    /// <summary>
    /// tooltip settings in the coordinate system component.
    /// </summary>
    [JsonProperty("tooltip", NullValueHandling = NullValueHandling.Ignore)]
    public Tooltip? Tooltip { get; set; }
}
