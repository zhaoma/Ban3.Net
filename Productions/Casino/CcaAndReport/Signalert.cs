using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Interfaces;

namespace Ban3.Productions.Casino.CcaAndReport;

[TracingIt]
public class Signalert
{
    public static ICollector Collector  = new Collector();

    public static ICalculator Calculator = new Calculator();

    public static IAnalyzer Analyzer = new Analyzer();

    public static IReportor Reportor = new Reportor();

    public static bool PrepareSeeds(Stock stock)
    {
        var prices = Collector.LoadDailyPrices(stock.Code);
        var events = Collector.LoadOnesEvents(stock.Symbol);

        var seeds = Calculator.CalculateSeeds(prices, events);
        var saved=seeds.SetsFile(stock.Symbol)
            .WriteFile(seeds.ObjToJson());

        return !string.IsNullOrEmpty(saved);
    }

    public static async Task<bool> PrepareAllSeeds(List<Stock> allCodes = null)
    {
        allCodes ??= Signalert.Collector.LoadAllCodes();
        var result = true;

        await allCodes.ParallelExecuteAsync((stock) => { result = result && PrepareSeeds(stock); },
            Config.MaxParallelTasks);

        return result;
    }

    public static async Task<bool> ReinstateAllPrices(List<Stock> allCodes = null)
    {
        allCodes ??= Signalert.Collector.LoadAllCodes();
        var result = true;

        await allCodes.ParallelExecuteAsync((stock) =>
            {
                var ps = Collector.LoadDailyPrices(stock.Code);
                
                result = result && Calculator.ReinstatePrices(stock.Code, stock.Symbol, ps);
            },
            Config.MaxParallelTasks);

        return result;
    }

    public static async Task ExecuteDailyJob()
    {
        Collector.PrepareAllCodes();

        var allCodes = Signalert.Collector.LoadAllCodes();

        Collector.FixDailyPrices(allCodes);

        var reinstate = await Signalert.ReinstateAllPrices(allCodes);

        if (reinstate)
        {
            await allCodes.ParallelExecuteAsync((stock) => { Calculator.GenerateIndicatorLine(stock.Code); },
                Config.MaxParallelTasks);


            await PrepareAllDiagrams(allCodes);

            await PrepareAllSets(allCodes);
        }
    }

    public static async Task ExecuteRealtimeJob()
    {
        var allCodes = Signalert.Collector.LoadAllCodes();

        await ExecuteRealtimeJob(allCodes);
    }

    public static async Task ExecuteRealtimeJob(List<Stock> stocks)
    {
        Collector.ReadRealtime(stocks);

        await PrepareAllDiagrams(stocks);

        await PrepareAllSets(stocks);
    }

    public static async Task PrepareAllDiagrams(List<Stock> allCodes=null)
    {
        allCodes ??= Signalert.Collector.LoadAllCodes();

        await allCodes.ParallelExecuteAsync((stock) =>
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
        var prices = Calculator.LoadReinstatedPrices(stock.Code, cycle);
        
        if (prices == null || !prices.Any()) return false;

        var indicatorValue=Calculator.LoadIndicatorLine(stock.Code, cycle);

        var diagram= Reportor.CreateOnesDiagram(stock, prices, indicatorValue);

        var saved =$"{stock.Code}.{cycle}" 
            .DataFile<Diagram>()
            .WriteFile(diagram.ObjToJson());

        return !string.IsNullOrEmpty(saved);
    }

    public static Diagram LoadDiagram(Stock stock, StockAnalysisCycle cycle = StockAnalysisCycle.DAILY)
        => $"{stock.Code}.{cycle}"
            .DataFile<Diagram>()
            .ReadFileAs<Diagram>();

    public static async  Task PrepareAllSets(List<Stock> allCodes = null)
    {
        allCodes ??= Signalert.Collector.LoadAllCodes();

        await allCodes.ParallelExecuteAsync((stock) =>
        {
            PrepareOnesDiagram(stock);
        }, Config.MaxParallelTasks);
    }

    public static List<StockSets> PrepareOnesSets(Stock stock)
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
}