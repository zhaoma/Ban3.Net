using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Extensions;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Enums;

namespace Ban3.Productions.Casino.CcaAndReport;

public partial class Signalert
{
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

    public static string LoadDiagramContent(Stock stock, StockAnalysisCycle cycle = StockAnalysisCycle.DAILY)
        => $"{stock.Code}.{cycle}"
            .DataFile<Diagram>()
        .ReadFile();

    #endregion

    #region 生成/加载个股特征

    public static void PrepareAllSets(List<Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();

        var aggregated = new List<StockSets>();

        allCodes.ParallelExecute((stock) =>
        {
            if (Calculator.PrepareSets(stock, out var ones))
            {
                aggregated.AppendToList(ones.Last());
            }
        }, Config.MaxParallelTasks);

        $"latest"
            .DataFile<StockSets>()
            .WriteFile(aggregated.ObjToJson());
    }

    #endregion

    #region 生成/加载排名列表

    public static bool PrepareLatestList()
        => Calculator.LoadAllLatestSets().GenerateList(DateTime.Now.ToYmd());

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