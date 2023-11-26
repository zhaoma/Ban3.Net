// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Casino;

using System.Threading.Tasks;
using System.Collections.Generic;

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
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryGenerateSeeds(
        IStockData<IStockEvent> stockEvents,
        Action<IStockData<IStockSeed>> action
    );

    /// <summary>
    /// 提供(个股)复权因子
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    Task<IStockData<IStockSeed>> TryLoadSeeds( IStock stock );

    /// <summary>
    /// 提供(个股未复权)历史价格数据
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    Task<IStockData<IStockPrice>> TryLoadOriginalPrices( IStock stock );

    /// <summary>
    /// 价格复权
    /// </summary>
    /// <param name="sourcePrices"></param>
    /// <param name="stockSeeds"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryAdjustPrices(
        IStockData<IStockPrice> sourcePrices,
        IStockData<IStockSeed> stockSeeds,
        Action<IStockData<IStockPrice>> action
    );

    /// <summary>
    /// 周期转换，日->周/月
    /// </summary>
    /// <param name="dailyPrices"></param>
    /// <param name="analysisCycle"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryConvertCycle(
        IStockData<IStockPrice> dailyPrices,
        AnalysisCycle analysisCycle,
        Action<AnalysisCycle, IStockData<IStockPrice>> action
    );

    /// <summary>
    /// 提供价格数据(复权后)
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    Task<IStockData<IStockPrice>> TryLoadRehabilitatedPrices( 
	    IStock stock, 
	    AnalysisCycle cycle 
	);

    /// <summary>
    /// 用价格信息计算指标
    /// </summary>
    /// <param name="input"></param>
    /// <param name="output"></param>
    /// <returns></returns>
    Task<bool> TryGenerateIndicators(
        IInput input,
        Action<IOutput> output
    );

    /// <summary>
    /// 提供(个股)计算结果
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    Task<IOutput> TryLoadIndicators( IStock stock );
}