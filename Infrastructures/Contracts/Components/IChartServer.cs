//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;

namespace Ban3.Infrastructures.Components;

/// <summary>
/// 图表服务
/// </summary>
public interface IChartServer
{
    /// <summary>
    /// 个股K线图
    /// </summary>
    /// <param name="stockResult"></param>
    /// <returns></returns>
    string CandlestickDiagram(Result stockResult);

    /// <summary>
    /// 个股时间线图
    /// </summary>
    /// <param name="stockResult"></param>
    /// <returns></returns>
    string TimelineDiagram(Result stockResult);

    /// <summary>
    /// 市场矩形树图
    /// </summary>
    /// <param name="stocksSummary"></param>
    /// <returns></returns>
    string TreemapDiagram(Summary stocksSummary);
}
