//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-26
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Ban3.Infrastructures.GeneralImpl.Entries.Casino;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Filters;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

public class StocksAnalyzer : OneImplement, IStocksAnalyzer
{
    private IStoragesHelper _storagesHelper;

    public StocksAnalyzer(
        IStoragesHelper storagesHelper )
    {
        _storagesHelper = storagesHelper;
    }

    /// 用特征值生成建议
    public async Task<bool> TryGenerateSuggests(
        IStockFilter stockFilter,
        IOutput output,
        Action<IStockData<IStockSuggest>> action
    )
    {
        var result = new StockData<StockSuggest>
        {
            Code = output.Code,
            Values = new List<StockSuggest>()
        };

        var previousSuggest = new StockSuggest { Code = output.Code };

        return await _storagesHelper.TrySave( result, output.Code );
    }

    /// 提供(个股)建议
    public async Task<IStockData<IStockSuggest>> TryLoadSuggests( IStock stock )
        => await _storagesHelper.TryLoad<IStockData<IStockSuggest>>( stock.Code );
}