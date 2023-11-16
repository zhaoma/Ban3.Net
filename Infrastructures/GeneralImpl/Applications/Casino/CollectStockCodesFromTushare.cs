// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.GeneralImpl.Response;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

/// <summary>
/// 
/// </summary>
public class CollectStockCodesFromTushare : OneImplement, IStockCodesCollector
{
    private IInternetsHelper _internetsHelper;
    private IStoragesHelper _storagesHelper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="internetsHelper"></param>
    /// <param name="storagesHelper"></param>
    public CollectStockCodesFromTushare(
        IInternetsHelper internetsHelper,
        IStoragesHelper storagesHelper
    )
    {
        _internetsHelper = internetsHelper;
        _storagesHelper = storagesHelper;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    public async Task<bool> TryFetchStocks( Action<IEnumerable<IStock>> action )
        => await _internetsHelper.TryRequest(
            Request.TushareRequest.Host(),
            Request.TushareRequest.ResourceForCodes(),
            callback =>
            {
                var data = TushareResponse.ResultToCodes( callback );

                _storagesHelper.TrySave( data, "all" );

                action( data );
            } );

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<IStock>> TryLoad()
        => await _storagesHelper.TryLoad<IEnumerable<Stock>>( "all" );
}