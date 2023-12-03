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
/// 大股东数据收集
/// </summary>
public interface IStockHoldersCollector
{
    /// <summary>
    /// 准备大股东数据
    /// </summary>
    /// <param name="action">处理动作</param>
    /// <returns></returns>
    Task<bool> TryFetchHolders( Action<IEnumerable<IStockHolder>> action );

    /// <summary>
    /// 提供大股东数据
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<IStockHolder>> TryLoad( IStockHolder stockHolder );

    /// <summary>
    /// 提供大股东数据(个股)
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    Task<IEnumerable<IStockHolder>> TryLoad( IStock stock );
}