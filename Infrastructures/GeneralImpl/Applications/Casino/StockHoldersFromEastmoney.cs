//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI . 2023-11-25
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Applications.Casino;
using Ban3.Infrastructures.ServiceCentre.Applications;
using Ban3.Infrastructures.ServiceCentre.Applications.Hybird;

using System;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

using System.Collections.Generic;
using System.Threading.Tasks;

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
    public async Task<bool> TryFetchHolders( Action<IEnumerable<IStockHolder>> action ) {}

    /// 
    public async Task<IEnumerable<IStockHolder>> TryLoad( IStockHolder stockHolder ) {}

    /// 
    public async Task<IEnumerable<IStockHolder>> TryLoad( IStock stock ) {}
}