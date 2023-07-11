using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Extensions;
using System.Collections.Generic;
using System;
using Ban3.Productions.Casino.Contracts;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;

namespace Ban3.Productions.Casino.CcaAndReport;

public partial class Signalert
{
    /// <summary>
    /// 下载事件，计算复权价格
    /// </summary>
    /// <param name="allCodes"></param>
    public static void PrepareEventsAndSeeds(List<Contracts.Entities.Stock> allCodes = null)
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
    public static bool ReinstateAllPrices(List<Contracts.Entities.Stock> allCodes = null)
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

    public static void CreateAmountDiagrams(int days=3)
    {
        var stocks = Collector.ScopedCodes();

        var total = stocks.Count;
        var current = 0;

        stocks.ParallelExecute(one =>
        {
            var now = DateTime.Now;
            var stock = new Stock
                { Code = one.Code, ListDate = one.ListDate, Name = one.Name, Symbol = one.Symbol };

            CreateAmountDiagram(stock, days);

            current++;
            Logger.Debug(
                $"parse {current}/{total} : {one.Code} over,{DateTime.Now.Subtract(now).TotalMilliseconds} ms elapsed.");
        }, Config.MaxParallelTasks);
    }

    /// <summary>
    /// 评估策略，生成汇总
    /// </summary>
    public static void EvaluateProfiles()
    {
        var stocks = Collector.ScopedCodes();
        var profiles = Profiles();

        var total = stocks.Count;
        var current = 0;
        var profileSummaries = new Dictionary<string, ProfileSummary>();

        stocks.ParallelExecute(one =>
        {
            var now = DateTime.Now;
            var stock = new Stock
                { Code = one.Code, ListDate = one.ListDate, Name = one.Name, Symbol = one.Symbol };

            var dailySets = stock.LoadStockSets();

            profiles.ForEach(profile =>
            {
                var oneProfileSummary = profile.OutputDailyOperates(dailySets)
                    .SaveFor(one, profile)
                    .ConvertToRecords()
                    .SaveFor(stock, profile)
                    .RecordsSummary(profile);

                profileSummaries.MergeSummary(oneProfileSummary);
            });
            current++;
            Logger.Debug(
                $"parse {current}/{total} : {one.Code} over,{DateTime.Now.Subtract(now).TotalMilliseconds} ms elapsed.");
        }, Config.MaxParallelTasks);

        profileSummaries.Save();
    }
}