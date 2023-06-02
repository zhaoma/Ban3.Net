using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

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

    public static List<StockPrice> ConvertCycle(this List<StockPrice> dailyPrices, StockAnalysisCycle targetCycle)
    {
        var result=new List<StockPrice>();

        if (dailyPrices != null && dailyPrices.Any())
        {
            var lastRecord = dailyPrices[0];
            foreach (var price in dailyPrices)
            {
                var endDate = targetCycle == StockAnalysisCycle.WEEKLY
                    ? lastRecord.TradeDate.ToDateTimeEx().FindWeekend()
                    : lastRecord.TradeDate.ToDateTimeEx().FindMonthend();

                if (endDate.Subtract(price.TradeDate.ToDateTimeEx()).TotalDays >= 0)
                {
                    lastRecord.TradeDate = price.TradeDate;
                    lastRecord.High = Math.Max(lastRecord.High, price.High);
                    lastRecord.Low = Math.Min(lastRecord.Low, price.Low);
                    lastRecord.Vol += price.Vol;
                    lastRecord.Amount += price.Amount;
                    lastRecord.Close = price.Close;
                }
                else
                {
                    result.Add(lastRecord);
                    lastRecord= price;
                }
            }
        }

        return result;
    }
}