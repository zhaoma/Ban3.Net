using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Formulas;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Productions.Casino.Contracts.Models;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Sites.ViaTushare.Entries;
using Stock = Ban3.Productions.Casino.Contracts.Entities.Stock;

#nullable enable
namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// ICollector 扩展方法，计算相关
/// </summary>
public static partial class Helper
{
    #region 计算/加载复权因子

    /// <summary>
    /// 计算复权因子
    /// </summary>
    /// <param name="_"></param>
    /// <param name="prices"></param>
    /// <param name="events"></param>
    /// <returns></returns>
    public static List<StockSeed> CalculateSeeds(this ICalculator _, List<StockPrice> prices, List<StockEvent> events)
    {
        var result = new List<StockSeed>();
        try
        {
            if (events.Any())
            {
                foreach (var e in events)
                {
                    var price = prices.Last(o => o.TradeDate.ToDateTimeEx() < e.MarkTime);
                    {
                        var close = (decimal)price.Close;

                        var thisSeed =
                            Math.Round(
                                close * (1 + (Math.Round(e.Sbonus, 0) + Math.Round(e.Zbonus, 0)) / 10M +
                                         Math.Round(e.Pbonus, 0) / 10M) / (close - e.Xmoney / 10M +
                                                                           Math.Round(e.Pbonus, 0) / 10M *
                                                                           Math.Round(e.Pprice, 2)), 4);

                        result.Add(new StockSeed { MarkTime = e.MarkTime, Seed = (float)thisSeed });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return result;
    }
    
    #endregion

    #region 计算/加载复权价格

    /// <summary>
    /// 计算复权价格
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <param name="symbol"></param>
    /// <param name="prices"></param>
    /// <returns></returns>
    public static bool ReinstatePrices(
        this ICalculator _,
        string code,
        string symbol,
        List<StockPrice>? prices)
    {
        if (prices == null || !prices.Any()) return false;

        try
        {
            var seeds = symbol.LoadEntities<StockSeed>();

            prices.Select(seeds!.ReinstateOnePrice)
                .ToList()
                .SaveEntities($"{code}.{StockAnalysisCycle.DAILY}");
            
            return true;
        }
        catch (Exception ex)
        {
            Logger.Error($"ReinstatePrices {code}");
            Logger.Error(ex);
        }

        return false;
    }

    static StockPrice ReinstateOnePrice(this List<StockSeed>? seeds, StockPrice price)
    {
        var newPrice = new StockPrice
        {
            Code = price.Code,
            TradeDate = price.TradeDate,
            Change = price.Change,
            ChangePercent = price.ChangePercent,
            Vol = price.Vol,
            Amount = price.Amount,

            Open = price.Open,
            High = price.High,
            Low = price.Low,
            Close = price.Close,
            PreClose = price.PreClose
        };

        try
        {
            if (seeds != null && seeds.Any())
            {
                foreach (var s in seeds)
                {
                    if (s.MarkTime.Subtract(price.TradeDate.ToDateTimeEx()).TotalDays > 0)
                    {
                        newPrice.Open = (float)Math.Round(price.Open / s.Seed, 2);
                        newPrice.High = (float)Math.Round(price.High / s.Seed, 2);
                        newPrice.Low = (float)Math.Round(price.Low / s.Seed, 2);
                        newPrice.Close = (float)Math.Round(price.Close / s.Seed, 2);
                        newPrice.PreClose = (float)Math.Round(price.PreClose / s.Seed, 2);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return newPrice;
    }

    /// <summary>
    /// 加载复权价格
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public static List<StockPrice>? LoadReinstatedPrices(this ICalculator _, string code, StockAnalysisCycle cycle)
        => $"{code}.{cycle}".LoadEntities<StockPrice>();

    /// <summary>
    /// 加载复权价格(用于指标计算)
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public static List<Price>? LoadPricesForIndicators(this ICalculator _, string code, StockAnalysisCycle cycle)
        => $"{code}.{cycle}".DataFile<StockPrice>().ReadFileAs<List<Price>>();

    #endregion
    
    /// <summary>
    /// 对dots of buying or selling main table按照RenderView筛选
    /// </summary>
    /// <param name="dots"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static List<DotInfo> ExtendedDots(
        this Dictionary<string, List<DotInfo>> dots,
        RenderView? request)
    {
        var result = new List<DotInfo>();

        foreach (var keyValuePair in dots)
        {
            keyValuePair.Value.ForEach(o => o.Code = keyValuePair.Key);
            result.AddRange(keyValuePair.Value);
        }

        if (request != null)
        {
            result = result
                .Where(o =>DotFilter(o,request))
                .OrderByDescending(o => o.TradeDate)
                .ThenByDescending(o => o.Code)
                .ToList();
        }

        return result;
    }
    
    /// <summary>
    /// Latest Sets
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public static List<StockSets> LoadAllLatestSets(this ICalculator _)
    {
        var file = $"latest".DataFile<StockSets>();

        return Config.CacheKey<StockSets>("latest")
            .LoadOrSetDefault<List<StockSets>>(file);
    }

    /// <summary>
    /// 筛选
    /// </summary>
    /// <param name="_"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static List<StockSets> ScopedByRenderView(
        this ICalculator _,
        RenderView? request)
    {
        var targets= _.LoadAllLatestSets();
        if (request != null)
        {
            if (!string.IsNullOrEmpty(request.IncludeKeys) || !string.IsNullOrEmpty(request.ExcludeKeys))
            {
                if (!string.IsNullOrEmpty(request.IncludeKeys))
                {
                    targets = targets.Where(o => o.SetKeys.AllFoundIn(request.IncludeKeys.Split(','))).ToList();
                }

                if (!string.IsNullOrEmpty(request.ExcludeKeys))
                {
                    targets = targets.Where(o => o.SetKeys.NotFoundIn(request.ExcludeKeys.Split(','))).ToList();
                }
            }

            targets = targets
                .Where(o => StrFilter(o.Code,request))
                .OrderByDescending(o => o.Code)
                .ThenByDescending(o => o.MarkTime)
                .ToList();
        }

        return targets;
    }

    /// <summary>
    /// 准备基础数据
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stocks"></param>
    /// <returns></returns>
    public static bool GenerateBasisData(this ICalculator _, List<Entities.Stock> stocks)
    {
        try
        {
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
                            //Logger.Debug($"GenerateBasisData:[{one.Code}]");
                            var now = DateTime.Now;

                            var dailyPrices = _.LoadPricesForIndicators(one.Code, StockAnalysisCycle.DAILY);

                            if (_.GenerateOneBasisData(one, dailyPrices, null, out var dailySets))
                            {
                                var dots = dailyPrices.DotsOfBuyingOrSelling(filter);

                                if (dots != null)
                                {
                                    dots.ForEach(dot => { dot.SetKeys = dailySets.GetSetKeys(dot.TradeDate); });
                                    dotsDic.Add(one.Code, dots);
                                }

                                if (dailySets != null)
                                {
                                    dailySets.PushLatest(latestSets);

                                    buyingDotsSets.AppendDistinct(
                                        dailySets
                                            .FindAll(o =>
                                                dots != null && dots.Any(x =>
                                                    x.IsDotOfBuying && x.TradeDate == o.MarkTime.ToYmd())));

                                    sellingDotsSets.AppendDistinct(
                                        dailySets
                                            .FindAll(o =>
                                                dots != null && dots.Any(x =>
                                                    x.IsDotOfBuying && x.TradeDate == o.MarkTime.ToYmd())));
                                }

                                Config.Profiles().ForEach(profile =>
                                {
                                    var oneProfileSummary = profile.OutputDailyOperates(dailySets)
                                        .SaveFor(one, profile)
                                        .ConvertToRecords()
                                        .SaveFor(one, profile)
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

            Logger.Debug("save dotsDic,latestSets,profileSummaries.");

            dotsDic.SaveFor(filter);
            latestSets.SaveEntities("latest").GenerateList().Save();
            profileSummaries.Save();
            
            Logger.Info("save dotsDic,latestSets,profileSummaries success.");

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

            _.GenerateTimelineRecords(stocks);

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    /// <summary>
    /// 准备个股基础数据
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stock"></param>
    /// <param name="prices"></param>
    /// <param name="formulas"></param>
    /// <param name="dailySets"></param>
    /// <returns></returns>
    public static bool GenerateOneBasisData(
        this ICalculator _,
        Infrastructures.Indicators.Entries.Stock stock,
        List<Price>? prices,
        Full? formulas,
        out List<StockSets>? dailySets)
    {
        dailySets = null;
        try
        {
            var dailyPrices = prices
                              ?? _.LoadPricesForIndicators(stock.Code, StockAnalysisCycle.DAILY);

            if (dailyPrices.SplitWeeklyAndMonthly(out var weeklyPrices, out var monthlyPrices))
            {
                weeklyPrices.SaveEntities(stock.FileNameWithCycle(StockAnalysisCycle.WEEKLY));

                monthlyPrices.SaveEntities(stock.FileNameWithCycle(StockAnalysisCycle.MONTHLY));

                var dailyLine = dailyPrices.CalculateIndicators(formulas)
                    .SaveFor(stock, StockAnalysisCycle.DAILY);

                dailySets = dailyLine.LineToSets(stock);

                var weeklyLine = weeklyPrices.CalculateIndicators()
                    .SaveFor(stock, StockAnalysisCycle.WEEKLY);
                var weeklySets = weeklyLine.LineToSets(stock);

                var monthlyLine = monthlyPrices.CalculateIndicators()
                    .SaveFor(stock, StockAnalysisCycle.MONTHLY);
                var monthlySets = monthlyLine.LineToSets(stock);

                dailySets.MergeWeeklyAndMonthly(weeklySets, monthlySets)
                    .SaveFor(stock);

                dailyPrices.CreateCandlestickDiagram(dailyLine!, stock)
                    .SaveFor(stock, StockAnalysisCycle.DAILY);

                weeklyPrices.CreateCandlestickDiagram(weeklyLine!, stock)
                    .SaveFor(stock, StockAnalysisCycle.WEEKLY);

                monthlyPrices.CreateCandlestickDiagram(monthlyLine!, stock)
                    .SaveFor(stock, StockAnalysisCycle.MONTHLY);
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error($"Parser one :{stock.Code} fault.");
            Logger.Error(ex);
        }

        return false;
    }

    /// <summary>
    /// 成交额图表
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stocks"></param>
    /// <param name="days"></param>
    public static void GenerateAmountDiagrams(
        this ICalculator _,
        List<Entities.Stock> stocks,
        int days = 3)
    {
        var total = stocks.Count;
        var current = 0;

        stocks.ParallelExecute(one =>
        {
            var now = DateTime.Now;

            _.GenerateAmountDiagram(one, days);

            current++;
            Logger.Debug(
                $"parse {current}/{total} : {one.Code} over,{DateTime.Now.Subtract(now).TotalMilliseconds} ms elapsed.");
        }, Config.MaxParallelTasks);
    }

    /// <summary>
    /// 单个成交额图表
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stock"></param>
    /// <param name="days"></param>
    public static void GenerateAmountDiagram(
        this ICalculator _,
        Infrastructures.Indicators.Entries.Stock stock, 
        int days = 5)
    {
        var dailyPrices = typeof(StockPrice).LocalFile(stock.Code).ReadFileAs<List<Price>>();

        if (dailyPrices != null && dailyPrices.SplitAmount(days, out var dailyAmounts))
        {
            var fileName = $"{stock.Code}.Amount";
            var line = dailyAmounts.CalculateIndicators()
                .SaveEntity(_ => fileName);

            if (line != null)
            {
                line.LineToSets(stock)
                    .SaveEntities(fileName);

                dailyAmounts.CreateCandlestickDiagram(line, stock)
                    .SaveFor(fileName);
            }
        }
    }

    /// <summary>
    /// MACD时间线
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stocks"></param>
    public static void GenerateTimelineRecords(
        this ICalculator _,
        List<Entities.Stock> stocks)
    {
        var result = new List<TimelineRecord>();

        stocks.ParallelExecute(one =>
        {
            var sets = one.LoadStockSets();
            if (sets != null && sets.Any())
            {
                var tm = new TimelineRecord(sets, out var selected);
                if (selected)
                {
                    lock (_lock)
                    {
                        result.Add(tm);
                    }
                }
            }
        }, Config.MaxParallelTasks);

        Logger.Debug($"TimelineRecords count={result.Count},success");
        result.SaveEntities("all");
    }

    /// <summary>
    /// 生成Decide
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stocks"></param>
    public static void GenerateTargets(
        this ICalculator _,
        List<Stock> stocks)
    {
        var targets = new Models.Targets();

        stocks.ParallelExecute(one =>
        {
            try
            {
                Logger.Debug($"PARSE {one.Code}");
                var prices = typeof(StockPrice).LocalFile(one.Code).ReadFileAs<List<StockPrice>>();
                var sets = one.LoadStockSets();

                if (sets == null || !sets.Any() || prices == null || !prices.Any())
                {
                    Logger.Debug("SKIP NULL");
                    return;
                }

                var points = sets.GetPoints();
                if (points.Any())
                    targets.AppendTarget(one, points, prices!.Last(), sets.Last());
            }
            catch (Exception ex)
            {
                Logger.Error($"ERROR WHEN PARSE {one.Code}:{ex.Message}");
            }
        }, Config.MaxParallelTasks);

        targets.Save();
        Logger.Debug($"GenerateTargets {targets.Data.Count},success");
    }

    static List<TimelinePoint> GetPoints(this List<StockSets> sets)
    {
        var result=new List<TimelinePoint>();

        try
        {
            var latestDaily = sets.Last(o => o.SetKeys != null && o.SetKeys.Contains("MACD.C0.DAILY"));

            if (latestDaily != null)
            {
                var afterC0 = sets.Where(o => o.MarkTime.ToYmd().ToInt() > latestDaily.MarkTime.ToYmd().ToInt())
                    .ToList();

                if (!afterC0.Any() || afterC0.Count > 20)
                {
                    Logger.Debug("SKIP");
                    return result;
                }
                else
                {
                    Logger.Debug($"ADD TARGET {latestDaily.MarkTime}->{afterC0.Count}");
                }
                
                result.Add(new TimelinePoint(latestDaily));

                foreach (var p in afterC0.Select(s => new TimelinePoint(s))
                             .Where(p => result.All(x => x.Subject != p.Subject)))
                {
                    if (p.Subject != "")
                        result.Add(p);
                }
            }
        }catch(Exception ex) {Logger.Error($".FAULT.{ex.Message}"); }

        return result;
    }
}