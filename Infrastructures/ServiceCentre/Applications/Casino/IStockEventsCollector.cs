// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

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
    /// <param name="action">事件集合</param>
    /// <returns></returns>
    Task<bool> TryFetchEvents(IStock stock, Action<IStockData<IStockEvent>> action);

    /// <summary>
    /// 提供事件数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<bool> TryLoad(out IEnumerable<IStockEvent> data);
}