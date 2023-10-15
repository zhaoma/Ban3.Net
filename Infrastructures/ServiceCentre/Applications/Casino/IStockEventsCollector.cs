using System.Collections.Generic;
using System.Threading.Tasks;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino;

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
    /// <param name="stockEvents">事件集合</param>
    /// <returns></returns>
    Task<bool> PrepareStockEvents(IStock stock, out IEnumerable<IStockEvent> stockEvents);
}