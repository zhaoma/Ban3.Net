// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 标的事件数据收集
/// </summary>
public interface IStockEventsCollector
{
    /// <summary>
    /// 标的事件数据
    /// </summary>
    /// <param name="stock">标的</param>
    /// <param name="action">处理动作</param>
    /// <returns></returns>
    Task<bool> TryFetchEvents( IStock stock, Action<IStockData<IStockEvent>> action );

    /// <summary>
    /// 提供事件数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<bool> TryLoad( out IEnumerable<IStockEvent> data );
}