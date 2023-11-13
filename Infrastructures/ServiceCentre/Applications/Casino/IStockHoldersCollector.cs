// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 大股东数据收集
/// </summary>
public interface IStockHoldersCollector
{
    /// <summary>
    /// 准备大股东数据
    /// </summary>
    /// <param name="action">大股东数据</param>
    /// <returns></returns>
    Task<bool> TryFetchHolders(out IEnumerable<IStockHolder> action);

    /// <summary>
    /// 提供大股东数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<bool> TryLoad(out IEnumerable<IStockHolder> data);

}