//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;

namespace Ban3.Implements.Alpha.Components.ChartServer;

/// <summary>
/// 
/// </summary>
public class UtilizeEcharts:IChartServer
{
    /// <summary>
    /// 个股K线图
    /// </summary>
    /// <param name="stockResult"></param>
    /// <returns></returns>
    public string CandlestickDiagram(Result stockResult)
    {
        return string.Empty;
    }

    /// <summary>
    /// 个股时间线图
    /// </summary>
    /// <param name="stockResult"></param>
    /// <returns></returns>
    public string TimelineDiagram(Result stockResult)
    {
        return string.Empty;
    }

    /// <summary>
    /// 市场矩形树图
    /// </summary>
    /// <param name="stocksSummary"></param>
    /// <returns></returns>
    public string TreemapDiagram(Summary stocksSummary)
    {
        return string.Empty;
    }
}
