using System.Diagnostics;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Extensions;

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

            case "--realtime":
                if (!Config.NeedSync())
                {
                    $"--realtime only run 9:15 - 15:00".WriteColorLine(ConsoleColor.Red);
                    break;
                }

                if (args.Length <= 1)
                {
                    new Action(Signalert.ExecuteRealtimeJob)
                        .ExecuteAndTiming("realtime(ExecuteRealtimeJob)");
                }
                else
                {
                    new Action(() => Signalert.ExecuteRealtimeJob(args[1]))
                        .ExecuteAndTiming($"realtime(ExecuteRealtimeJob({args[1]}))");
                }

                break;

            case "--one":
                new Action(() => { Signalert.ExecuteDailyJob(args[1]); })
                    .ExecuteAndTiming($"one(PrepareOnesDailyPrices({args[1]}))");

                break;

            case "--realtimeOnly":
                new Action(() => { Signalert.Collector.ReadRealtime(); })
                    .ExecuteAndTiming("Prepare realtime prices only.");
                break;

            case "--reinstate":
                new Action(() => { Signalert.ReinstateData(Signalert.Collector.LoadAllCodes()); })
                    .ExecuteAndTiming("ReinstateData.");
                break;

            case "--output":
                new Action(() => { Signalert.PrepareOutput(Signalert.Collector.LoadAllCodes()); })
                    .ExecuteAndTiming("PrepareOutput.");
                break;

            case "--eva":
                new Action(() => { Signalert.EvaluateProfiles(Signalert.Collector.ScopedCodes()); })
                    .ExecuteAndTiming("EvaluateProfiles.");
                break;

            case "--check":
                new Action(CheckSomething)
                    .ExecuteAndTiming("CheckSomething.");
                break;

            case "--v2":
                var codes = Signalert.Collector.ScopedCodes();
                Signalert.PrepareV2(codes);

                break;

            default:
                $"--all:                     prepare all data(exclude events and seeds)".WriteColorLine(ConsoleColor
                    .DarkYellow);
                $"--prepare:                 prepare all data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--daily :                  prepare all daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--realtime [codes] :       refresh all realtime data(prices and reinstate etc.)".WriteColorLine(
                    ConsoleColor.DarkYellow);
                $"--one [code] :             prepare ones daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--realtimeOnly :           refresh realtime prices only"
                    .WriteColorLine(ConsoleColor.DarkYellow);
                $"--reinstate :              reinstate prices and indicators data".WriteColorLine(ConsoleColor
                    .DarkYellow);
                $"--output :                 prepare charts or others output data".WriteColorLine(ConsoleColor
                    .DarkYellow);
                $"--check :                  check some temp function@ca.Main".WriteColorLine(ConsoleColor.DarkYellow);

                break;
        }

        Sw.Stop();

        $"{Sw.ElapsedMilliseconds} ms elapsed. @{controlCode}".WriteColorLine(ConsoleColor.DarkYellow);
    }

    private static readonly Stopwatch Sw = new();

    private static void CheckSomething()
    {

    }
}