using System.Diagnostics;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Productions.Casino.CcaAndReport;
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
                new Action(() => Signalert.Collector.Sites.PrepareOnesDailyPrices(args[1])).ExecuteAndTiming($"one(PrepareOnesDailyPrices({args[1]}))");
                break;

            case "--check":
                new Action(() => Signalert.ExecuteRealtimeJob(args[1])).ExecuteAndTiming($"realtime(ExecuteRealtimeJob({args[1]}))");
                break;

            default:
                $"--all:                     prepare all data(exclude events and seeds)".WriteColorLine(ConsoleColor.DarkYellow);
                $"--prepare:                 prepare all data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--daily :                  prepare ones daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--one code :               prepare ones daily prices".WriteColorLine(ConsoleColor.DarkYellow);
                $"--realtime [codes] :       refresh realtime".WriteColorLine(ConsoleColor.DarkYellow);

                break;
        }

        Sw.Stop();

        $"{Sw.ElapsedMilliseconds} ms spent @{controlCode}".WriteColorLine(ConsoleColor.DarkYellow);
    }

    private static readonly Stopwatch Sw = new();
}