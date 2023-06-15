using System.Collections.Generic;
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
        Identity = "D7W30M40",
        Subject = "D7W30M40",
        MinChangePercent = new Dictionary<StockAnalysisCycle, float>
        {
            { StockAnalysisCycle.DAILY, 7F },
            { StockAnalysisCycle.WEEKLY, 30F },
            { StockAnalysisCycle.MONTHLY, 40F }
        },
        MaxChangePercent = new Dictionary<StockAnalysisCycle, float>
        {
            { StockAnalysisCycle.DAILY, 21F }
        }
    };
}