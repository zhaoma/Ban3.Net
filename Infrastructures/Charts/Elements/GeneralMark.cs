// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System.Collections.Generic;
using Ban3.Infrastructures.Charts.Cogs;
using Ban3.Infrastructures.Charts.Labels;
using Ban3.Infrastructures.Charts.Styles;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Charts.Elements;

public class GeneralMark
    : IHasSymbol, IHasAnimation
{
    #region IHasSymbol

    ///
    public object? Symbol { get; set; }

    /// 
    public object? SymbolSize { get; set; }

    /// 
    public int? SymbolRotate { get; set; }

    /// 
    public bool? SymbolKeepAspect { get; set; }

    /// 
    public object? SymbolOffset { get; set; }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("silent", NullValueHandling = NullValueHandling.Ignore)]
    public bool? Silent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("precision", NullValueHandling = NullValueHandling.Ignore)]
    public int? Precision { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("label", NullValueHandling = NullValueHandling.Ignore)]
    public Label? Label { get; set; }

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
    /// 
    /// </summary>
    [JsonProperty("emphasis", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Emphasis { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("blur", NullValueHandling = NullValueHandling.Ignore)]
    public Emphasis? Blur { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    public List< GeneralData>? Data { get; set; }

    #region IHasAnimation

    public bool? Animation { get; set; } = true;

    public int? AnimationThreshold { get; set; } = 2000;

    public object? AnimationDuration { get; set; } = 1000;

    public Enums.EasingEffect? AnimationEasing { get; set; } = Enums.EasingEffect.CubicOut;

    public object? AnimationDelay { get; set; } = 0;

    public object? AnimationDurationUpdate { get; set; } = 300;

    public Enums.EasingEffect? AnimationEasingUpdate { get; set; } = Enums.EasingEffect.CubicInOut;

    public object? AnimationDelayUpdate { get; set; } = 0;

    #endregion
}