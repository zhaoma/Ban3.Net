//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

public class StockNotionsFromSohu
{
    private IStoragesHelper _storagesHelper;

    ///
    public StockNotionsFromSohu( IStoragesHelper storagesHelper )
    {
        _storagesHelper = storagesHelper;
    }

    ///
    public async Task<bool> TryFetchNotions( Action<IEnumerable<IStockNotion>> action )
    {
        return await Task.FromResult( true );
    }

    ///
    public async Task<IEnumerable<IStockNotion>> TryLoad()
        => await _storagesHelper.TryLoad<IEnumerable<StockNotion>>( "all" );

    ///
    public async Task<IEnumerable<IStock>> TryLoad( IStockNotion stockNotion )
        => await _storagesHelper.TryLoad<IEnumerable<Stock>>( $"Notion.{stockNotion.Id}.Stocks" );

    ///
    public async Task<IEnumerable<IStockNotion>> TryLoad( IStock stock )
        => await _storagesHelper.TryLoad<IEnumerable<StockNotion>>( $"Stock.{stock.Code}.Notions" );
}