//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Implements.Alpha.Extensions;
using Ban3.Infrastructures.Charts.Composites;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Ban3.Sites.ViaSina;
using Ban3.Sites.ViaTushare;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Implements.Alpha.Applications;

/// <summary>
/// 数据准备部分
/// </summary>
public partial class CasinoServer
{
    /// <summary>
    /// 准备标的
    /// </summary>
    /// <returns></returns>
    public bool PrepareStocks()
    {
        try
        {
            var codesResponse = new Sites.ViaTushare.Request.GetStockBasic().GetResult();
            var stocks = codesResponse.Data.ObjToJson().JsonToObj<List<Stock>>();
            if (stocks != null && stocks.Any())
            {
                var exists = LoadStocks();
                var newList = stocks.Where(o => exists.All(x => x.Code != o.Code)).ToList();
                newList.ForEach(x => { x.Suggest = SuggestIs.Skip; });
                exists.AddRange(newList);

                _databaseServer.SaveList<Stock>(exists);
            }

            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return false;
    }

    /// <summary>
    /// 准备所有标的分红解禁事件信息
    /// </summary>
    public void PrepareAllBonus()
    {
        var codes = LoadStocks();

        foreach (var c in codes.Where(o => o.Suggest != SuggestIs.Ignore))
        {
            PrepareOnesBonus(c);
            (3, 7).RandomDelay();
        }
    }

    /// <summary>
    /// 准备标的分红解禁事件信息
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public bool PrepareOnesBonus(Stock stock)
    {
        try
        {
            var a = new Sites.ViaSina.Request.DownloadEvents(stock.Symbol).GetResult();
            var b = new Sites.ViaSina.Request.DownloadLifts(stock.Symbol).GetResult();

            var all = a.Data.ObjToJson().JsonToObj<List<Bonus>>()
                 .Union(b.Data.ObjToJson().JsonToObj<List<Bonus>>())
                 .Where(o => o.MarkTime != null && o.MarkTime.Year > 1)
                 .ToList();

            return _databaseServer.SaveList<Bonus>(all, () => stock.Code);
        }
        catch (Exception ex) { _logger.Error(ex); }

        return false;
    }

    /// <summary>
    /// 收集所有标的行情数据
    /// </summary>
    /// <returns></returns>
    public bool CollectAllPrices()
    {
        var result = true;
        var codes = LoadStocks();

        foreach (var c in codes.Where(o => o.Suggest != SuggestIs.Ignore))
        {
            result = result && CollectOnesPrices(c);
        }

        return result;
    }

    public bool CollectRecentPrices(List<Stock> stocks)
    {
        return true;
    }

    /// <summary>
    /// 收集标的行情数据
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public bool CollectOnesPrices(Stock stock)
    {
        try
        {
            var prices = CollectAnyPrices(new List<string> { stock.Code }, 360);

            return _databaseServer.SaveList<Price>(prices, () => stock.Code);
        }
        catch (Exception ex) { _logger.Error(ex); }

        return false;
    }

    private List<Price> CollectAnyPrices(List<string> codes, int months)
        => CollectAnyPrices(codes, DateTime.Now.AddMonths(0 - months).ToYmd(), DateTime.Now.AddDays(1).ToYmd());

    private List<Price> CollectAnyPrices(List<string> codes, string startYmd, string endYmd)
    {
        var getDailyParams = new Sites.ViaTushare.Request.GetDailyParams(codes)
        {
            StartDate = startYmd,
            EndDate = endYmd
        };

        var pricesResult = new Sites.ViaTushare.Request.GetStockPrice(getDailyParams).GetResult();

        var prices = pricesResult.Data.ObjToJson().JsonToObj<List<Price>>().OrderBy(o => o.TradeDate).ToList();

        prices.ForEach(price => { price.MarkTime = price.TradeDate.ToDateTimeEx(); });

        return prices;
    }

    /// <summary>
    /// 计算所有标的复权因子
    /// </summary>
    /// <returns></returns>
    public bool CalculateAllSeeds()
    {
        var result = true;
        var codes = LoadStocks();

        foreach (var c in codes.Where(o => o.Suggest != SuggestIs.Ignore))
        {
            result = result && CalculateOnesSeeds(c);
        }

        return result;
    }

    /// <summary>
    /// 计算标的复权因子
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public bool CalculateOnesSeeds(Stock stock)
    {
        var result = new List<Reinstate>();
        try
        {
            var prices = LoadOnesPrices(stock, null);
            var events = LoadOnesBonus(stock);

            if (events.Any())
            {
                foreach (var e in events)
                {
                    if (prices.Any(o => o.MarkTime < e.MarkTime))
                    {
                        var price = prices.Last(o => o.MarkTime < e.MarkTime);

                        var thisSeed =
                            Math.Round(
                                price.Close * (1 + (Math.Round(e.Sbonus, 0) + Math.Round(e.Zbonus, 0)) / 10M +
                                         Math.Round(e.Pbonus, 0) / 10M) / (price.Close - e.Xmoney / 10M +
                                                                           Math.Round(e.Pbonus, 0) / 10M *
                                                                           Math.Round(e.Pprice, 2)), 4);

                        result.Add(new Reinstate { MarkTime = e.MarkTime, Factor = thisSeed });
                    }
                }
            }

            return _databaseServer.SaveList<Reinstate>(result, () => stock.Code);
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return false;
    }

    private Price ReinstateOnePrice(List<Reinstate>? seeds, Price price)
    {
        var newPrice = new Price
        {
            Code = price.Code,
            MarkTime = price.MarkTime,
            TradeDate = price.TradeDate,
            Change = price.Change,
            ChangePercent = price.ChangePercent,
            Volumn = price.Volumn,
            Amount = price.Amount,
            Open = price.Open,
            High = price.High,
            Low = price.Low,
            Close = price.Close,
            PreClose = price.PreClose
        };

        try
        {
            if (seeds != null && seeds.Any())
            {
                foreach (var s in seeds)
                {
                    if (s.MarkTime.Subtract(price.MarkTime).TotalDays > 0)
                    {
                        newPrice.Open = Math.Round(price.Open / s.Factor, 2);
                        newPrice.High = Math.Round(price.High / s.Factor, 2);
                        newPrice.Low = Math.Round(price.Low / s.Factor, 2);
                        newPrice.Close = Math.Round(price.Close / s.Factor, 2);
                        newPrice.PreClose = Math.Round(price.PreClose / s.Factor, 2);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return newPrice;
    }

    /// <summary>
    /// 计算标的复权价格(日线行情)
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public bool ReinstateOnesPrices(Stock stock)
    {
        try
        {
            var prices = LoadOnesPrices(stock, null);
            var factors = LoadOnesSeeds(stock);

            var dailyPrices = prices.Select(p => ReinstateOnePrice(factors, p)).ToList();

            return _databaseServer.SaveList<Price>(dailyPrices, () => $"{stock.Code}.{CycleIs.Daily}");
        }
        catch (Exception ex) { _logger.Error(ex); }

        return false;
    }

    /// <summary>
    /// 分析标的指标与特征值
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public bool AnalyzeOne(Stock stock)
    {
        try
        {
            var dailyPrices = _databaseServer.LoadList<Price>(typeof(Price), () => $"{stock.Code}.{CycleIs.Daily}");

            if (dailyPrices == null || !dailyPrices.Any())
            {
                _logger.Error(new ArgumentNullException($"{stock.Code} prices is empty now,Skip."));
                return false;
            }

            var result = new Result
            {
                Stock = stock,
                Suggest = SuggestIs.Skip,
                LatestPrice = dailyPrices.Last(),
                Remarks = new Alpha.Entries.CasinoServer.IndicatorParameter().GenerateRemarks(dailyPrices)
            }.GenerateSuggest();

            _databaseServer.Save<Diagram>(stock.Code, _chartServer.CandlestickDiagram(result));
            _databaseServer.Create<Result>(result, (_) => stock.Code);
            return true;
        }
        catch (Exception ex) { _logger.Error(ex); }

        return false;
    }

    /// <summary>
    /// 生成汇总报告
    /// </summary>
    /// <returns></returns>
    public bool GenerateSummary(List<Stock> stocks)
    {
        try
        {
            var summary = new Summary { MarkTime = DateTime.Now, Records = new List<TradeRecord>() };

            foreach (var stock in stocks)
            {
                var r = LoadResult(stock);
                var details = r.GenerateDetails();

                if (details.Any())
                {
                    summary.Records.Add(new TradeRecord
                    {
                        Code = r.Stock.Code,
                        LatestClose = r.LatestPrice.Close,
                        Details = details
                    });
                }
            }

            var latest=summary.Latest();

            _databaseServer.Save<Diagram>("all", _chartServer.TreemapDiagram(latest));

            _databaseServer.Create<Summary>(summary, (_) => "all");

            return true;
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return false;
    }
}
