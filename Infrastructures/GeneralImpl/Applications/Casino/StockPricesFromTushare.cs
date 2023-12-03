// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.GeneralImpl.Response;
using Ban3.Infrastructures.GeneralImpl.Request;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

/// 
public class CollectStockPricesFromTushare : OneImplement, IStockPricesCollector
{
    private IInternetsHelper _internetsHelper;
    private IStoragesHelper _storagesHelper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="internetsHelper"></param>
    /// <param name="storagesHelper"></param>
    public CollectStockPricesFromTushare(
        IInternetsHelper internetsHelper,
        IStoragesHelper storagesHelper
    )
    {
        _internetsHelper = internetsHelper;
        _storagesHelper = storagesHelper;
    }

    /// 
    public async Task<bool> TryFetchPrices( IStock stock, Action<IStockData<IStockPrice>> action )
        => await _internetsHelper.TryRequest(
            TushareRequest.ResourceForPrices( stock ),
            callback =>
            {
                var data = TushareResponse.ResultToPrices( callback, stock );

                _storagesHelper.TrySave( data, stock.Code );

                action( data );
            } );
}