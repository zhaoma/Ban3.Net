using System.Diagnostics;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.CcaAndReport.Implements;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Request;

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
                new Action(() => Signalert.ExecuteFullyJob(true)).ExecuteAndTiming("prepare(ExecuteFullyJob)");
                break;

            case "--prepare":
                new Action(() => Signalert.ExecuteFullyJob()).ExecuteAndTiming("prepare(ExecuteFullyJob exclude events and seeds)");
                break;

            case "--daily":
                new Action(Signalert.ExecuteDailyJob).ExecuteAndTiming("daily(ExecuteDailyJob)");
                break;

            case "--realtime":
                if (args.Length <= 1)
                {
                    new Action(Signalert.ExecuteRealtimeJob).ExecuteAndTiming("realtime(ExecuteRealtimeJob)");
                }
                else
                {
                    new Action(() => Signalert.ExecuteRealtimeJob(args[1])).ExecuteAndTiming($"realtime(ExecuteRealtimeJob({args[1]}))");
                }

                break;

            case "--one":
                new Action(
                    () =>
                    {
                        Signalert.ExecuteDailyJob(args[1]);
                    }).ExecuteAndTiming($"one(PrepareOnesDailyPrices({args[1]}))");

                break;

            case "--check":
                new Action(() => CheckSomething()).ExecuteAndTiming($"CheckSomething");
                break;

            case "--dots":
                new Action(() =>
                {
                    Signalert.PrepareFocus(Config.DefaultFilter, out var _);
                    Signalert.PrepareDots(Config.DefaultFilter);
                }).ExecuteAndTiming("Prepare Dots & Focus");
                break;

            default:
                $"--all:                     prepare all data(exclude events and seeds)".WriteColorLine(ConsoleColor.DarkYellow);
                $"--prepare:                 prepare all data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--daily :                  prepare all daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--one code :               prepare ones daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--realtime [codes] :       refresh all realtime data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--dots :                   refresh dagram data".WriteColorLine(ConsoleColor.DarkYellow);
                CheckSomething();
                break;
        }

        Sw.Stop();

        $"{Sw.ElapsedMilliseconds} ms spent @{controlCode}".WriteColorLine(ConsoleColor.DarkYellow);
    }

    private static readonly Stopwatch Sw = new();

    private static void CheckSomething()
    {
        $"program line 90, nothing in check".WriteColorLine(ConsoleColor.Yellow);
    }
}