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
    /// <param name="stocks">标的集合</param>
    /// <returns></returns>
    Task<bool> TryFetchStocks(out IEnumerable<IStock> stocks);
}