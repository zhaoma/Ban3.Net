// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Filters;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 标的数据分析
/// </summary>
public interface IStocksAnalyzer
{
    /// <summary>
    /// 用特征值生成建议
    /// </summary>
    /// <param name="stockFilter"></param>
    /// <param name="output"></param>
    /// <param name="action"></param>
    /// <returns></returns>
    Task<bool> TryGenerateSuggests(
        IStockFilter stockFilter,
        IOutput output,
        Action<IStockData<IStockSuggest>> action
    );

    /// <summary>
    /// 提供(个股)建议
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    Task<IStockData<IStockSuggest>> TryLoadSuggests( IStock stock );
}