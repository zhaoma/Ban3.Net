//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @        2022/10/16 11:50
//  function:	    
//  reference:
//  ————————————————————————————————————————————————————————————————————————————

using  Ban3.Infrastructures.Charts.Elements;
using  Ban3.Infrastructures.Charts.Styles;
using  Ban3.Infrastructures.Charts.Labels;
using Newtonsoft.Json;
using ECharts =  Ban3.Infrastructures.Charts.Enums;

namespace  Ban3.Infrastructures.Charts.Cogs;

public class Mark
    : IHasSymbol, IHasAnimation
{
    #region IHasSymbol

    ///
    public ECharts.Symbol? Symbol { get; set; }

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
    public object? Data { get; set; }

    #region IHasAnimation

    public bool? Animation { get; set; } = true;

    public int? AnimationThreshold { get; set; } = 2000;

    public object? AnimationDuration { get; set; } = 1000;

    public ECharts.EasingEffect? AnimationEasing { get; set; } = ECharts.EasingEffect.CubicOut;

    public object? AnimationDelay { get; set; } = 0;

    public object? AnimationDurationUpdate { get; set; } = 300;

    public ECharts.EasingEffect? AnimationEasingUpdate { get; set; } = ECharts.EasingEffect.CubicInOut;

    public object? AnimationDelayUpdate { get; set; } = 0;

    #endregion
}