using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;

namespace Ban3.Productions.Casino.Contracts;

/// 
public class Config
{
    /// 
    public static int MaxParallelTasks = Infrastructures.Common.Config.GetValue("Config:MaxParallelTasks").ToInt(30);

    /// 
    public static List<string> IgnoreKeys = Infrastructures.Common.Config.GetValue("Config:IgnoreKeys") == ""
        ? new List<string>
        {
            "MACD.N.DAILY", "MACD.MDI.DAILY"
        }
        : Infrastructures.Common.Config.GetValue("Config:IgnoreKeys").Split(';').ToList();

    ///
    public const int FixDailyPrices = 10;

    /// 
    public const int FixPageSize = 100;

    /// 
    public static string CacheKey<T>(string key) => $"{typeof(T).Name}.{key}";

    /// <summary>
    /// 只在交易时间运行ca --realtime
    /// </summary>
    /// <returns></returns>
    public static bool NeedSync()
    {
        var now = DateTime.Now.ToString("HHmm").ToInt();
        //and <= 1130 or >= 1300
        return now is >= 915 and <= 1500;
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
		            new (
                        0,
                        "次新横盘",
                        new DistributeExpression
                        {
                            StartsWith = "68,002,003,30",
                            HasWeek = true, 
                            MaxIncrease=5,
                            MaxDays=250,
                            Sorter = RecordsSorter.Increase
                        },
                        true
                    ),
                    new (
                        1,
                        "科创板三周期",
                        new DistributeExpression
                        {
                            StartsWith = "68",
                            HasWeek = true, HasMonth = true,
                            Sorter = RecordsSorter.Increase
                        },
                        true
                    ),
                    new (
                        2,
                        "科创板日与周",
                        new DistributeExpression
                        {
                            StartsWith = "68",
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
                        },
                        true
                    ),
                    new (
                        3,
                        "科创板日周期",
                        new DistributeExpression
                        {
                            StartsWith = "68",
                            Sorter = RecordsSorter.Increase
                        }
                    ),

                    new (
                        11,
                        "创业板三周期",
                        new DistributeExpression
                        {
                            StartsWith = "30",
                            HasWeek = true, HasMonth = true,
                            Sorter = RecordsSorter.Increase
                        },
                        true
                    ),
                    new (
                        12,
                        "创业板日与周",
                        new DistributeExpression
                        {
                            StartsWith = "30",
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
                        },
                        true
                    ),
                    new (
                        13,
                        "创业板日周期",
                        new DistributeExpression
                        {
                            StartsWith = "30",
                            Sorter = RecordsSorter.Increase
                        }
                    ),

                    new (
                        21,
                        "中小板三周期",
                        new DistributeExpression
                        {
                            StartsWith = "002,003",
                            HasWeek = true, HasMonth = true,
                            Sorter = RecordsSorter.Increase
                        },
                        true
                    ),
                    new (
                        22,
                        "中小板日与周",
                        new DistributeExpression
                        {
                            StartsWith = "002,003",
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
                        }
                    ),
                    new (
                        23,
                        "中小板日周期",
                        new DistributeExpression
                        {
                            StartsWith = "002,003",
                            Sorter = RecordsSorter.Increase
                        }
                    ),

                    new (
                        31,
                        "沪主板三周期",
                        new DistributeExpression
                        {
                            StartsWith = "60",
                            HasWeek = true, HasMonth = true,
                            Sorter = RecordsSorter.Increase
                        }
                    ),
                    new (
                        32,
                        "沪主板日与周",
                        new DistributeExpression
                        {
                            StartsWith = "60",
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
                        }
                    ),
                    new (
                        33,
                        "沪主板日周期",
                        new DistributeExpression
                        {
                            StartsWith = "60",
                            Sorter = RecordsSorter.Increase
                        }
                    ),

                    new (
                        41,
                        "深主板三周期",
                        new DistributeExpression
                        {
                            StartsWith = "000,001",
                            HasWeek = true, HasMonth = true,
                            Sorter = RecordsSorter.Increase
                        }
                    ),
                    new (
                        42,
                        "深主板日与周",
                        new DistributeExpression
                        {
                            StartsWith = "000,001",
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
                        }
                    ),
                    new (
                        43,
                        "深主板日周期",
                        new DistributeExpression
                        {
                            StartsWith = "000,001",
                            Sorter = RecordsSorter.Increase
                        }
                    ),

                    new (
                        51,
                        "100+",
                        new DistributeExpression
                        {
                            MinPrice = 100,
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
                        },
                        true
                    ),
                    new (
                        52,
                        "5-",
                        new DistributeExpression
                        {
                            MaxPrice = 5,
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
                        },
                        true
                    ),
                    new (
                        53,
                        "5-30",
                        new DistributeExpression
                        {
                            MinPrice=5,
                            MaxPrice = 30,
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
                        },
                        true
                    ),
                    new (
                        54,
                        "30-60",
                        new DistributeExpression
                        {
                            MinPrice=30,
                            MaxPrice = 60,
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
                        }
                    ),
                    new (
                        55,
                        "60-100",
                        new DistributeExpression
                        {
                            MinPrice=60,
                            MaxPrice = 100,
                            HasWeek = true,
                            Sorter = RecordsSorter.Increase
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