using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
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
    /// <param name="stockNotions">题材概念数据</param>
    /// <returns></returns>
    Task<bool> PrepareStockNotions(out IEnumerable<IStockNotion> stockNotions);

}