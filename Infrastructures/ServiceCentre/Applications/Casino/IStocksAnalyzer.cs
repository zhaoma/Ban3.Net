// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

public interface IStocksAnalyzer
{
    /// <summary>
    /// 用指标生成特征值
    /// </summary>
    /// <param name="output"></param>
    /// <param name="stockFeatures"></param>
    /// <returns></returns>
    Task<bool> TryGenerateFeatures(
        IOutput output,
        out IStockData<IStockFeature> stockFeatures
    );

    /// <summary>
    /// 用特征值生成
    /// </summary>
    /// <param name="stockFeatures"></param>
    /// <param name="stockSuggests"></param>
    /// <returns></returns>
    Task<bool> TryGenerateSuggests(
        IStockFilter stockFilter,
        IStockData<IStockFeature> stockFeatures,
        out IStockData<IStockSuggest> stockSuggests
    );
}