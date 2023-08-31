//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/10/30 10:44
//  function:	GeneralLabel.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Elements;

public class GeneralLabel
    : IHasFont, IHasBorder, IHasShadow, IHasTextBorder, IHasTextShadow
{
    /// <summary>
    /// Whether to show label.
    /// </summary>
    [JsonProperty("show", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Show { get; set; } = true;

    /// <summary>
    /// Width of legend component. Adaptive by default.
    /// </summary>
    [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
    public object? Width { get; set; } = "auto";

    /// <summary>
    /// Height of legend component. Adaptive by default.
    /// </summary>
    [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
    public object? Height { get; set; } = "auto";

    #region IHasFont

    /// 
    public string? Color { get; set; }

    /// 
    public ECharts.FontStyle? FontStyle { get; set; }

    /// 
    public ECharts.FontWeight? FontWeight { get; set; }

    ///
    public string? FontFamily { get; set; } = "sans-serif";

    /// 
    public int? FontSize { get; set; } = 12;

    /// 
    public ECharts.Align? Align { get; set; }

    /// 
    public ECharts.VerticalAlign? VerticalAlign { get; set; }

    /// 
    public int? LineHeight { get; set; }

    #endregion

    #region IHasBorder

    /// 
    public string? BackgroundColor { get; set; } = "transparent";

    /// 
    public string? BorderColor { get; set; } = "#ccc";

    /// 
    public ECharts.BorderType? BorderType { get; set; }

    /// 
    public int? BorderWidth { get; set; } = 1;

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

    #region IHasTextBorder

    /// 
    public string? TextBorderColor { get; set; }

    /// 
    public int? TextBorderWidth { get; set; }

    /// 
    public ECharts.BorderType? TextBorderType { get; set; }

    /// 
    public int? TextBorderDashOffset { get; set; }

    #endregion

    #region IHasTextShadow

    /// 
    public int? TextShadowBlur { get; set; }

    /// 
    public string? TextShadowColor { get; set; }

    /// 
    public int? TextShadowOffsetX { get; set; }

    /// 
    public int? TextShadowOffsetY { get; set; }

    #endregion

}