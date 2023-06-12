using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Interfaces;
using log4net;

namespace Ban3.Productions.Casino.CcaAndReport;

[TracingIt]
public class Signalert
{
    static readonly ILog Logger = LogManager.GetLogger(typeof(Signalert));

    public static ICollector Collector = new Collector();

    public static ICalculator Calculator = new Calculator();

    public static IAnalyzer Analyzer = new Analyzer();

    public static IReportor Reportor = new Reportor();

    #region 批量作业

    public static void ExecuteFullyJob(bool reCalculateSeeds=false)
    {
        Collector.PrepareAllCodes();

        var allCodes = Collector.LoadAllCodes();
        
        new Action(() => Collector.PrepareDailyPrices(allCodes)).ExecuteAndTiming("PrepareDailyPrices");

        if(reCalculateSeeds)
            PrepareEventsAndSeeds(allCodes);

        new Action(() => ReinstateAllPrices(allCodes)).ExecuteAndTiming("ReinstateAllPrices");

        ExecutePrepare(allCodes);
    }

    public static void ExecuteDailyJob()
    {
        var allCodes = Collector.LoadAllCodes();

        new Action(() => Collector.FixDailyPrices(allCodes)).ExecuteAndTiming("FixDailyPrices");

        new Action(() => ReinstateAllPrices(allCodes)).ExecuteAndTiming("ReinstateAllPrices");

        ExecutePrepare(allCodes);
    }

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
            .Where(x=>cs.Contains(x.Code))
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

    static void ExecutePrepare(List<Stock> stocks)
    {
        new Action(() =>
            stocks.ParallelExecute((stock) => { Calculator.GenerateIndicatorLine(stock.Code); },
                Config.MaxParallelTasks)
        ).ExecuteAndTiming("GenerateIndicatorLine");

        new Action(() =>
            PrepareAllDiagrams(stocks)
        ).ExecuteAndTiming("PrepareAllDiagrams");

        new Action(() =>
            PrepareAllSets(stocks)
        ).ExecuteAndTiming("PrepareAllSets");

        new Action(() =>
            PrepareLatestList()
        ).ExecuteAndTiming("PrepareLatestList");

        new Action(() =>
            stocks.ParallelExecute((stock) =>
            {
                var sets = Calculator.LoadSets(stock.Code);
                
                Infrastructures.Indicators.Helper.Profiles
                    .Where(o => o.Persistence)
                    .ParallelExecute((profile) =>
                        {
                            profile
                                .OutputDailyOperates(sets, stock.Code)
                                .ConvertOperates2Records(profile,stock.Code);
                        },
                        Config.MaxParallelTasks);
            }, Config.MaxParallelTasks)
        ).ExecuteAndTiming("OutputDailyOperates");
    }

    #endregion

    #region 计算复权因子并重新计算行情

    public static void PrepareEventsAndSeeds(List<Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();
        Collector.PrepareAllEvents(allCodes);
        PrepareAllSeeds(allCodes);
    }

    public static bool PrepareAllSeeds(List<Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();
        var result = true;

        allCodes.ParallelExecute((stock) => { result = result && PrepareSeeds(stock); },
            Config.MaxParallelTasks);

        return result;
    }

    public static bool PrepareSeeds(Stock stock)
    {
        var prices = Collector.LoadDailyPrices(stock.Code);
        var events = Collector.LoadOnesEvents(stock.Symbol);

        var seeds = Calculator.CalculateSeeds(prices, events);
        var saved = seeds.SetsFile(stock.Symbol)
            .WriteFile(seeds.ObjToJson());

        return !string.IsNullOrEmpty(saved);
    }

    public static bool ReinstateAllPrices(List<Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();
        var result = true;

        allCodes.ParallelExecute((stock) =>
            {
                try
                {
                    var ps = Collector.LoadDailyPrices(stock.Code);

                    var reinstateOne = Calculator.ReinstatePrices(stock.Code, stock.Symbol, ps);

                    result = result && reinstateOne;
                }
                catch (Exception ex)
                {
                    Logger.Error(stock.Code);
                    Logger.Error(ex);
                }
            },
            Config.MaxParallelTasks);

        return result;
    }

    #endregion

    #region 生成/加载个股图表

    public static void PrepareAllDiagrams(List<Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();

        allCodes.ParallelExecute((stock) => { PrepareOnesDiagram(stock); }, Config.MaxParallelTasks);
    }

    public static bool PrepareOnesDiagram(Stock stock)
        => PrepareDiagram(stock)
           && PrepareDiagram(stock, StockAnalysisCycle.WEEKLY)
           && PrepareDiagram(stock, StockAnalysisCycle.MONTHLY);

    public static bool PrepareDiagram(Stock stock, StockAnalysisCycle cycle = StockAnalysisCycle.DAILY)
    {
        try
        {
            var prices = Calculator.LoadReinstatedPrices(stock.Code, cycle);

            if (prices == null || !prices.Any()) return false;

            var indicatorValue = Calculator.LoadIndicatorLine(stock.Code, cycle);

            var diagram = Reportor.CreateOnesCandlestickDiagram(stock, prices, indicatorValue);

            var saved = $"{stock.Code}.{cycle}"
                .DataFile<Diagram>()
                .WriteFile(diagram.ObjToJson());

            return !string.IsNullOrEmpty(saved);
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }

    public static Diagram LoadDiagram(Stock stock, StockAnalysisCycle cycle = StockAnalysisCycle.DAILY)
        => $"{stock.Code}.{cycle}"
            .DataFile<Diagram>()
            .ReadFileAs<Diagram>();

    #endregion

    #region 生成/加载个股特征
    
    public static void PrepareAllSets(List<Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();

        var aggregated = new List<StockSets>();

        allCodes.ParallelExecute((stock) =>
        {
            if (Calculator.PrepareSets(stock,out var ones))
            {
                aggregated.AppendToList(ones.Last());
            }
        }, Config.MaxParallelTasks);

        $"latest"
            .DataFile<StockSets>()
            .WriteFile(aggregated.ObjToJson());
    }

    public static List<StockSets> LoadAllSets()
        => $"latest"
            .DataFile<StockSets>()
            .ReadFileAs<List<StockSets>>();

    #endregion

    #region 生成/加载排名列表

    public static bool PrepareLatestList()
        => LoadAllSets().GenerateList(DateTime.Now.ToYmd());

    public static bool LoadOneDaysList(DateTime? day, out List<ListRecord> records)
    {
        var saved = (day ?? DateTime.Now)
            .ToYmd()
            .DataFile<ListRecord>();

        if (!File.Exists(saved))
        {
            records = null;
            return false;
        }

        records = saved.ReadFileAs<List<ListRecord>>();
        return true;
    }

    #endregion
    
}