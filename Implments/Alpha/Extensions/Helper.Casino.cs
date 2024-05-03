//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Entries.CasinoServer;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Implements.Alpha.Extensions;

/// <summary>
/// Casino的一些静态扩展方法
/// </summary>
public static partial class Helper
{
    public static void AppendLatest(this List<Price> prices, Price addPrice, CycleIs cycle)
    {
        Price price = new Price
        {
            Code = addPrice.Code,
            TradeDate = addPrice.MarkTime.ToYmd(),
            Open = addPrice.Open,
            High = addPrice.High,
            Low = addPrice.Low,
            Close = addPrice.Close,
            PreClose = addPrice.PreClose,
            Volumn = addPrice.Volumn,
            Amount = addPrice.Amount
        };
        if (!prices.Any())
        {
            prices.Add(price);
            return;
        }

        Price price2 = prices.Last();
        string strValue = price2.MarkTime.End(cycle).ToYmd();
        string strValue2 = price.MarkTime.End(cycle).ToYmd();
        if (strValue.ToInt().Equals(strValue2.ToInt()))
        {
            price2.Close = price.Close;
            price2.High = Math.Max(price2.High, price.High);
            price2.Low = Math.Min(price2.Low, price.Low);
            price2.Volumn += price.Volumn;
            price2.Amount += price.Amount;
            price2.Change = price2.Close - price2.PreClose;
            price2.ChangePercent = price2.PreClose != 0.0M ? Math.Round((price2.Close - price2.PreClose) / price2.PreClose * 100.0M, 2) : 0M;
        }
        else
        {
            prices.Add(price);
        }
    }

    private static DateTime End(this DateTime begin, CycleIs stockCycle)
    {
        if (stockCycle != CycleIs.Weekly)
        {
            return begin.FindMonthEnd();
        }

        return begin.FindWeekEnd();
    }

    public static decimal EMA(
        this List<Price> prices,
        Func<Price, decimal> selectValue,
        int current,
        int period)
    {
        var total = 0M;
        var counter = 0;
        var start = Math.Max(0, current - period);

        for (var i = start; i <= current; i++)
        {
            total += (i - start) * selectValue(prices[i]);
            counter += i - start;
        }

        return counter > 0 ? Math.Round(total / counter, 3) : 0;
    }

    public static decimal EMA(
        this List<decimal> numbers,
        int current,
        int period)
    {
        var total = 0M;
        var counter = 0;
        var start = Math.Max(0, current - period);

        for (var i = start; i <= current; i++)
        {
            total += (i - start) * numbers[i];
            counter += i - start;
        }

        return counter > 0 ? Math.Round(total / counter, 3) : 0;
    }

    public static decimal MA(
        this List<Price> prices,
        Func<Price, decimal> selectValue,
        int current,
        int period)
    {
        var total = 0M;
        var counter = 0;
        var start = Math.Max(0, current - period);

        for (int i = start; i < current; i++)
        {
            total += selectValue(prices[i]);
            counter++;
        }

        return counter > 0 ? Math.Round(total / counter, 3) : 0;
    }

    public static decimal MA(
        this List<decimal> numbers,
        int current,
        int period)
    {
        var total = 0M;
        var counter = 0;
        var start = Math.Max(0, current - period);

        for (int i = start; i < current; i++)
        {
            total += numbers[i];
            counter++;
        }

        return counter > 0 ? Math.Round(total / counter, 3) : 0;
    }


}
