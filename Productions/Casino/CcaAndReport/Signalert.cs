﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
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

    public static async Task ExecuteFullyJob()
    {
        //Collector.PrepareAllCodes();

        var allCodes = Collector.LoadAllCodes();
        
	Collector.PrepareAllEvents(allCodes);

        Collector.PrepareDailyPrices(allCodes);

        await PrepareAllSeeds(allCodes);

        ReinstateAllPrices(allCodes);

        ExecutePrepare(allCodes);
    }

    public static void ExecuteDailyJob()
    {
        Collector.PrepareAllCodes();

        var allCodes = Collector.LoadAllCodes();

        Console.WriteLine($"targets {allCodes.Count} total.");
        Collector.FixDailyPrices(allCodes);

        ReinstateAllPrices(allCodes);

        ExecutePrepare(allCodes);
    }

    public static void ExecuteRealtimeJob()
    {
        var allCodes = Collector.LoadAllCodes();

        ExecuteRealtimeJob(allCodes);
    }

    /// <summary>
    /// 实时刷新数据
    /// </summary>
    /// <param name="stocks"></param>
    public static void ExecuteRealtimeJob(List<Stock> stocks)
    {
        Collector.ReadRealtime(stocks);

        ExecutePrepare(stocks);
    }

    static void ExecutePrepare(List<Stock> stocks)
    {
        stocks.ParallelExecute((stock) => { Calculator.GenerateIndicatorLine(stock.Code); }, Config.MaxParallelTasks);

        PrepareAllDiagrams(stocks);

        PrepareAllSets(stocks);

        PrepareLatestList();
    }

    #region 计算复权因子并重新计算行情

    public static async Task<bool> PrepareAllSeeds(List<Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();
        var result = true;

        await allCodes.ParallelExecuteAsync((stock) => { result = result && PrepareSeeds(stock); },
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
                var ps = Collector.LoadDailyPrices(stock.Code);

                var reinstateOne = Calculator.ReinstatePrices(stock.Code, stock.Symbol, ps);

                result = result && reinstateOne;
            },
            Config.MaxParallelTasks);

        return result;
    }

    #endregion

    #region 生成/加载个股图表

    public static void PrepareAllDiagrams(List<Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();

        allCodes.ParallelExecute((stock) =>
        {
            PrepareOnesDiagram(stock);
        }, Config.MaxParallelTasks);
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

            var diagram = Reportor.CreateOnesDiagram(stock, prices, indicatorValue);

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

    public static List<StockSets> PrepareOnesSets(Stock stock)
    {
        try
        {
            var prices = Calculator.LoadReinstatedPrices(stock.Code, StockAnalysisCycle.DAILY);

            var sets = Analyzer.PrepareSets(stock, prices);

            sets.Merge(
                Calculator.LoadIndicatorLine(stock.Code, StockAnalysisCycle.DAILY),
                StockAnalysisCycle.DAILY);

            sets.Merge(
                Calculator.LoadIndicatorLine(stock.Code, StockAnalysisCycle.WEEKLY),
                StockAnalysisCycle.WEEKLY);

            sets.Merge(
                Calculator.LoadIndicatorLine(stock.Code, StockAnalysisCycle.MONTHLY),
                StockAnalysisCycle.MONTHLY);

            $"{stock.Code}"
                .DataFile<StockSets>()
                .WriteFile(sets.ObjToJson());

            return sets;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return new List<StockSets>();
    }

    public static void PrepareAllSets(List<Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();

        var aggregated = new List<StockSets>();

        allCodes.ParallelExecute((stock) =>
        {
            var ones = PrepareOnesSets(stock);
            if (ones != null && ones.Any())
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

    public static bool LoadOnedaysList(DateTime? day,out List<ListRecord> records)
    {
        var saved = (day ?? DateTime.Now)
            .ToYmd()
            .DataFile<ListRecord>();

        if (!File.Exists(saved))
        {
            records = null;
            return false;
        }

        records= saved.ReadFileAs<List<ListRecord>>();
        return true;
    }

    #endregion
}