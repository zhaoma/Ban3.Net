using System.Diagnostics;
using System.Security.Principal;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Common.Models;
using Ban3.Infrastructures.Consoles;
using Ban3.Infrastructures.Indicators;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.CcaAndReport;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using Stock = Ban3.Infrastructures.Indicators.Entries.Stock;

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
                $"--check :          check some temp function@ca.Main".WriteColorLine(ConsoleColor.DarkYellow);
                CheckSomething();
                break;
        }

        Sw.Stop();

        $"{Sw.ElapsedMilliseconds} ms elapsed. @{controlCode}".WriteColorLine(ConsoleColor.DarkYellow);
    }

    private static readonly Stopwatch Sw = new();

    private static void CheckSomething()
    {
        Console.WriteLine("NOTHING IN QUEUE.");

        var stocks = Signalert.TargetCodes()
            .Select(o=>new Infrastructures.Indicators.Entries.Stock
            {
                Code=o.Code,
                Symbol=o.Symbol,
                Name = o.Name,
                ListDate=o.ListDate
            })
            .ToList();
        /*
        var ps = new List<DistributeCondition>
                 {
                     new DistributeCondition(
                        1,
                        "科创板三周期",
                        new DistributeExpression
                        {
                            StartsWith="68",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        2,
                        "科创板日与周",
                        new DistributeExpression
                        {
                            StartsWith="68",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        3,
                        "科创板日周期",
                        new DistributeExpression
                        {
                            StartsWith="68",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        11,
                        "创业板三周期",
                        new DistributeExpression
                        {
                            StartsWith="30",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        12,
                        "创业板日与周",
                        new DistributeExpression
                        {
                            StartsWith="30",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        13,
                        "创业板日周期",
                        new DistributeExpression
                        {
                            StartsWith="30",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        21,
                        "中小板三周期",
                        new DistributeExpression
                        {
                            StartsWith="002,003",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        22,
                        "中小板日与周",
                        new DistributeExpression
                        {
                            StartsWith="002,003",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        23,
                        "中小板日周期",
                        new DistributeExpression
                        {
                            StartsWith="002,003",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        31,
                        "沪主板三周期",
                        new DistributeExpression
                        {
                            StartsWith="60",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        32,
                        "沪主板日与周",
                        new DistributeExpression
                        {
                            StartsWith="60",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        33,
                        "沪主板日周期",
                        new DistributeExpression
                        {
                            StartsWith="60",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        41,
                        "深主板三周期",
                        new DistributeExpression
                        {
                            StartsWith="000,001",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly&IndicatorHas.Monthly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        42,
                        "深主板日与周",
                        new DistributeExpression
                        {
                            StartsWith="000,001",
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        43,
                        "深主板日周期",
                        new DistributeExpression
                        {
                            StartsWith="000,001",
                            IndicatorHas=IndicatorHas.Daily,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),

                     new DistributeCondition(
                        51,
                        "100+",
                        new DistributeExpression
                        {
                            MinPrice=100,
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                     new DistributeCondition(
                        52,
                        "5-",
                        new DistributeExpression
                        {
                            MaxPrice=5,
                            IndicatorHas=IndicatorHas.Daily&IndicatorHas.Weekly,
                            Sorter=RecordsSorter.Increase&RecordsSorter.Asc
                        }
                     ),
                 };
        var codes = stocks.Select(o => o.Code).ToList();

        var dic = new Dictionary<DistributeCondition, MultiResult<TimelineRecord>>();
        ps
            .ForEach(o =>
            {
                Console.WriteLine(o.Rank);
                dic.Add(o,new MultiResult<TimelineRecord>{Data=new List<TimelineRecord>{ new TimelineRecord { Code = o.Rank + "!" } }});
            });

        dic.ObjToJson().WriteColorLine(ConsoleColor.DarkYellow);
        */
        var x = new DistributeCondition(
            1,
            "科创板三周期",
            new DistributeExpression
            {
                StartsWith = "68",
                IndicatorHas = IndicatorHas.Daily & IndicatorHas.Weekly & IndicatorHas.Monthly,
                Sorter = RecordsSorter.Increase & RecordsSorter.Asc
            }
        );

        x.ObjToJson().WriteColorLine(ConsoleColor.DarkRed);

        var a = new DD {S="HA", T = TT.A | TT.B };
        a.ObjToJson().WriteColorLine(ConsoleColor.DarkYellow);
        Console.WriteLine(a.GetHashCode());
        var dic = new Dictionary<DD, MultiResult<TimelineRecord>>();
        dic.Add(a,new MultiResult<TimelineRecord>{Data = new List<TimelineRecord>{new TimelineRecord{Code = "xx"}}});



        dic.ObjToJson().WriteColorLine(ConsoleColor.Blue);
    }
    
}

public class DD
{
    [JsonProperty("s", NullValueHandling = NullValueHandling.Ignore)]
    public string S { get; set; }

    [JsonProperty("t", NullValueHandling = NullValueHandling.Ignore)]
    public TT T { get; set; }

    public override bool Equals(object obj)
    {
        var your_class = (DD)obj;
        return your_class.T == this.T ;
    }

    public override int GetHashCode()
    {
        int id_hashcode = T.GetHashCode();

        return id_hashcode *297+S.GetHashCode();
    }

    public override string ToString()
    {
        return this.ObjToJson();
    }
}

[Flags]
public enum TT
{
    A,
    B
}