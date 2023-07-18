using System;
using System.Collections.Generic;
using System.IO;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;

namespace Ban3.Productions.Casino.Contracts;

public class Config
{
    public static int MaxParallelTasks =Infrastructures.Common.Config.GetValue("Config:MaxParallelTasks").ToInt(30) ;
    public const int FixDailyPrices = 10;
    public const int FixPageSize = 100;

    public static string CacheKey<T>(string key) => $"{typeof(T).Name}.{key}";

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
    
    /// <summary>
    /// 当前策略集合
    /// </summary>
    /// <returns></returns>
    public static List<Profile> Profiles()
    {
        var profileFile = typeof(Profile).LocalFile();
        return Config.CacheKey<Profile>("all")
             .LoadOrSetDefault(() =>
             {
                 var ps = Infrastructures.Indicators.Helper.DefaultProfiles;
                 if (!File.Exists(profileFile))
                 {
                     profileFile.WriteFile(ps.ObjToJson());
                 }

                 return ps;
             }, profileFile);
    }

    /// <summary>
    /// 当前分拣条件集合
    /// </summary>
    /// <returns></returns>
    public static List<DistributeCondition> DistributeConditions()
    {
        var profileFile = typeof(DistributeCondition).LocalFile();
        return Config.CacheKey<DistributeCondition>("all")
             .LoadOrSetDefault(() =>
             {
                 var ps = new List<DistributeCondition>
                 {
                     new DistributeCondition(
                        1,
                        "科创板三周期",
                        new DistributeExpression
                        {
                            StartsWith="68",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        2,
                        "科创板日与周",
                        new DistributeExpression
                        {
                            StartsWith="68",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        3,
                        "科创板日周期",
                        new DistributeExpression
                        {
                            StartsWith="68",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        11,
                        "创业板三周期",
                        new DistributeExpression
                        {
                            StartsWith="30",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        12,
                        "创业板日与周",
                        new DistributeExpression
                        {
                            StartsWith="30",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        13,
                        "创业板日周期",
                        new DistributeExpression
                        {
                            StartsWith="30",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        21,
                        "中小板三周期",
                        new DistributeExpression
                        {
                            StartsWith="002,003",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        22,
                        "中小板日与周",
                        new DistributeExpression
                        {
                            StartsWith="002,003",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        23,
                        "中小板日周期",
                        new DistributeExpression
                        {
                            StartsWith="002,003",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        31,
                        "沪主板三周期",
                        new DistributeExpression
                        {
                            StartsWith="60",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        32,
                        "沪主板日与周",
                        new DistributeExpression
                        {
                            StartsWith="60",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        33,
                        "沪主板日周期",
                        new DistributeExpression
                        {
                            StartsWith="60",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        41,
                        "深主板三周期",
                        new DistributeExpression
                        {
                            StartsWith="000,001",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        42,
                        "深主板日与周",
                        new DistributeExpression
                        {
                            StartsWith="000,001",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        43,
                        "深主板日周期",
                        new DistributeExpression
                        {
                            StartsWith="000,001",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        51,
                        "100+",
                        new DistributeExpression
                        {
                            MinPrice=100,
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        52,
                        "5-",
                        new DistributeExpression
                        {
                            MaxPrice=5,
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                 };

                 if (!File.Exists(profileFile))
                 {
                     profileFile.WriteFile(ps.ObjToJson());
                 }

                 return ps;
             }, profileFile);
    }

}