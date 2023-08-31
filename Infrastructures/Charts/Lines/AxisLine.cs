/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022-09-01 08:00
 * function:            坐标轴轴线
 * reference:https://echarts.apache.org/zh/option.html#angleAxis.axisLine
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Charts.Elements;
using ECharts = Ban3.Infrastructures.Charts.Enums;

namespace Ban3.Infrastructures.Charts.Lines;

/// <summary>
/// 轴线
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
