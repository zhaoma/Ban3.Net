// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

#nullable enable
namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 标的采集
/// </summary>
public interface IStockCodesCollector
{
    /// <summary>
    /// 标的采集
    /// </summary>
    /// <param name="action">处理动作</param>
    /// <returns></returns>
    Task<bool> TryFetchStocks( Action<IEnumerable<IStock>>? action );

    /// <summary>
    /// 提供标的
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<IStock>> TryLoad();
}