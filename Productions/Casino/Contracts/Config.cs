using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Request;

namespace Ban3.Productions.Casino.Contracts;

public class Config
{
    public const int MaxParallelTasks = 20;
    public const int FixDailyPrices = 10;
    public const int FixPageSize = 100;

    public static string CacheKey<T>(string key)
        => $"{typeof(T).Name}.{key}";

    public static FocusFilter DefaultFilter = new FocusFilter
    {
        Identity = "FF752",
        Subject = "日7周25月40",
        BuyingCondition = new Dictionary<StockAnalysisCycle, float>
        {
            { StockAnalysisCycle.DAILY, 7F },
            { StockAnalysisCycle.WEEKLY, 20F },
            { StockAnalysisCycle.MONTHLY, 40F }
        },
        SellingCondition = new Dictionary<StockAnalysisCycle, float>
        {
            { StockAnalysisCycle.DAILY, -7F },
            { StockAnalysisCycle.WEEKLY, -20F },
            { StockAnalysisCycle.MONTHLY, -40F }
        }
    };

    public static bool NeedSync() 
    {
        var result = false;

        var now = DateTime.Now.ToString("HHmm").ToInt();

        result = result || (now >= 915 && now <= 1130);

        result = result || (now >= 1300 && now <= 1500);

        return result;
    } 
}