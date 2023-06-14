using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// Stock扩展方法，常规转换
/// </summary>
public static partial class Helper
{

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static StockGroup GetStockGroup(this string code)
    {
        if (code.Length < 6)
            return (StockGroup)0;
        string str = code.Substring(0, 3);
        if (str == "000")
            return StockGroup.SZA;
        if (str == "002" || str == "003")
            return StockGroup.SZZ;
        if (str == "300" || str == "301")
            return StockGroup.SZC;
        return str == "688" ? StockGroup.SHK : StockGroup.SHA;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <returns></returns>
    public static string GetStockPrefix(this string code)
    {
        switch (code.GetStockGroup())
        {
            case StockGroup.SZA:
            case StockGroup.SZZ:
            case StockGroup.SZC:
                return "sz";
            default:
                return "sh";
        }
    }

    public static string GetStockNumPrefix(this string code)
        => code.GetStockPrefix() == "sz" ? "1" : "0";

    /// <summary>
    /// 价格周期转换
    /// </summary>
    /// <param name="dailyPrices"></param>
    /// <param name="targetCycle"></param>
    /// <returns></returns>
    public static List<StockPrice> ConvertCycle(
        this List<StockPrice> dailyPrices,
        StockAnalysisCycle targetCycle)
    {
        var result = new List<StockPrice>();

        if (dailyPrices != null && dailyPrices.Any())
        {
            dailyPrices = dailyPrices.OrderBy(o => o.TradeDate).ToList();
            var lastRecord = dailyPrices[0];
            var endDate = lastRecord.TradeDate.ToDateTimeEx().NextDate(targetCycle);
            for (var i=0;i<dailyPrices.Count;i++)
            {
                var price = dailyPrices[i];

                if (endDate.ToYmd().ToInt() > price.TradeDate.ToInt())
                {
                    lastRecord.TradeDate = price.TradeDate;
                    lastRecord.High = Math.Max(lastRecord.High, price.High);
                    lastRecord.Low = Math.Min(lastRecord.Low, price.Low);
                    lastRecord.Vol += price.Vol;
                    lastRecord.Amount += price.Amount;
                    lastRecord.Close = price.Close;

                    if (i == dailyPrices.Count - 1)
                    {
                        result.Add(lastRecord);
                    }
                }
                else
                {
                    lastRecord.Change = lastRecord.Close - lastRecord.PreClose;
                    lastRecord.ChangePercent=lastRecord.PreClose != 0
                        ?(float)Math.Round((lastRecord.Close-lastRecord.PreClose) /lastRecord.PreClose,2)
                        :0F;
                    result.Add(lastRecord);
                    lastRecord = price;
                    endDate = endDate.AddDays(1).NextDate(targetCycle);
                }
            }
        }

        return result;
    }

    static DateTime NextDate(this DateTime from, StockAnalysisCycle targetCycle)
    {
        return targetCycle == StockAnalysisCycle.WEEKLY
            ? from.FindWeekend()
            : from.FindMonthend();
    }
}