using System;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Productions.Casino.Contracts;

public class Config
{
    public static int MaxParallelTasks =Infrastructures.Common.Config.GetValue<int>("Config:MaxParallelTasks") ;
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