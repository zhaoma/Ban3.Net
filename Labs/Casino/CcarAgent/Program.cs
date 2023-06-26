using System.Diagnostics;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Indicators.Outputs;
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

            case "--check":
                new Action(CheckSomething)
                    .ExecuteAndTiming("CheckSomething.");
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
        var stocks = Signalert.Collector.LoadAllCodes();

        new Action(() =>
            stocks.ParallelExecute((stock) =>
            {
                var sets = Signalert.Calculator.LoadSets(stock.Code);
                if (sets != null && sets.Any())
                {
                    Infrastructures.Indicators.Helper.DefaultProfiles
                        .Where(o => o.Persistence)
                        .ParallelExecute((profile) =>
                        {
                            Signalert.Analyzer
                                .OutputDailyOperates(profile, sets, stock.Code)
                                .ConvertOperates2Records(profile, stock.Code);
                        },
                            Config.MaxParallelTasks);
                }
            }, Config.MaxParallelTasks)
        ).ExecuteAndTiming("OutputDailyOperates");

        /*

        var code = "688160.SH";
        var indicatorValue = Signalert.Calculator.LoadIndicatorLine(code,Productions.Casino.Contracts.Enums.StockAnalysisCycle.DAILY);

        var a = indicatorValue.LineToSets();
        a.ObjToJson().WriteColorLine(ConsoleColor.Red);
    var notices = a
            .Where(o => o.SetKeys != null && o.SetKeys.Any(x => x.StartsWith("MACD.C0")))
            .Select(o => new object[] { o.Code, o.Close })
            .ToList();

        Console.WriteLine(notices.Count);


        var ss = Signalert.Calculator.LoadSets(code);
        var ns=ss.Where(o => o.SetKeys != null && o.SetKeys.Any(x => x.StartsWith("MACD.C0.")))
            .Select(o => new object[] { o.Code, o.Close })
            .ToList();

        Console.WriteLine(ns.Count);


        var latest=Signalert.Calculator.LoadList().OrderBy(o=>o.Rank).ThenByDescending(o=>o.Code);
        latest.Take(10).ToList()
            .ForEach(
            o =>
            {
                $"{o.Code} -> {o.Close}".WriteColorLine(ConsoleColor.DarkGreen);
            });
        return;


        var dotsDic = Signalert.Reportor.LoadDots(Config.DefaultFilter);
        Signalert.Collector.LoadAllCodes()
            .Where(o=>dotsDic.ContainsKey(o.Code))
            .ToList()
            .ForEach(
            target =>
            {
                target.Code.WriteColorLine(ConsoleColor.Green);
                var dic = new Dictionary<string, List<KeyValuePair<string, ConsoleColor>>>();
                var sets = Signalert.Calculator.LoadSets(target.Code);

                var ss = sets.FindAll(o => o.SetKeys.Any(x => x.StartsWith("MACD.C0.")));
                $"{ss.Count()} found.".WriteColorLine(ConsoleColor.Blue);
                ss.ForEach(o =>
                {
                    if (dic.ContainsKey(o.MarkTime.ToYmd()))
                    {


                        if (Infrastructures.Indicators.Helper.DefaultProfile.Match(o))
                        {
                            dic[o.MarkTime.ToYmd()].Add(
                                new KeyValuePair<string, ConsoleColor>(o.SetKeys.AggregateToString(","),
                                ConsoleColor.Yellow));

                            dic[o.MarkTime.ToYmd()]
                                .Add(new KeyValuePair<string, ConsoleColor>(
                                    "MATCH",
                                    ConsoleColor.Blue));
                        }
                    }
                    else
                    {

                        if (Infrastructures.Indicators.Helper.DefaultProfile.Match(o))
                        {
                            var nd = new List<KeyValuePair<string, ConsoleColor>>
                            {
                                new KeyValuePair<string, ConsoleColor>(
                                    o.SetKeys.AggregateToString(","),
                                    ConsoleColor.Yellow)
                            };

                            nd.Add(new KeyValuePair<string, ConsoleColor>("MATCH",
                                ConsoleColor.Blue));

                            dic.Add(o.MarkTime.ToYmd(),nd);
                        }
                    }
                });

                if (dotsDic.TryGetValue(target.Code, out var dots))
                {
                    dots.ForEach(o =>
                    {
                        var sks = sets.GetSets(o.TradeDate);

                        if (dic.ContainsKey(o.TradeDate))
                        {
                            dic[o.TradeDate]
                                .Add(new KeyValuePair<string, ConsoleColor>($"{o.Days}:{o.ChangePercent}{sks.OrderBy(y=>y).AggregateToString("\r\n")}",
                                    ConsoleColor.Red));
                            if (Infrastructures.Indicators.Helper.DefaultProfile.Match(new StockSets { SetKeys = sks }))
                            dic[o.TradeDate]
                                .Add(new KeyValuePair<string, ConsoleColor>(
                                  "MATCH",
                                    ConsoleColor.Blue));
                        }
                        else
                        {
                            var nc = new List<KeyValuePair<string, ConsoleColor>>
                            {
                                new KeyValuePair<string, ConsoleColor>(
                                    $"{o.Days}:{o.ChangePercent}{sks.OrderBy(y => y).AggregateToString("\r\n")}",
                                    ConsoleColor.Red)
                            };

                            if(Infrastructures.Indicators.Helper.DefaultProfile.Match(new StockSets { SetKeys = sks }))
                                nc.Add(new KeyValuePair<string, ConsoleColor>(
                                        "MATCH",
                                        ConsoleColor.Blue));

                            dic.Add(o.TradeDate,nc);
                        }
                    });
                }

                dic.OrderBy(o => o.Key)
                    .ToList()
                    .ForEach(o =>
                    {
                        foreach (var keyValuePair in o.Value)
                        {
                            $"{o.Key}:{keyValuePair.Key}".WriteColorLine(keyValuePair.Value);
                        }
                    });
                Console.Read();
            }
        );*/
    }
}