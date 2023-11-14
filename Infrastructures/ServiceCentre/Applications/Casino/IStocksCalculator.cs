// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using System.Threading.Tasks;

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
    Task<bool> TryGenerateSeeds(
        IStockData<IStockEvent> stockEvents,
        out IStockData<IStockSeed> stockSeeds
    );

    /// <summary>
    /// 价格复权
    /// </summary>
    /// <param name="sourcePrices"></param>
    /// <param name="stockSeeds"></param>
    /// <param name="targetPrices"></param>
    /// <returns></returns>
    Task<bool> TryAdjustPrices(
        IStockData<IStockPrice> sourcePrices,
        IStockData<IStockSeed> stockSeeds,
        out IStockData<IStockPrice> targetPrices
    );

    /// <summary>
    /// 周期转换，日->周/月
    /// </summary>
    /// <param name="dailyPrices"></param>
    /// <param name="analysisCycle"></param>
    /// <param name="targetPrices"></param>
    /// <returns></returns>
    Task<bool> TryConvertCycle(
        IStockData<IStockPrice> dailyPrices,
        AnalysisCycle analysisCycle,
        out IStockData<IStockPrice> targetPrices
    );

    /// <summary>
    /// 用价格信息计算指标
    /// </summary>
    /// <param name="input"></param>
    /// <param name="output"></param>
    /// <returns></returns>
    Task<bool> TryGenerateIndicators(
        IInput input,
        out IOutput output
    );
}