//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using Ban3.Infrastructures.GeneralImpl.Entries.Casino.Items;

#nullable enable
namespace Ban3.Infrastructures.GeneralImpl.Applications.Casino;

/// 
public class StockHoldersFromEastmoney : OneImplement, IStockHoldersCollector
{
    private IInternetsHelper _internetsHelper;
    private IStoragesHelper _storagesHelper;

    /// 
    public StockHoldersFromEastmoney(
        IInternetsHelper internetsHelper,
        IStoragesHelper storagesHelper
    )
    {
        _internetsHelper = internetsHelper;
        _storagesHelper = storagesHelper;
    }

    /// 
    public async Task<bool> TryFetchHolders(
        IStock stock,
        Action<IEnumerable<IStockHolder>>? action )
    {
        return await Task.FromResult( true );
    }

    /// 
    public async Task<IEnumerable<IStockHolder>> TryLoad( IStockHolder stockHolder )
        => await _storagesHelper.TryLoad<IEnumerable<StockHolder>>( $"Holder.{stockHolder.Code}.Stocks" );

    /// 
    public async Task<IEnumerable<IStockHolder>> TryLoad( IStock stock )
        => await _storagesHelper.TryLoad<IEnumerable<StockHolder>>( $"Stock.{stock.Code}.Holders" );
}