using System.Diagnostics;
using System.Runtime.CompilerServices;
using Ban3.Infrastructures.Charts.Enums;
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
                new Action(() => Signalert.ExecuteFullyJob()).ExecuteAndTiming(
                    "prepare(ExecuteFullyJob exclude events and seeds)");
                break;

            case "--daily":
                new Action(Signalert.ExecuteDailyJob).ExecuteAndTiming("daily(ExecuteDailyJob)");
                break;

            case "--realtime":
                if (!Config.NeedSync())
                {
                    $"--realtime only run 9:15 - 15:00".WriteColorLine(ConsoleColor.Red);
                    break;
                }

                if (args.Length <= 1)
                {
                    new Action(Signalert.ExecuteRealtimeJob).ExecuteAndTiming("realtime(ExecuteRealtimeJob)");
                }
                else
                {
                    new Action(() => Signalert.ExecuteRealtimeJob(args[1])).ExecuteAndTiming(
                        $"realtime(ExecuteRealtimeJob({args[1]}))");
                }

                break;

            case "--one":
                new Action(
                        () => { Signalert.ExecuteDailyJob(args[1]); })
                    .ExecuteAndTiming($"one(PrepareOnesDailyPrices({args[1]}))");

                break;

            case "--check":
                new Action(CheckSomething).ExecuteAndTiming($"CheckSomething");
                break;

            case "--dots":
                Console.WriteLine("Prepare Focus...");
                new Action(() => { Signalert.PrepareFocus(Config.DefaultFilter, out var _); }).ExecuteAndTiming(
                    "Prepare Focus");

                Console.WriteLine();

                Console.WriteLine("Prepare Dots...");
                new Action(() => { Signalert.PrepareDots(Config.DefaultFilter); }).ExecuteAndTiming("Prepare Dots");
                break;

            default:
                $"--all:                     prepare all data(exclude events and seeds)".WriteColorLine(ConsoleColor
                    .DarkYellow);
                $"--prepare:                 prepare all data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--daily :                  prepare all daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--one code :               prepare ones daily data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--realtime [codes] :       refresh all realtime data".WriteColorLine(ConsoleColor.DarkYellow);
                $"--dots :                   refresh diagram data".WriteColorLine(ConsoleColor.DarkYellow);
                CheckSomething();
                break;
        }

        Sw.Stop();

        $"{Sw.ElapsedMilliseconds} ms spent @{controlCode}".WriteColorLine(ConsoleColor.DarkYellow);
    }

    private static readonly Stopwatch Sw = new();

    private static void CheckSomething()
    {
        //$"program line 90, nothing in check".WriteColorLine(ConsoleColor.Yellow);
        var now = DateTime.Now;

        var drs = Signalert.Reportor.LoadDotsSankey(Config.DefaultFilter)
            .Where(o => o.ChangePercent > 0);

        var up4 = drs.Where(o => 
        o.SetKeys.Count(x=>x.StartsWith("MACD.PDI."))+ o.SetKeys.Count(x => x.StartsWith("DMI.PDI."))>4
        ).ToList();

        $"up4={up4.Count}".WriteColorLine(ConsoleColor.Red);

        var k = "MACD";
        var dots = drs
                .OrderBy(o=>o.TradeDate)
                .ToList();
        dots
            .ForEach(o =>
        {
            var macd = o.SetKeys.Where(o => o.StartsWith($"{k}.")).OrderBy(o => o);
            $"{o.Code}:{o.TradeDate}/{Math.Round(o.ChangePercent,2)}:{macd.AggregateToString(",")}  ".WriteColorLine(ConsoleColor.DarkYellow);

            $"{macd.Count(o=>o.StartsWith($"{k}.PDI."))} .PDI".WriteColorLine(ConsoleColor.Green);
        });

        var dic = dots.Select(o => o.SetKeys.Where(x => x.StartsWith($"{k}."))).MergeToDictionary();
        Console.WriteLine(dots.Count);

        foreach (var kv in dic.OrderByDescending(o=>o.Value))
        {
            $"{kv.Key }={kv.Value}".WriteColorLine(ConsoleColor.Red);
        }

        var s = Signalert.Reportor.LoadAllLatestSets();
        var t = Signalert.FilterStockSets(s);
        Console.WriteLine("FilterStockSets=" + t.Count);

        for (var i = 0; i < Math.Min(10, t.Count); i++)
        {
            $"{t[i].Code}:{t[i].SetKeys?.AggregateToString(",")}".WriteColorLine(ConsoleColor.Blue);
        }
       
    }

    /*
    var s = Signalert.Reportor.LoadAllLatestSets();
    Console.WriteLine(s.Count);

    s.GenerateList($"{now.ToYmd()}.all");

    var t = Signalert.FilterStockSets(s);
    Console.WriteLine(t.Count);

    t.GenerateList($"{now.ToYmd()}.filter");

    var all = Signalert.Calculator.LoadList($"{now.ToYmd()}.all")
        .Take(20);

    foreach (var listRecord in all)
    {
        var r1 = s.Last(o => o.Code == listRecord.Code);
        var k1 = r1.SetKeys?
            .Where(o => o.StartsWithIn(new List<string> { "MACD.", "DMI." }))
            .OrderBy(o => o);

        $"{listRecord.Code}:{listRecord.Value}->{listRecord.Rank}:{k1?.AggregateToString(" , ")}".WriteColorLine(
            ConsoleColor.Red);
    }

    var filter = Signalert.Calculator.LoadList($"{now.ToYmd()}.filter")
        .Take(20);

    foreach (var listRecord in filter)
    {
        var r2 = s.Last(o => o.Code == listRecord.Code);
        var k2 = r2.SetKeys?
            .Where(o => o.StartsWithIn(new List<string> { "MACD.", "DMI." }))
            .OrderBy(o => o);

        $"{listRecord.Code}:{listRecord.Value}->{listRecord.Rank}:{k2?.AggregateToString(" , ")}".WriteColorLine(
            ConsoleColor.DarkBlue);
    }*/
}