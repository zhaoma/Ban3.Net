// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

/// <summary>
/// 
/// </summary>
public class CollectStockCodeFromTushare : OneImplement, IStockCodesCollector
{
    private IInternetsHelper _internetsHelper;
    private IStoragesHelper _storagesHelper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="internetsHelper"></param>
    /// <param name="storagesHelper"></param>
    public CollectStockCodeFromTushare(
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
    {
        var host = new InternetHost
        {
            AuthenticationType = AuthenticationType.None,
            BaseUrl = @"http://api.tushare.pro"
        };

        var resource = Request.TushareRequest.ResourceForCodes();

        return await _internetsHelper.TryRequest(
            host,
            resource,
            callback =>
            {
                var data = callback.Response.StringContent.JsonToObj<List<Stock>>();
                _storagesHelper.TrySave( data, "all" );
                action( data );
            } );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<IStock>> TryLoad()
    {
        return await _storagesHelper.TryLoad<IEnumerable<Stock>>( "all" );
    }
}