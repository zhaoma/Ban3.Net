using Ban3.Implements.Alpha.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ban3.Implements.Alpha.Applications;

public partial class CasinoServer
{
    /// <summary>
    /// 获取标的
    /// </summary>
    /// <returns></returns>
    public List<IStock> LoadStocks()
        => _databaseServer.LoadList<Stock>(typeof(Stock))
        .Select(o => (IStock)o)
        .ToList();

    /// <summary>
    /// 获取标的分红解禁事件信息
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public List<IBonus> LoadOnesBonus(IStock stock)
         => _databaseServer
        .LoadList<Bonus>(typeof(Bonus), () => stock.Code)
        .Select(o => (IBonus)o)
        .OrderBy(o => o.MarkTime)
        .ToList();

    /// <summary>
    /// 获取价格数据
    /// </summary>
    /// <param name="stock"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public List<IPrice> LoadOnesPrices(IStock stock, CycleIs? cycle)
    {
        var key = cycle == null ? stock.Code : $"{stock.Code}.{cycle}";
        return _databaseServer
            .LoadList<Price>(typeof(Price), () => key)
        .Select(o => (IPrice)o)
        .ToList();
    }

    /// <summary>
    /// 获取复权因子
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public List<IReinstate> LoadOnesSeeds(IStock stock)
        => _databaseServer
        .LoadList<Reinstate>(typeof(Reinstate), () => stock.Code)
        .Select(o => (IReinstate)o)
        .OrderBy(o => o.MarkTime)
        .ToList();


    /// <summary>
    /// 获取标的指标与特征值
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public IResult LoadResult(IStock stock)
        => _databaseServer.Load<Result>(stock.Code);

    /// <summary>
    /// 获取汇总报告
    /// </summary>
    /// <returns></returns>
    public ISummary LoadSummary()
        => _databaseServer.Load<Summary>("all");
}
