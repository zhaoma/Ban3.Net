using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Extensions;
using System.Collections.Generic;
using System;
using Ban3.Productions.Casino.Contracts;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using System.Linq;

namespace Ban3.Productions.Casino.CcaAndReport;

public partial class Signalert
{
    public static void PrepareEventsAndSeeds(List<Contracts.Entities.Stock> allCodes = null)
    {
        allCodes ??= Collector.LoadAllCodes();
        Collector.PrepareAllEvents(allCodes);

        ReinstateAllPrices(allCodes);
    }
    
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

    public static void EvaluateProfiles()
    {
        var stocks = Collector.ScopedCodes();

        var total = stocks.Count;
        var current = 0;
        var profileSummaries = new Dictionary<string, ProfileSummary>();

        stocks.ParallelExecute(one =>
        {
            var now = DateTime.Now;
            var stock = new Stock
            { Code = one.Code, ListDate = one.ListDate, Name = one.Name, Symbol = one.Symbol };

            var dailySets = stock.LoadStockSets();

            Profiles().ForEach(profile =>
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
        },Config.MaxParallelTasks);

        profileSummaries.Save();

        Profiles().ForEach(profile => { Signalert.PrepareCompositeRecords(stocks.Select(o => o.Code).ToList(), profile.Identity); });
    }
}