// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

using System.Threading.Tasks;
using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 价格数据收集
/// </summary>
public interface IStockPricesCollector
{
    /// <summary>
    /// 价格数据
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="action">处理动作</param>
    /// <returns></returns>
    Task<bool> TryFetchPrices( IStock stock, Action<IStockData<IStockPrice>> action );

    /// <summary>
    /// 提供价格数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<bool> TryLoad( out IEnumerable<IStockPrice> data );
}