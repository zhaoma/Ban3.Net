using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
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
    /// <param name="stockHolders">大股东数据</param>
    /// <returns></returns>
    Task<bool> TryFetchHoldes(out IEnumerable<IStockHolder> stockHolders);
}