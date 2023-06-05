
using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
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

    public static List<StockSets> Merge(
        this List<StockSets> sets,
        LineOfPoint indicatorValue,
        StockAnalysisCycle cycle)
    {
        var setsList = indicatorValue
            .LatestList()
            .Select(o => (o.Current.MarkTime, o.Features()))
            .ToList();

        sets.ForEach(o =>
        {
            var ss = setsList.FindLast(x => x.MarkTime.Subtract(o.MarkTime).TotalDays >= 0);
            o.SetKeys = o.SetKeys.Union(ss.Item2.Select(y => $"{y}.{cycle}"));
        });

        return sets;
    }

    public static List<Latest> LatestList(this LineOfPoint line)
    {
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

}