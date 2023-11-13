// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 标的采集
/// </summary>
public interface IStockCodesCollector
{
    /// <summary>
    /// 标的采集
    /// </summary>
    /// <param name="action">标的集合</param>
    /// <returns></returns>
    Task<bool> TryFetchStocks(Action<IEnumerable<IStock>> action);

    /// <summary>
    /// 提供标的
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<bool> TryLoad(out IEnumerable<IStock> data);
}