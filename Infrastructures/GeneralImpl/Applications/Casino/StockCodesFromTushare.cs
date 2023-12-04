// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.GeneralImpl.Response;

#nullable enable
namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

/// 
public class StockCodesFromTushare : OneImplement, IStockCodesCollector
{
    private IInternetsHelper _internetsHelper;
    private IStoragesHelper _storagesHelper;

    /// 
    public StockCodesFromTushare(
        IInternetsHelper internetsHelper,
        IStoragesHelper storagesHelper
    )
    {
        _internetsHelper = internetsHelper;
        _storagesHelper = storagesHelper;
    }

    /// 
    public async Task<bool> TryFetchStocks( Action<IEnumerable<IStock>>? action )
        => await _internetsHelper.TryRequest(
            Request.TushareRequest.ResourceForCodes(),
            callback =>
            {
                var data = TushareResponse
                          .ResultToCodes( callback )
                          .OrderBy( o => o.Code )
                          .ToList();

                if( action == null )
                {
                    _storagesHelper.TrySave( data, "all" );
                }
                else
                {
                    action( data );
                }
            } );

    /// 
    public async Task<IEnumerable<IStock>> TryLoad()
        => await _storagesHelper.TryLoad<IEnumerable<Stock>>( "all" );
}