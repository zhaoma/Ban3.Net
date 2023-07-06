using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Interfaces;
using log4net;

namespace Ban3.Productions.Casino.CcaAndReport;

/// <summary>
/// 
/// </summary>
[TracingIt]
public partial class Signalert
{
    public static ICollector Collector = new Collector();

    public static ICalculator Calculator = new Calculator();

    public static IAnalyzer Analyzer = new Analyzer();

    public static IReportor Reportor = new Reportor();

    #region 批量作业

    /// <summary>
    /// 完整任务
    /// 下载历史行情数据（分红配股事件及计算复权因子）
    /// </summary>
    /// <param name="reCalculateSeeds"></param>
    public static void ExecuteFullyJob(bool reCalculateSeeds = false)
    {
        Collector.PrepareAllCodes();

        var allCodes = Collector.LoadAllCodes();

        new Action(() => Collector.PrepareDailyPrices(allCodes)).ExecuteAndTiming("PrepareDailyPrices");

        if (reCalculateSeeds)
            PrepareEventsAndSeeds(allCodes);

        ExecutePrepare(allCodes);
    }

    #region 日常任务

    /// <summary>
    /// 日常任务
    /// 无参数，全市场
    /// </summary>
    public static void ExecuteDailyJob()
    {
        var allCodes = Collector.LoadAllCodes();

        ExecuteDailyJob(allCodes);
    }

    /// <summary>
    /// 指定codes，","分割
    /// </summary>
    /// <param name="codes"></param>
    public static void ExecuteDailyJob(string codes)
    {
        var cs = codes.Split(',');
        var allCodes = Collector.LoadAllCodes()
            .Where(x => cs.Contains(x.Code))
            .ToList();

        ExecuteDailyJob(allCodes);
    }

    /// <summary>
    /// 指定标的集合
    /// </summary>
    /// <param name="stocks"></param>
    public static void ExecuteDailyJob(List<Contracts.Entities.Stock> stocks)
    {
        new Action(() => Collector.FixDailyPrices(stocks)).ExecuteAndTiming("FixDailyPrices");

        ExecutePrepare(stocks);
    }

    #endregion

    #region 实时任务
    /*
    public static void ExecuteRealtimeJob()
    {
        var allCodes = Collector.LoadAllCodes();

        ExecuteRealtimeJob(allCodes);
    }

    public static void ExecuteRealtimeJob(string startsWith, string endsWith)
    {
        var allCodes = Collector.LoadAllCodes()
            .Where(o => (string.IsNullOrEmpty(startsWith) || o.Code.StartsWith(startsWith)
                && (string.IsNullOrEmpty(endsWith) || o.Code.EndsWith(endsWith))))
            .ToList();

        ExecuteRealtimeJob(allCodes);
    }

    public static void ExecuteRealtimeJob(string codes)
    {
        var cs = codes.Split(',');
        var allCodes = Collector.LoadAllCodes()
            .Where(x => cs.Contains(x.Code))
            .ToList();

        ExecuteRealtimeJob(allCodes);
    }

    /// <summary>
    /// 实时刷新数据
    /// </summary>
    /// <param name="stocks"></param>
    public static void ExecuteRealtimeJob(List<Stock> stocks)
    {
        new Action(() => Collector.ReadRealtime(stocks)).ExecuteAndTiming("ReadRealtime");

        ExecutePrepare(stocks);
    }
    */
    #endregion

    /// <summary>
    /// 计算复权价格
    /// 计算指标值
    /// 准备指标图表数据
    /// 准备指标特征数据
    /// 生成最新列表
    /// </summary>
    /// <param name="stocks"></param>
    static void ExecutePrepare(List<Contracts.Entities.Stock> stocks)
    {
        new Action(() => ReinstateAllPrices(stocks)).ExecuteAndTiming("ReinstateAllPrices");

        var filter = Infrastructures.Indicators.Helper.DefaultFilter;
        var latestSets = new List<StockSets>();
        var buyingDotsSets = new List<StockSets>();
        var sellingDotsSets = new List<StockSets>();
        var profileSummaries = new Dictionary<string, ProfileSummary>();
        var dotsDic = new Dictionary<string, List<DotInfo>>();

        new Action(() =>
            stocks.ParallelExecute(one =>
                {
                    var stock = new Infrastructures.Indicators.Entries.Stock
                        { Code = one.Code, ListDate = one.ListDate, Name = one.Name, Symbol = one.Symbol };

                    var dailyPrices = Calculator.LoadPricesForIndicators(stock.Code, StockAnalysisCycle.DAILY);

                    if (dailyPrices.SplitWeeklyAndMonthly(out var weeklyPrices, out var monthlyPrices))
                    {
                        weeklyPrices.SaveEntities(stock.FileNameWithCycle(StockAnalysisCycle.WEEKLY));

                        monthlyPrices.SaveEntities(stock.FileNameWithCycle(StockAnalysisCycle.MONTHLY));

                        var dailyLine = dailyPrices.CalculateIndicators()
                            .SaveFor(stock, StockAnalysisCycle.DAILY);
                        var dailySets = dailyLine.LineToSets(stock);

                        var weeklyLine = weeklyPrices.CalculateIndicators()
                            .SaveFor(stock, StockAnalysisCycle.WEEKLY);
                        var weeklySets = weeklyLine.LineToSets(stock);

                        var monthlyLine = monthlyPrices.CalculateIndicators()
                            .SaveFor(stock, StockAnalysisCycle.MONTHLY);
                        var monthlySets = monthlyLine.LineToSets(stock);

                        dailySets.MergeWeeklyAndMonthly(weeklySets, monthlySets)
                            .SaveFor(stock)
                            .PushLatest(latestSets);


                        var dots = dailyPrices.DotsOfBuyingOrSelling(filter);

                        dots.ForEach(dot =>
                        {
                            dot.SetKeys = dailySets.GetSetKeys(dot.TradeDate);
                        });

                        dotsDic.Add(stock.Code, dots);


                        buyingDotsSets = dailySets?
                            .FindAll(o => dots!=null&& dots.Any(x =>x.IsDotOfBuying&& x.TradeDate == o.MarkTime.ToYmd()))
                            .ToList();

                        sellingDotsSets = dailySets?
                            .FindAll(o => dots != null && dots.Any(x => !x.IsDotOfBuying && x.TradeDate == o.MarkTime.ToYmd()))
                            .ToList();

                        Profiles().ForEach(profile =>
                        {
                            var oneProfileSummary = profile.OutputDailyOperates(dailySets)
                                .SaveFor(stock, profile)
                                .ConvertToRecords()
                                .SaveFor(stock, profile)
                                .RecordsSummary(profile);

                            profileSummaries.MergeSummary(oneProfileSummary);
                        });

                        dailyPrices.CreateCandlestickDiagram(dailyLine!, stock)
                            .SaveFor(stock, StockAnalysisCycle.DAILY);

                        weeklyPrices.CreateCandlestickDiagram(weeklyLine!, stock)
                            .SaveFor(stock, StockAnalysisCycle.WEEKLY);

                        monthlyPrices.CreateCandlestickDiagram(monthlyLine!, stock)
                            .SaveFor(stock, StockAnalysisCycle.MONTHLY);
                    }
                },
                Config.MaxParallelTasks)
        ).ExecuteAndTiming($"everyOne");

        dotsDic.SaveFor(filter);
        latestSets.SaveEntities("latest");
        latestSets.GenerateList().Save();
        profileSummaries.Save();

        var allDots = dotsDic
            .Select(o => o.Value)
            .UnionAll()
            .ToList();

        allDots.Where(o => o.IsDotOfBuying)
                      .Select(o => o.SetKeys)
              .MergeToDictionary()
                      .CreateTreemapDiagram("Dots Of Buying Treemap")
                      .SaveFor($"{filter.Identity}.Treemap.Buying");

        allDots.Where(o => !o.IsDotOfBuying)
                .Select(o => o.SetKeys).MergeToDictionary()
                .CreateTreemapDiagram("Dots Of Selling Treemap")
                .SaveFor($"{filter.Identity}.Treemap.Selling");
     

            buyingDotsSets.CreateSankeyDiagram("Dots Of Buying Sankey")
                .SaveFor($"{filter.Identity}.Sankey.Buying");

            sellingDotsSets.CreateSankeyDiagram("Dots Of Selling Sankey")
                .SaveFor($"{filter.Identity}.Sankey.Selling");
        
    }
    
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
    
    #endregion
    
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Signalert));
}