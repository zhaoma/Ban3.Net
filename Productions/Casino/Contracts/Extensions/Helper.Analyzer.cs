
using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Entries;
using Ban3.Infrastructures.Indicators.Entries;
using System;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    /// <summary>
    /// 用行情数据生成指标特征集
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stock"></param>
    /// <param name="prices"></param>
    /// <returns></returns>
    public static List<StockSets> PrepareSets(
        this IAnalyzer _,
        Stock stock,
        List<StockPrice> prices
        )
    {
        var result = prices.Select(o => new StockSets
        {
            Close = (decimal)o.Close,
            MarkTime = o.TradeDate.ToDateTimeEx(),
            Code = stock.Code,
            Symbol = stock.Symbol,
            SetKeys = new List<string>()
        }).ToList();

        return result;
    }

    /// <summary>
    /// 指标特征集合并日/周/月指标特征集
    /// </summary>
    /// <param name="sets"></param>
    /// <param name="indicatorValue"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public static List<StockSets> Merge(
        this List<StockSets> sets,
        LineOfPoint indicatorValue,
        StockAnalysisCycle cycle)
    {
        var latestList = indicatorValue
            .LatestList();

        if (latestList == null ||  !latestList.Any()) return sets;

        var setsList = latestList
            .Select(o => (o.Current.MarkTime, o.Features()))
            .ToList();

        sets.ForEach(o =>
        {
            var ss = setsList.FindLast(x => x.MarkTime.Subtract(o.MarkTime).TotalDays >= 0);
            if (ss.Item2!=null&&ss.Item2.Any())
                o.SetKeys = o.SetKeys.Union(ss.Item2.Select(y => $"{y}.{cycle}"));
        });

        return sets;
    }

    /// <summary>
    /// 指标值线转换点
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static List<Latest> LatestList(this LineOfPoint line)
    {
        if (line.EndPoints != null && line.EndPoints.Any()) return null;

        var list = line.EndPoints.Select(o => new Latest
        {
            Current = o
        }).ToList();

        for (var i = 1; i < list.Count; i++)
        {
            list[i].Prev = list[i - 1].Current;
        }

        return list;
    }

    /// <summary>
    /// 指标特征集转换版单
    /// </summary>
    /// <param name="stockSets"></param>
    /// <param name="listName"></param>
    /// <returns></returns>
    public static bool GenerateList(this List<StockSets> stockSets,string listName) 
    {
        var result = stockSets
            .Where(o => o.SetKeys != null && o.SetKeys.Any())
            .Select(o => new ListRecord(o))
            .OrderByDescending(o => o.Value)
            .ToList();

        var rank = 1;
        int? prev = null;
        foreach (var r in result)
        {
            if (prev == null || r.Value == prev.Value)
            {
                r.Rank = rank;
            }
            else
            {
                rank++;
            }

            prev = r.Value;
        }

        var saved = listName
            .DataFile<ListRecord>()
            .WriteFile(result.ObjToJson());

        return !string.IsNullOrEmpty(saved);
    }



}