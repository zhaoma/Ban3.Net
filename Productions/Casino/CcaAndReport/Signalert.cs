using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.CcaAndReport.Models;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Sites.ViaTushare.Entries;
using log4net;
using Stock = Ban3.Infrastructures.Indicators.Entries.Stock;

#nullable enable

namespace Ban3.Productions.Casino.CcaAndReport;

/// <summary>
/// 
/// </summary>
[TracingIt]
public partial class Signalert
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Signalert));

    public static ICollector Collector = new Collector();

    public static ICalculator Calculator = new Calculator();

    public static IAnalyzer Analyzer = new Analyzer();

    public static IReportor Reportor = new Reportor();


    public static List<Contracts.Entities.Stock> TargetCodes()
        => Collector.LoadAllCodes().Where(o => o.Code.EndsWith(".SH") || o.Code.EndsWith(".SZ")).ToList();

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

    /// <summary>
    /// 日常任务
    /// 无参数，全市场
    /// </summary>
    public static void ExecuteDailyJob()
    {
        var allCodes = TargetCodes();

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
        var total = stocks.Count;
        var current = 0;

        new Action(() =>
            stocks.ParallelExecute(one =>
                {
                    try
                    {
                        var now = DateTime.Now;
                        var stock = new Stock
                        { Code = one.Code, ListDate = one.ListDate, Name = one.Name, Symbol = one.Symbol };

                        var dailyPrices = Calculator.LoadPricesForIndicators(stock.Code, StockAnalysisCycle.DAILY);

                        if (ParseOne(stock, dailyPrices, null, out var dailySets))
                        {
                            var dots = dailyPrices.DotsOfBuyingOrSelling(filter);

                            if (dots != null)
                            {
                                dots.ForEach(dot => { dot.SetKeys = dailySets.GetSetKeys(dot.TradeDate); });
                                dotsDic.Add(stock.Code, dots);
                            }

                            if (dailySets != null)
                            {
                                dailySets.PushLatest(latestSets);

                                buyingDotsSets.AppendDistinct(
                                    dailySets
                                        .FindAll(o =>
                                            dots != null && dots.Any(x => x.IsDotOfBuying && x.TradeDate == o.MarkTime.ToYmd())));

                                sellingDotsSets.AppendDistinct(
                                    dailySets
                                        .FindAll(o =>
                                            dots != null && dots.Any(x => x.IsDotOfBuying && x.TradeDate == o.MarkTime.ToYmd())));
                            }

                            Profiles().ForEach(profile =>
                            {
                                var oneProfileSummary = profile.OutputDailyOperates(dailySets)
                                    .SaveFor(stock, profile)
                                    .ConvertToRecords()
                                    .SaveFor(stock, profile)
                                    .RecordsSummary(profile);

                                profileSummaries.MergeSummary(oneProfileSummary);
                            });
                        }

                        current++;
                        Logger.Debug(
                            $"parse {current}/{total} : {one.Code} over,{DateTime.Now.Subtract(now).TotalMilliseconds} ms elapsed.");
                    }
                    catch (Exception ex)
                    {
                        Logger.Error($"fault when parse {one.Code}");
                        Logger.Error(ex);
                    }
                },
                Config.MaxParallelTasks)
        ).ExecuteAndTiming($"Stocks Completed,Next is summaries.");

        dotsDic.SaveFor(filter);
        latestSets.SaveEntities("latest").GenerateList().Save();
        profileSummaries.Save();

        var allDots = dotsDic
            .Select(o => o.Value)
            .UnionAll()
            .ToList();

        allDots.Where(o => o.IsDotOfBuying)
            .Select(o => o.SetKeys)!
            .MergeToDictionary()
            .CreateTreemapDiagram("Dots Of Buying Treemap")
            .SaveFor($"{filter.Identity}.Treemap.Buying");

        allDots.Where(o => !o.IsDotOfBuying)
            .Select(o => o.SetKeys)!
            .MergeToDictionary()
            .CreateTreemapDiagram("Dots Of Selling Treemap")
            .SaveFor($"{filter.Identity}.Treemap.Selling");

        buyingDotsSets.CreateSankeyDiagram("Dots Of Buying Sankey")
            .SaveFor($"{filter.Identity}.Sankey.Buying");

        sellingDotsSets.CreateSankeyDiagram("Dots Of Selling Sankey")
            .SaveFor($"{filter.Identity}.Sankey.Selling");

        Profiles().ForEach(profile =>
        {
            PrepareCompositeRecords(stocks.Select(o => o.Code).ToList(), profile.Identity);
        });

        GenerateTimelineRecords();
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

    public static List<DotInfo>? GetDots(RenderView request)
    {
        return Reportor
        .LoadDots(Infrastructures.Indicators.Helper.DefaultFilter)
        .ExtendedDots(request);
    }

    public static Dictionary<string, int>? GetDotsKey(bool forBuying)
        => Reportor.LoadDotsKey(Infrastructures.Indicators.Helper.DefaultFilter, forBuying);

    public static LineOfPoint? GetLineOfPoint(RenderView request)
        => new Stock { Code = request.Id }.LoadLineOfPoint(
            request.CycleEnum()
            );

    public static List<ListRecord>? GetListRecords(string listName = "latest")
        => Config.CacheKey<ListRecord>(listName)
            .LoadOrSetDefault<List<ListRecord>>(listName.DataFile<ListRecord>());

    public static List<StockPrice> GetStockPrices(RenderView request)
        => Calculator.LoadReinstatedPrices(request.Id, request.CycleEnum());

    public static List<StockSets>? GetStockSets(RenderView request)
        => new Stock { Code = request.Id }.LoadStockSets();

    public static List<StockSets>? GetLatestStockSets()
        => Config.CacheKey<StockSets>("latest")
            .LoadOrSetDefault<List<StockSets>>("latest".DataFile<StockSets>());

    public static string UnsellRecord(StockOperationRecord r, out double c)
    {
        var l = GetLatestStockSets()?.FindLast(o => o.Code == r.Code);
        if (l != null)
        {
            c = l.Close;
            return $"{l.Close} : {Math.Round((l.Close - r.BuyPrice) / r.BuyPrice * 100D, 2)} %";
        }

        c = 0;
        return string.Empty;
    }

    public static string GetTreemapDiagram(int id = 1)
    {
        var diagramName = id == 1
            ? $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Treemap.Buying"
            : $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Treemap.Selling";

        var diagram = diagramName.LoadDiagram();

        return diagram.ObjToJson();
    }

    public static string GetSankeyDiagram(int id = 1)
    {
        var diagramName = id == 1
            ? $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Sankey.Buying"
            : $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Sankey.Selling";

        var diagram = diagramName.LoadDiagram();

        return diagram.ObjToJson();
    }

    public static string GetCandlestickDiagram(string code, string cycle = "DAILY")
    {
        cycle = cycle.ToUpper();

        var cycleEnum = cycle.StringToEnum<StockAnalysisCycle>();

        return new Stock { Code = code, }.LoadDiagram(cycleEnum).ObjToJson();
    }

    public static string GetAmountDiagram(string code)
        => $"{code}.Amount".LoadDiagram().ObjToJson();

    public static string GetBiasDiagram(string code)
        => code.BiasDiagram().ObjToJson();

    public static string GetDmiDiagram(string code)
        => code.DmiDiagram().ObjToJson();

    public static string GetKdDiagram(string code)
        => code.KdDiagram().ObjToJson();

    public static string GetMacdDiagram(string code)
        => code.MacdDiagram().ObjToJson();

    public static List<StockOperationRecord> GetProfileDetails(List<string> codes, string profileId)
        => Analyzer.LoadProfileDetails(codes, profileId);

    public static Models.CompositeRecords PrepareCompositeRecords(List<string> codes, string profileId)
    {
        var result = new Models.CompositeRecords
        {
            Profile = Profiles().Last(o => o.Identity == profileId),
            Records = GetProfileDetails(codes, profileId)
        };

        var rightSets = new List<List<string>>();
        var wrongSets = new List<List<string>>();

        result.Records.ForEach(r =>
        {
            if (r.SellDate != null)
            {
                var sets = GetStockSets(new RenderView { Id = r.Code })
                    .GetSetKeys(r.BuyDate.ToYmd());
		    //.Except(result.Profile.BuyingCondition.);

                if (sets != null)
                {
                    if (r.SellPrice > r.BuyPrice)
                    {
                        rightSets.Add(sets);
                    }
                    else
                    {
                        wrongSets.Add(sets);
                    }
                }
            }
        });

        result.RightKeys = rightSets.MergeToDictionary();
        result.WrongKeys = wrongSets.MergeToDictionary();

        result.SaveEntity(_ => profileId);

        return result;
    }

    public static Models.CompositeRecords? LoadCompositeRecords(string profileId)
        => profileId.LoadEntity<Models.CompositeRecords>();

    private static object _lock = new();

    public static List<TimelineRecord>? GetTimelineRecords()
        => "all".LoadEntities<TimelineRecord>();

    public static Dictionary<DistributeCondition, MultiResult<TimelineRecord>> DistributeRecords()
    {


    }

}