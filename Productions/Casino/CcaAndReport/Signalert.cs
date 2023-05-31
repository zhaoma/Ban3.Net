using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Attributes;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
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

    public static async Task<bool> PrepareAllSeeds()
    {
        var result = true;
        var allCodes = Signalert.Collector.Sites.LoadAllCodes();
        await allCodes.ParallelExecuteAsync((stock) => { result = result && PrepareSeeds(stock); },
            Config.MaxParallelTasks);

        return result;
    }

    public static async Task<bool> ReinstateAllPrices()
    {
        var result = true;
        var allCodes = Signalert.Collector.Sites.LoadAllCodes();
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
        
        Collector.FixDailyPrices();

        var reinstate = await Signalert.ReinstateAllPrices();

        if (reinstate)
        {
            var allCodes = Signalert.Collector.LoadAllCodes();

            await allCodes.ParallelExecuteAsync((stock) =>
            {
                Calculator.GenerateIndicatorLine(stock.Code);
            }, Config.MaxParallelTasks);

        }
    }

    //public static async Task ExecuteRealtimeJob()
    //{

    //}
}