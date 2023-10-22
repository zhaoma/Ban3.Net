using Ban3.Infrastructures.ServiceCentre.Entries.Casino;
using Ban3.Infrastructures.ServiceCentre.Entries.Casino.Items;
using System.Threading.Tasks;

namespace Ban3.Infrastructures.ServiceCentre.Applications.Casino;

/// <summary>
/// 价格数据收集
/// </summary>
public interface IStockPricesCollector
{
    /// <summary>
    /// 价格数据
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="stockPrices"></param>
    /// <returns></returns>
    Task<bool> TryFetchPrices(IStock stock, out IStockData<IStockPrice> stockPrices);

}