using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.CcaAndReport;

public partial class Signalert
{
    public static bool PrepareOne(Stock stock, out List<string> message)
    {
        message = new List<string>();

        try
        {
            var sw = new Stopwatch();
            sw.Start();

            var prices = Calculator.LoadReinstatedPrices(stock.Code, Contracts.Enums.StockAnalysisCycle.DAILY);

            sw.Stop();
            message.Add($"Load ReinstatedPrices,{sw.ElapsedMilliseconds} elapsed.=>{prices.Count}");
            sw.Restart();

            var weeklyPrices = new List<StockPrice>();
            var monthlyPrices = new List<StockPrice>();

            for (var i = 1; i <= prices.Count; i++)
            {
                var destPrices = new StockPrice[i];
                prices.CopyTo(0, destPrices, 0, i);

                var a = destPrices.ToList().ConvertCycle(Contracts.Enums.StockAnalysisCycle.WEEKLY);
                var b = destPrices.ToList().ConvertCycle(Contracts.Enums.StockAnalysisCycle.MONTHLY);

                weeklyPrices.Add(a.Last());
                monthlyPrices.Add(b.Last());
            }

            sw.Stop();
            message.Add($"Generate weekly and monthly prices {sw.ElapsedMilliseconds} ms elapsed.=>W:{weeklyPrices.Count};M:{monthlyPrices.Count}");
            sw.Restart();

            weeklyPrices.SetsFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.WEEKLY}")
                .SaveFileOnDemand(weeklyPrices, out _);

            sw.Stop();
            message.Add($"Save weekly prices {sw.ElapsedMilliseconds} ms elapsed.");
            sw.Restart();

            monthlyPrices.SetsFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.MONTHLY}")
                .SaveFileOnDemand(monthlyPrices, out _);

            sw.Stop();
            message.Add($"Save monthly prices {sw.ElapsedMilliseconds} ms elapsed.");
            sw.Restart();

            var dailyLineOfPoint = prices.IndicatorLine(stock.Code);
            typeof(LineOfPoint)
            .LocalFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.DAILY}")
            .SaveFileOnDemand(dailyLineOfPoint, out _);

            sw.Stop();
            message.Add($"Generate daily IndicatorLine,{sw.ElapsedMilliseconds} ms elapsed.=>{dailyLineOfPoint.EndPoints.Count}");
            sw.Restart();

            var weeklyLineOfPoint = weeklyPrices.IndicatorLine(stock.Code);
            typeof(LineOfPoint)
            .LocalFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.WEEKLY}")
            .SaveFileOnDemand(weeklyLineOfPoint, out _);

            sw.Stop();
            message.Add($"Generate weekly IndicatorLine,{sw.ElapsedMilliseconds} ms elapsed.=>{weeklyLineOfPoint.EndPoints.Count}");
            sw.Restart();

            var monthlyLineOfPoint = monthlyPrices.IndicatorLine(stock.Code);
            typeof(LineOfPoint)
            .LocalFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.MONTHLY}")
            .SaveFileOnDemand(monthlyLineOfPoint, out _);

            sw.Stop();
            message.Add($"Generate monthly IndicatorLine,{sw.ElapsedMilliseconds} ms elapsed.=>{monthlyLineOfPoint.EndPoints.Count}");
            sw.Restart();

            var d = dailyLineOfPoint.LineToSets();

            sw.Stop();
            message.Add($"Daily Indicators LineToSets,{sw.ElapsedMilliseconds} ms elapsed.=>{d.Count}");
            sw.Restart();

            var w = weeklyLineOfPoint.LineToSets();

            var m = monthlyLineOfPoint.LineToSets();

            for (var index = 0; index < d.Count; index++)
            {
                var keys = d[index].SetKeys.Select(o => $"{o}.{Contracts.Enums.StockAnalysisCycle.DAILY}");
                keys = keys.Union(w[index].SetKeys.Select(o => $"{o}.{Contracts.Enums.StockAnalysisCycle.WEEKLY}"));
                keys = keys.Union(m[index].SetKeys.Select(o => $"{o}.{Contracts.Enums.StockAnalysisCycle.MONTHLY}"));
                d[index].SetKeys = keys;

                Console.WriteLine($"i{d[index].MarkTime.ToYmd()}:{keys.AggregateToString(",")}");

                //Console.WriteLine(d[index].MarkTime.ToYmd() + ":" + d[index].SetKeys.AggregateToString(","));
                //Console.WriteLine();
            }

            stock.Code.DataFile<StockSets>()
                .SaveFileOnDemand(d, out _);

            sw.Stop();
            message.Add($"Merge LineToSets,{sw.ElapsedMilliseconds} elapsed.=>{d.Count}");
            sw.Restart();

            $"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.DAILY}"
                .DataFile<Diagram>()
                .SaveFileOnDemand(Reportor.CreateOnesCandlestickDiagram(stock, prices, dailyLineOfPoint), out _);

            $"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.WEEKLY}"
                .DataFile<Diagram>()
                .SaveFileOnDemand(Reportor.CreateOnesCandlestickDiagram(stock, weeklyPrices, weeklyLineOfPoint), out _);

            $"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.WEEKLY}"
                .DataFile<Diagram>()
                .SaveFileOnDemand(Reportor.CreateOnesCandlestickDiagram(stock, monthlyPrices, monthlyLineOfPoint), out _);

            sw.Stop();
            message.Add($"Create Diagrams,{sw.ElapsedMilliseconds} elapsed.");
            sw.Restart();

            var dic = new Dictionary<string, List<StockOperate>>();
            var profiles = Profiles();

            for (var index = 0; index < d.Count; index++)
            {
                profiles.ForEach(p =>
                {
                    var so = dic.TryGetValue(p.Identity, out var stockOperates);
                    if (so)
                    {
                        var latestOperate = stockOperates.Last();

                        var currentOperate = d[index].SetKeys.GetOperate(p, latestOperate.Operate);

                        if (currentOperate != latestOperate.Operate)
                        {
                            dic[p.Identity].Add(new StockOperate
                            {
                                Code = stock.Code,
                                Symbol = stock.Symbol,
                                MarkTime = d[index].MarkTime,
                                Close = (decimal)prices[index].Close,
                                Operate = currentOperate
                            });
                        }
                    }
                    else
                    {
                        dic.Add(p.Identity, new List<StockOperate>
                        {
                            new StockOperate{
                                Code=stock.Code,
                                Symbol=stock.Symbol,
                                MarkTime=d[index].MarkTime,
                                Close=(decimal)prices[index].Close,
                                Operate=Infrastructures.Indicators.Enums.StockOperate.Left
                            }
                        });
                    }

                });
            }

            foreach (var kv in dic)
            {
                $"{stock.Code}.{kv.Key}"
                    .DataFile<StockOperate>()
                    .SaveFileOnDemand(kv.Value, out _);

                var rs= kv.Value.ConvertOperates2Records(new Profile { Identity = kv.Key }, stock.Code);
                message.Add($"Generate operates and records : {kv.Value.Count} -> {rs.Count}");
            }

            sw.Stop();
            message.Add($"Evaluate profiles,{sw.ElapsedMilliseconds} elapsed.");
            sw.Restart();

            sw = null;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
            message.Add($"ERROR:{ex.Message}");
        }

        return true;
    }

}