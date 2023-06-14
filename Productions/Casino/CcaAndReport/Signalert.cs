using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
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

    public static void ExecuteDailyJob()
    {
        var allCodes = Collector.LoadAllCodes();

        ExecuteDailyJob(allCodes);
    }

    public static void ExecuteDailyJob(string codes)
    {
        var cs = codes.Split(',');
        var allCodes = Collector.LoadAllCodes()
            .Where(x => cs.Contains(x.Code))
            .ToList();

        ExecuteDailyJob(allCodes);
    }

    public static void ExecuteDailyJob(List<Stock> stocks)
    {
        new Action(() => Collector.FixDailyPrices(stocks)).ExecuteAndTiming("FixDailyPrices");

        ExecutePrepare(stocks);
    }

    #endregion

    #region 实时任务

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

    #endregion

    /// <summary>
    /// 计算复权价格
    /// 计算指标值
    /// 准备指标图表数据
    /// 准备指标特征数据
    /// 生成最新列表
    /// 生成个股操作建议
    /// 生成个股操作纪录
    /// </summary>
    /// <param name="stocks"></param>
    static void ExecutePrepare(List<Stock> stocks)
    {
        new Action(() => ReinstateAllPrices(stocks)).ExecuteAndTiming("ReinstateAllPrices");

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
                            Analyzer
                                .OutputDailyOperates(profile,sets, stock.Code)
                                .ConvertOperates2Records(profile, stock.Code);
                        },
                        Config.MaxParallelTasks);
            }, Config.MaxParallelTasks)
        ).ExecuteAndTiming("OutputDailyOperates");
    }

    #endregion

    private static readonly ILog Logger = LogManager.GetLogger(typeof(Signalert));
}