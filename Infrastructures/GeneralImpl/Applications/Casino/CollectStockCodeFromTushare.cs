// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2022
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.GeneralImpl.Entries.Hybird;
using Ban3.Infrastructures.ServiceCentre.Enums.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

public class CollectStockCodeFromTushare : OneImplement, IStockCodesCollector
{
    private IInternetsHelper _internetsHelper;

    public CollectStockCodeFromTushare( IInternetsHelper internetsHelper )
    {
        _internetsHelper = internetsHelper;
    }

    public async Task<bool> TryFetchStocks( Action<IEnumerable<IStock>> action )
    {
        var host = new InternetHost
        {
            AuthenticationType = AuthenticationType.None,
            BaseUrl = @"http://api.tushare.pro"
        };

        var resource = new InternetResource
        {
            Url = @""
        };

        return await _internetsHelper.TryRequest(
            host,
            resource,
            callback =>
            {
                var data = callback.Response.StringContent.JsonToObj<IEnumerable<IStock>>();
                action( data );
            } );
    }
}