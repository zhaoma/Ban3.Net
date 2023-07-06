using System;
using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
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

    /// <summary>
    /// 只在交易时间运行ca --realtime
    /// </summary>
    /// <returns></returns>
    public static bool NeedSync() 
    {
        var now = DateTime.Now.ToString("HHmm").ToInt();
        //and <= 1130 or >= 1300
        return now is >= 915  and <= 1500;
    } 
}