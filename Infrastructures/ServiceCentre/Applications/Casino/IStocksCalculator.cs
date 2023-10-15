using System.Collections.Generic;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 标的数据计算
/// </summary>
public interface IStocksCalculator
{
    /// <summary>
    /// 从财务事件中分析复权因子
    /// </summary>
    /// <param name="stockEvents"></param>
    /// <param name="stockSeeds"></param>
    /// <returns></returns>
    Task<bool> GenerateSeeds(
	    IEnumerable<IStockEvent> stockEvents,
	    out IEnumerable<IStockSeed> stockSeeds
	);

    /// <summary>
    /// 价格复权
    /// </summary>
    /// <param name="sourcePrices"></param>
    /// <param name="stockSeeds"></param>
    /// <param name="targetPrices"></param>
    /// <returns></returns>
    Task<bool> AdjustPrices(
        IEnumerable<IStockPrice> sourcePrices,
        IEnumerable<IStockSeed> stockSeeds,
        out IEnumerable<IStockPrice> targetPrices
    );
    /// <summary>
    /// 周期转换，日->周/月
    /// </summary>
    /// <param name="sourcePrices"></param>
    /// <param name="analysisCycle"></param>
    /// <param name="targetPrices"></param>
    /// <returns></returns>
    Task<bool> ConvertCycle(
        IEnumerable<IStockPrice> sourcePrices,
        AnalysisCycle analysisCycle,
        out IEnumerable<IStockPrice> targetPrices
	);

    /// <summary>
    /// 用价格信息计算指标
    /// </summary>
    /// <param name="input"></param>
    /// <param name="output"></param>
    /// <returns></returns>
    Task<bool> GenerateIndicators(
	    IInput input,
	    out IOutput output
	);
}