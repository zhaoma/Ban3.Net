// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 题材概念数据收集
/// </summary>
public interface IStockNotionsCollector
{
    /// <summary>
    /// 准备题材概念数据
    /// </summary>
    /// <param name="action">题材概念数据</param>
    /// <returns></returns>
    Task<bool> TryFetchNotions( out IEnumerable<IStockNotion> action );

    /// <summary>
    /// 提供题材概念数据
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<bool> TryLoad( out IEnumerable<IStockNotion> data );
}