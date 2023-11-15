// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using System;

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
    /// <param name="action">处理动作</param>
    /// <returns></returns>
    Task<bool> TryFetchNotions( Action<IEnumerable<IStockNotion>> action );

    /// <summary>
    /// 提供题材概念数据
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<IStockNotion>> TryLoad();

    /// <summary>
    /// 提供(个股)题材概念数据
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    Task<IEnumerable<IStockNotion>> TryLoad( IStock stock );

    /// <summary>
    /// 提供(题材概念相关)个股数据
    /// </summary>
    /// <param name="stockNotion"></param>
    /// <returns></returns>
    Task<IEnumerable<IStock>> TryLoad( IStockNotion stockNotion );
}