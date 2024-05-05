//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Implements.Alpha.Applications;

/// <summary>
/// 数据加载部分
/// </summary>
public partial class CasinoServer
{
    /// <summary>
    /// 获取标的
    /// </summary>
    /// <returns></returns>
    public List<Stock> LoadStocks()
        => _databaseServer.LoadList<Stock>(typeof(Stock))
        .Select(o => (Stock)o)
        .ToList();

    /// <summary>
    /// 获取标的分红解禁事件信息
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public List<Bonus> LoadOnesBonus(Stock stock)
         => _databaseServer
        .LoadList<Bonus>(typeof(Bonus), () => stock.Code)
        .Select(o => (Bonus)o)
        .OrderBy(o => o.MarkTime)
        .ToList();

    /// <summary>
    /// 获取价格数据
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public List<Price> LoadOnesPrices(Stock stock, CycleIs? cycle)
    {
        var key = cycle == null ? stock.Code : $"{stock.Code}.{cycle}";
        return _databaseServer
            .LoadList<Price>(typeof(Price), () => key)
        .Select(o => (Price)o)
        .ToList();
    }

    /// <summary>
    /// 获取复权因子
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public List<Reinstate> LoadOnesSeeds(Stock stock)
        => _databaseServer
        .LoadList<Reinstate>(typeof(Reinstate), () => stock.Code)
        .Select(o => (Reinstate)o)
        .OrderBy(o => o.MarkTime)
        .ToList();

    /// <summary>
    /// 获取标的指标与特征值
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public Result LoadResult(Stock stock)
        => _databaseServer.Load<Result>(stock.Code);

    /// <summary>
    /// 获取汇总报告
    /// </summary>
    /// <returns></returns>
    public Summary LoadSummary()
        => _databaseServer.Load<Summary>("all");
}
