using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.CcaAndReport.Implements;
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
public class Signalert
{
    private static readonly ILog Logger = LogManager.GetLogger(typeof(Signalert));

    /// 
    public static ICollector Collector = new Collector();

    /// 
    public static ICalculator Calculator = new Calculator();

    /// 
    public static IAnalyzer Analyzer = new Analyzer();

    /// 
    public static IReportor Reportor = new Reportor();

    /// <summary>
    /// 关注标的池
    /// </summary>
    /// <returns></returns>
    public static List<Contracts.Entities.Stock> TargetCodes()
        => Collector.LoadAllCodes().Where(o => o.Code.EndsWith(".SH") || o.Code.EndsWith(".SZ")).ToList();

    #region 复权

    /// <summary>
    /// 下载事件，计算复权价格
    /// </summary>
    /// <param name="allCodes"></param>
    public static void PrepareEventsAndSeeds(List<Contracts.Entities.Stock>? allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();
        Collector.PrepareAllEvents(allCodes);

        ReinstateAllPrices(allCodes);
    }

    /// <summary>
    /// 计算复权价格
    /// </summary>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool ReinstateAllPrices(List<Contracts.Entities.Stock>? allCodes = null)
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

        new Action(() => Calculator.GenerateBasisData(stocks)).ExecuteAndTiming("GenerateBasisData");

        new Action(() =>
        {
            Config.Profiles().ForEach(profile =>
            {
                Analyzer.PrepareCompositeRecords(stocks.Select(o => o.Code).ToList(), profile.Identity);
            });
        }).ExecuteAndTiming("PrepareCompositeRecords");

        new Action(() => Calculator.GenerateAmountDiagrams(stocks))
            .ExecuteAndTiming("GenerateAmountDiagrams");

        new Action(() =>
        {
            Analyzer.PrepareDistributeRecords();
        }).ExecuteAndTiming("PrepareDistributeRecords");

        new Action(() =>
        {
            Calculator.GenerateTargets(stocks);
        }).ExecuteAndTiming("GenerateTargets");
    }

    /// 
    public static List<DotInfo> GetDots(RenderView request)
    {
        return Reportor
            .LoadDots(Infrastructures.Indicators.Helper.DefaultFilter)
            .ExtendedDots(request);
    }

    /// 
    public static Dictionary<string, int> GetDotsKey(bool forBuying)
        => Reportor.LoadDotsKey(Infrastructures.Indicators.Helper.DefaultFilter, forBuying);

    /// 
    public static LineOfPoint? GetLineOfPoint(RenderView request)
        => new Stock { Code = request.Id }.LoadLineOfPoint(
            request.CycleEnum()
        );

    /// 
    public static List<ListRecord>? GetListRecords(string listName = "latest")
        => Config.CacheKey<ListRecord>(listName)
            .LoadOrSetDefault<List<ListRecord>>(typeof(ListRecord).LocalFile());

    /// 
    public static List<StockPrice>? GetStockPrices(RenderView request)
        => Calculator.LoadReinstatedPrices(request.Id, request.CycleEnum());

    /// 
    public static List<StockSets>? GetStockSets(RenderView request)
        => new Stock { Code = request.Id }.LoadStockSets();

    /// 
    public static List<StockSets>? GetLatestStockSets()
        => Config.CacheKey<StockSets>("latest")
            .LoadOrSetDefault<List<StockSets>>("latest".DataFile<StockSets>());

    /// 
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

    /// 
    public static string GetTreemapDiagram(int id = 1)
    {
        var diagramName = id == 1
            ? $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Treemap.Buying"
            : $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Treemap.Selling";

        var diagram = diagramName.LoadDiagram();

        return diagram.ObjToJson();
    }

    /// 
    public static string GetSankeyDiagram(int id = 1)
    {
        var diagramName = id == 1
            ? $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Sankey.Buying"
            : $"{Infrastructures.Indicators.Helper.DefaultFilter.Identity}.Sankey.Selling";

        var diagram = diagramName.LoadDiagram();

        return diagram.ObjToJson();
    }

    /// 
    public static string GetCandlestickDiagram(string code, string cycle = "DAILY")
    {
        cycle = cycle.ToUpper();

        var cycleEnum = cycle.StringToEnum<StockAnalysisCycle>();

        return new Stock { Code = code, }.LoadDiagram(cycleEnum).ObjToJson();
    }

    /// 
    public static string GetAmountDiagram(string code)
        => $"{code}.Amount".LoadDiagram().ObjToJson();

    /// 
    public static string GetBiasDiagram(string code)
        => code.BiasDiagram().ObjToJson();

    /// 
    public static string GetDmiDiagram(string code)
        => code.DmiDiagram().ObjToJson();

    /// 
    public static string GetKdDiagram(string code)
        => code.KdDiagram().ObjToJson();

    /// 
    public static string GetMacdDiagram(string code)
        => code.MacdDiagram().ObjToJson();

    /// 
    public static List<StockOperationRecord>? GetProfileDetails(List<string> codes, string profileId)
    {
        try
        {
            return Analyzer.LoadProfileDetails(codes, profileId);
        } catch (Exception e) { Logger.Error(e); }

        return null;
    }

    /// 
    public static Contracts.Entities.CompositeRecords? GetCompositeRecords(string profileId)
        => profileId.LoadEntity<Contracts.Entities.CompositeRecords>();

    /// 
    public static List<Contracts.Entities.TimelineRecord>? GetTimelineRecords()
        => "all".LoadEntities<Contracts.Entities.TimelineRecord>();

    /// 
    public static Dictionary<Contracts.Entities.DistributeCondition, MultiResult<Contracts.Entities.TimelineRecord>>?
        GetDistributeRecords()
        => Reportor.LoadDistributeRecords();
}