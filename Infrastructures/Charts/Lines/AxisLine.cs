// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
//  WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Charts.Elements;

namespace Ban3.Infrastructures.Charts.Lines;

/// <summary>
/// 轴线
/// https://echarts.apache.org/zh/option.html#angleAxis.axisLine
/// </summary>
public class AxisLine
    : GeneralLine, IHasSymbol
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
}
