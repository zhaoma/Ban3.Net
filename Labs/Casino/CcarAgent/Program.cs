using System.Diagnostics;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Infrastructures.Indicators;

namespace Ban3.Labs.Casino.CcarAgent;

internal class Program
{
    static void Main(string[] args)
    {
        var controlCode = args.Any() ? args[0].ToLower() : string.Empty;

        Sw.Start();
        switch (controlCode)
        {
            case "--all":
                new Action(() => Signalert.ExecuteFullyJob(true))
                    .ExecuteAndTiming("prepare(ExecuteFullyJob)");
                break;

            case "--prepare":
                new Action(() => Signalert.ExecuteFullyJob())
                    .ExecuteAndTiming("prepare(ExecuteFullyJob exclude events and seeds)");
                break;

            case "--daily":
                new Action(Signalert.ExecuteDailyJob)
                    .ExecuteAndTiming("daily(ExecuteDailyJob)");
                break;

            case "--one":
                new Action(() => { Signalert.ExecuteDailyJob(args[1]); })
                    .ExecuteAndTiming($"one(PrepareOnesDailyPrices({args[1]}))");

                break;

            case "--reinstate":
                new Action(() => { Signalert.ReinstateAllPrices(Signalert.Collector.LoadAllCodes()); })
                    .ExecuteAndTiming("ReinstateData.");
                break;

            case "--check":
                new Action(CheckSomething)
                    .ExecuteAndTiming("CheckSomething.");
                break;

            default:
                $"--all:                 prepare all data(exclude events and seeds)".WriteColorLine(ConsoleColor.DarkYellow);
                $"--prepare:             prepare all data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--daily :              prepare all daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--one [code] :         prepare ones daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--reinstate :          reinstate prices and indicators data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--check :              check some temp function@ca.Main".WriteColorLine(ConsoleColor.DarkYellow);

                break;
        }

        Sw.Stop();

        $"{Sw.ElapsedMilliseconds} ms elapsed. @{controlCode}".WriteColorLine(ConsoleColor.DarkYellow);
    }

    private static readonly Stopwatch Sw = new();

    private static void CheckSomething()
    {
        //Signalert.ExecuteDailyJob();
        var code = "300580.SZ";

        var dailyPrices = Signalert.Calculator.LoadPricesForIndicators(code, StockAnalysisCycle.DAILY);
        var dots = dailyPrices.DotsOfBuyingOrSelling(Infrastructures.Indicators.Helper.DefaultFilter);

        if (dots != null)
        {
            dots.ForEach(d =>
            {
                d.ObjToJson().WriteColorLine(ConsoleColor.Red);
                Console.WriteLine();
            });
        }
    }
}