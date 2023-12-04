//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Threading.Tasks;

using Ban3.Infrastructures.GeneralImpl.Response;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

#nullable enable
namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

/// 
public class StockEventsFromSina : OneImplement, IStockEventsCollector
{
    private IInternetsHelper _internetsHelper;
    private IStoragesHelper _storagesHelper;

    /// 
    public StockEventsFromSina(
        IInternetsHelper internetsHelper,
        IStoragesHelper storagesHelper
    )
    {
        _internetsHelper = internetsHelper;
        _storagesHelper = storagesHelper;
    }

    /// 
    public async Task<bool> TryFetchEvents( IStock stock, Action<IStockData<IStockEvent>>? action )
        => await _internetsHelper.TryRequest(
            Request.SinaRequest.ResourceForEvents( stock.Symbol ),
            callback =>
            {
                var data = SinaResponse.ResultToEvents( callback, stock );

                if( action == null )
                {
                    _storagesHelper.TrySave( data, stock.Symbol );
                }
                else
                {
                    action( data );
                }
            } );

    /// 
    public async Task<IStockData<IStockEvent>> TryLoad( IStock stock )
        => await _storagesHelper.TryLoad<IStockData<IStockEvent>>( stock.Symbol );
}