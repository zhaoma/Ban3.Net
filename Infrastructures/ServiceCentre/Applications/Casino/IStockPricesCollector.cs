//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

#nullable enable
namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 价格数据收集
/// </summary>
public interface IStockPricesCollector
{
    /// <summary>
    /// 价格数据(历史日行情)
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="action">处理动作</param>
    /// <returns></returns>
    Task<bool> TryFetchPrices( IStock stock, Action<IStockData<IStockPrice>>? action );
}