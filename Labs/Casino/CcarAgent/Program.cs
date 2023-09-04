using System.Diagnostics;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Models;

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
                    .ExecuteAndTiming("Prepare(ExecuteFullyJob exclude events and seeds)");
                break;

            case "--daily":
                new Action(Signalert.ExecuteDailyJob)
                    .ExecuteAndTiming("Daily Job (ExecuteDailyJob)");
                break;

            case "--one":
                new Action(() => { Signalert.ExecuteDailyJob(args[1]); })
                    .ExecuteAndTiming($"One(PrepareOnesDailyPrices({args[1]}))");
                break;

            case "--reinstate":
                new Action(() => { Signalert.ReinstateAllPrices(); })
                    .ExecuteAndTiming("ReinstateData.");
                break;

            case "--dr":
                new Action(() =>
                {
                    Signalert.Analyzer.PrepareDistributeRecords();
                }).ExecuteAndTiming("PrepareDistributeRecords");
                break;

            case "--check":
                new Action(CheckSomething)
                    .ExecuteAndTiming("CheckSomething(temp func).");
                break;

            default:
                $"--all :            prepare all data(exclude events and seeds)".WriteColorLine(ConsoleColor.DarkYellow);
                $"--prepare :        prepare all data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--daily :          prepare all daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--one [code] :     prepare ones daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--reinstate :      reinstate prices and indicators data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--dr :             distribute records data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--check :          check some temp function@ca.Main".WriteColorLine(ConsoleColor.DarkYellow);

                break;
        }

        Sw.Stop();

        $"{Sw.ElapsedMilliseconds} ms elapsed. @{controlCode}".WriteColorLine(ConsoleColor.DarkYellow);
    }

    private static readonly Stopwatch Sw = new();

    private static void CheckSomething()
    {
        Console.WriteLine("NOTHING IN QUEUE.");

        //Any trial functions test here...

        var stocks = Signalert.Collector.LoadAllCodes();
        new Action(() =>
        {
            Signalert.Calculator.GenerateTargets(stocks);
        }).ExecuteAndTiming("GenerateTargets");

        var targets = new Targets();
        $"{targets.Data.Count(o=>!o.Value.Ignore)} found".WriteColorLine(ConsoleColor.Red);

        Console.WriteLine(Productions.Casino.Contracts.Config.IgnoreKeys.ObjToJson());

        Console.WriteLine(
        targets.Data.Count(o =>
            !o.Value.Ignore&&
            Productions.Casino.Contracts.Config.IgnoreKeys.Any(x => o.Value.LatestSets.SetKeys!.Contains(x))));
    }
}