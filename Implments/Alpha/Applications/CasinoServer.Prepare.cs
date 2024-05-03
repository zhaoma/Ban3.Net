﻿using Ban3.Implements.Alpha.Entries.CasinoServer;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Contracts.Entries.CasinoServer;
using Ban3.Infrastructures.Contracts.Enums.CasinoServer;
using Ban3.Sites.ViaSina;
using Ban3.Sites.ViaTushare;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Applications;

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
            return _databaseServer.SaveList<Stock>(stocks);
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

        foreach (var c in codes)
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
    public bool PrepareOnesBonus(IStock stock)
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

        foreach (var c in codes)
        {
            result = result && CollectOnesPrices(c);
        }

        return result;
    }

    /// <summary>
    /// 收集标的行情数据
    /// </summary>
    /// <param name="stock"></param>
    /// <returns></returns>
    public bool CollectOnesPrices(IStock stock)
    {
        try
        {
            var getDailyParams = new Sites.ViaTushare.Request.GetDailyParams(new List<string> { stock.Code })
            {
                StartDate = DateTime.Now.AddYears(-10).ToYmd(),
                EndDate = DateTime.Now.AddDays(1).ToYmd()
            };

            var pricesResult = new Sites.ViaTushare.Request.GetStockPrice(getDailyParams).GetResult();

            var prices = pricesResult.Data.ObjToJson().JsonToObj<List<Price>>();

            return _databaseServer.SaveList<Price>(prices, () => stock.Code);
        }
        catch (Exception ex) { _logger.Error(ex); }

        return false;
    }


    /// <summary>
    /// 计算所有标的复权因子
    /// </summary>
    /// <returns></returns>
    public bool CalculateAllSeeds()
    {
        var result = true;
        var codes = LoadStocks();

        foreach (var c in codes)
        {
            result = result && CalculateOnesSeeds(c);
        }

        return result;
    }

    /// <summary>
    /// 计算标的复权因子
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="events"></param>
    /// <returns></returns>
    public bool CalculateOnesSeeds(IStock stock)
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


    private Price ReinstateOnePrice(List<IReinstate>? seeds, IPrice price)
    {
        var newPrice = new Price
        {
            Code = price.Code,
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
    public bool ReinstateOnesPrices(IStock stock)
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
    public bool AnalyzeOne(IStock stock)
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
                Remarks = new IndicatorParameter().GenerateRemarks(dailyPrices)
            };

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
    public Task<bool> GenerateSummary()
    {
        try
        {
            var summary = new Summary { MarkTime = DateTime.Now, Results = new List<IResult>() };

            var stocks = LoadStocks();

            foreach (var stock in stocks)
            {
                var r = LoadResult(stock);
                summary.Results.Add(new Result
                {
                    Stock = r.Stock,
                    Suggest = r.Suggest,
                    Notices = r.Notices,
                });
            }

            _databaseServer.Create<Summary>(summary, (_) => "all");

            return Task.FromResult(true);
        }
        catch (Exception ex)
        {
            _logger.Error(ex);
        }

        return Task.FromResult(false);
    }

}
