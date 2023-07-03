using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Extensions;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.CcaAndReport;

public partial class Signalert
{
    public static void PrepareV2(List<Stock> stocks)
    {
        new Action(() => Collector.FixDailyPrices(stocks)).ExecuteAndTiming("FixDailyPrices");

        new Action(() => ReinstateAllPrices(stocks)).ExecuteAndTiming("ReinstateAllPrices");

        stocks.ParallelExecute((stock) => {
	     Signalert.PrepareOne(stock, msg => { Logger.Debug($"{stock.Code}:{msg}"); }); },
                Config.MaxParallelTasks);

        var latestSets = new List<StockSets>();
        stocks.ForEach(stock =>
        {
            var ones = Calculator.LoadSets(stock.Code);
            if (ones != null && ones.Any())
                latestSets.Add(ones.Last());
        });
        $"latest".DataFile<StockSets>()
            .WriteFile(latestSets.ObjToJson());

        latestSets.GenerateList(DateTime.Now.ToYmd());

        new Action(() =>
            PrepareDots(stocks, Config.DefaultFilter)
        ).ExecuteAndTiming("PrepareDots");
    }

    public static bool PrepareOne(Stock stock, Action<string> messageCallback)
    {
        try
        {
            var sw = new Stopwatch();
            sw.Start();

            var prices = Calculator.LoadReinstatedPrices(stock.Code, Contracts.Enums.StockAnalysisCycle.DAILY);

            sw.Stop();
            messageCallback($"Load ReinstatedPrices,{sw.ElapsedMilliseconds} ms elapsed.=>{prices.Count}");
            sw.Restart();

            var weeklyPrices = new List<StockPrice>();
            var monthlyPrices = new List<StockPrice>();
            
            //var destPrices=new List<StockPrice>();
            for (var i = 1; i <= prices.Count; i++)
            {
                weeklyPrices.AppendLatest(prices[i-1],StockAnalysisCycle.WEEKLY);
                monthlyPrices.AppendLatest(prices[i-1],StockAnalysisCycle.MONTHLY);
                /*
                //var destPrices = prices.CloneNew(i);

                var o = prices[i - 1];
                destPrices.Add(new StockPrice
                {
                    Code = o.Code,
                    TradeDate = o.TradeDate,
                    Open = o.Open,
                    High = o.High,
                    Low = o.Low,
                    Close = o.Close,
                    PreClose = o.PreClose,
                    Change = o.Change,
                    ChangePercent = o.ChangePercent,
                    Vol = o.Vol,
                    Amount = o.Amount
                });

                //var destPrices = new StockPrice[i];
                //prices.CopyTo(0, destPrices, 0, i);
                
                var a = destPrices.ConvertCycle(Contracts.Enums.StockAnalysisCycle.WEEKLY);
                var b = destPrices.ConvertCycle(Contracts.Enums.StockAnalysisCycle.MONTHLY);
       
                weeklyPrices.Add(a.Last());
                monthlyPrices.Add(b.Last());        
                */
            }
            
            sw.Stop();
            messageCallback($"Generate weekly and monthly prices {sw.ElapsedMilliseconds} ms elapsed.=>W:{weeklyPrices.Count};M:{monthlyPrices.Count}");
            sw.Restart();

            weeklyPrices.SetsFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.WEEKLY}")
                .SaveFileOnDemand(weeklyPrices, out _);

            sw.Stop();
            messageCallback($"Save weekly prices {sw.ElapsedMilliseconds} ms elapsed.");
            sw.Restart();

            monthlyPrices.SetsFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.MONTHLY}")
                .SaveFileOnDemand(monthlyPrices, out _);

            sw.Stop();
            messageCallback($"Save monthly prices {sw.ElapsedMilliseconds} ms elapsed.");
            sw.Restart();

            var dailyLineOfPoint = prices.IndicatorLine(stock.Code);
            typeof(LineOfPoint)
            .LocalFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.DAILY}")
            .SaveFileOnDemand(dailyLineOfPoint, out _);

            sw.Stop();
            messageCallback($"Generate daily IndicatorLine,{sw.ElapsedMilliseconds} ms elapsed.=>{dailyLineOfPoint.EndPoints?.Count}");
            sw.Restart();

            var weeklyLineOfPoint = weeklyPrices.IndicatorLine(stock.Code);
            typeof(LineOfPoint)
            .LocalFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.WEEKLY}")
            .SaveFileOnDemand(weeklyLineOfPoint, out _);

            sw.Stop();
            messageCallback($"Generate weekly IndicatorLine,{sw.ElapsedMilliseconds} ms elapsed.=>{weeklyLineOfPoint.EndPoints?.Count}");
            sw.Restart();

            var monthlyLineOfPoint = monthlyPrices.IndicatorLine(stock.Code);
            typeof(LineOfPoint)
            .LocalFile($"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.MONTHLY}")
            .SaveFileOnDemand(monthlyLineOfPoint, out _);

            sw.Stop();
            messageCallback($"Generate monthly IndicatorLine,{sw.ElapsedMilliseconds} ms elapsed.=>{monthlyLineOfPoint.EndPoints?.Count}");
            sw.Restart();

            var d = dailyLineOfPoint.LineToSets();

            sw.Stop();
            messageCallback($"Daily Indicators LineToSets,{sw.ElapsedMilliseconds} ms elapsed.=>{d.Count}");
            sw.Restart();

            var w = weeklyLineOfPoint.LineToSets();

            var m = monthlyLineOfPoint.LineToSets();

            for (var index = 0; index < d.Count; index++)
            {
                var keys = d[index].SetKeys!.Select(o => $"{o}.{Contracts.Enums.StockAnalysisCycle.DAILY}");
                
                keys = keys.Union(w[index].SetKeys!.Select(o => $"{o}.{Contracts.Enums.StockAnalysisCycle.WEEKLY}"));
                
                keys = keys.Union(m[index].SetKeys!.Select(o => $"{o}.{Contracts.Enums.StockAnalysisCycle.MONTHLY}"));
                
                d[index].SetKeys = keys;
            }

            stock.Code.DataFile<StockSets>()
                .SaveFileOnDemand(d, out _);

            sw.Stop();
            messageCallback($"Merge LineToSets,{sw.ElapsedMilliseconds} ms elapsed.=>{d.Count}");
            sw.Restart();

            $"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.DAILY}"
                .DataFile<Diagram>()
                .SaveFileOnDemand(Reportor.CreateOnesCandlestickDiagram(stock, prices, dailyLineOfPoint), out _);

            $"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.WEEKLY}"
                .DataFile<Diagram>()
                .SaveFileOnDemand(Reportor.CreateOnesCandlestickDiagram(stock, weeklyPrices, weeklyLineOfPoint), out _);

            $"{stock.Code}.{Contracts.Enums.StockAnalysisCycle.MONTHLY}"
                .DataFile<Diagram>()
                .SaveFileOnDemand(Reportor.CreateOnesCandlestickDiagram(stock, monthlyPrices, monthlyLineOfPoint), out _);

            sw.Stop();
            messageCallback($"Create Diagrams,{sw.ElapsedMilliseconds} ms elapsed.");
            sw.Restart();

            var dic = new Dictionary<string, List<StockOperate>>();
            var profiles = Profiles();

            for (var index = 0; index < d.Count; index++)
            {
                if (d[index].MarkTime.Year <= DateTime.Now.Year - 2) continue;

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
                messageCallback($"Generate {kv.Key} operates and records : {kv.Value.Count} -> {rs.Count}");
            }

            sw.Stop();
            messageCallback($"Evaluate profiles,{sw.ElapsedMilliseconds} ms elapsed.");
            sw.Restart();

            sw = null;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
            messageCallback($"ERROR:{ex.Message}");
        }

        return true;
    }
}