﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaSina;
using Ban3.Sites.ViaSina.Request;
using Ban3.Sites.ViaTushare;
using Ban3.Sites.ViaTushare.Entries;
using Ban3.Sites.ViaTushare.Request;
using Ban3.Sites.ViaTushare.Response;
using StockPrice = Ban3.Sites.ViaTushare.Entries.StockPrice;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// 数据采集
/// </summary>
public static partial class Helper
{
    #region icons
    /*
    /// <summary>
    /// 云财经有防火墙规则
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    [Obsolete("云财经有防火墙规则")]
    public static bool DownloadAllIcons(this ISites _, List<Stock> allCodes = null)
    {
        var result = true;

        var local = allCodes ?? _.LoadAllCodes();

        local.ForEach(stock =>
        {
            var t = _.DownloadOnesIcon(stock.Code);
            var line = t ? "OK" : "FAILED";

            result = result && t;
            Logger.Debug($"download {stock.Code} icon : {line}");
            (3, 7).RandomDelay();
        });

        return result;
    }

    public static bool DownloadOnesIcon(this ISites _, string code)
    {
        var result = Sites.ViaYuncaijing.Helper
            .DownloadOneIcon(new DownloadOneIcon(code.GetStockPrefix(), code))
            .Result;

        return !string.IsNullOrEmpty(result.Path);
    }

    */
    #endregion

    #region codes
    /*
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    [Obsolete("tushare 数据更有用些,use PrepareAllCodesFromTushare")]
    public static bool PrepareAllCodesFromEastmoney(this ISites _, List<Stock> allCodes = null)
    {
        var codes = Sites.ViaEastmoney.Helper.DownloadAllCodes().Result.Data.Diff;

        var local = allCodes ?? _.LoadAllCodes();
        if (local != null)
        {
            local.AddRange(codes.FindAll(x => local.All(y => y.Code != x.Code)).Select(o => new Stock
            {
                Code = o.Code,
                Name = o.Name
            }));
        }
        else
        {
            local = codes.Select(o => new Stock
            {
                Code = o.Code,
                Name = o.Name
            }).ToList();
        }

        return !string.IsNullOrEmpty(
            local
                .SetsFile()
                .WriteFile(local.ObjToJson()));
    }
    */
    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool PrepareAllCodesFromTushare(this ISites _, List<Stock> allCodes = null)
    {
        var result = new GetStockBasic().GetResult();

        var local = allCodes ?? _.LoadAllCodes();
        if (local != null)
        {
            local.AddRange(result.Data.FindAll(x => local.All(y => y.Code != x.Code)).Select(o => new Stock
            {
                Code = o.Code,
                Symbol = o.Symbol,
                Name = o.Name,
                ListDate = o.ListDate
            }));
        }
        else
        {
            local = result.Data.Select(o => new Stock
            {
                Code = o.Code,
                Symbol = o.Symbol,
                Name = o.Name,
                ListDate = o.ListDate
            }).ToList();
        }

        return !string.IsNullOrEmpty(
            local.SetsFile()
                .WriteFile(local.ObjToJson())
        );
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    public static List<Stock> LoadAllCodes(this ISites _)
        => Config.CacheKey<Stock>("all").LoadOrSetDefault<List<Stock>>(typeof(Stock).LocalFile());

    #endregion

    #region daily prices

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="tsCodes"></param>
    /// <param name="startDate"></param>
    /// <param name="endDate"></param>
    /// <returns></returns>
    public static GetStockPriceResult GetDailyPrices(this ISites _, List<string> tsCodes, string startDate, string endDate)
    {
        var getDailyParams = new GetDailyParams(tsCodes)
        {
            StartDate = startDate,
            EndDate = endDate
        };

        return new GetStockPrice(getDailyParams).GetResult();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="tsCodes"></param>
    /// <param name="dateRange"></param>
    /// <returns></returns>
    public static GetStockPriceResult GetDailyPrices(this ISites _, List<string> tsCodes, DateRange dateRange)
        => _.GetDailyPrices(tsCodes, dateRange.StartDate, dateRange.EndDate);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static bool PrepareOnesDailyPrices(this ISites _, string code)
    {
        var result = false;
        var prices = new List<StockPrice>();

        var freq = 0;

        var r = _.GetDailyPrices(new List<string> { code }, new DateRange(10, freq));
        while (r != null && r.Data.Any())
        {
            prices = prices.Union(r.Data).ToList();

            freq++;
            r = _.GetDailyPrices(new List<string> { code }, new DateRange(10, freq));
        }

        if (prices.Any())
        {
            var savedPath = prices.SetsFile(code)
                .WriteFile(prices.OrderBy(o => o.TradeDate).ObjToJson());
            result = !string.IsNullOrEmpty(savedPath);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool PrepareAllDailyPrices(this ISites _, List<Stock> allCodes = null)
    {
        allCodes ??= _.LoadAllCodes();
        var result = true;

        allCodes.ForEach(stock => { result = result && _.PrepareOnesDailyPrices(stock.Code); });
        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool FixAllDailyPrices(this ISites _, List<Stock> allCodes = null)
    {
        allCodes ??= _.LoadAllCodes();
        var result = true;

        var page = 1;
        var codes = allCodes
            .Take(Config.FixPageSize)
            .Select(o => o.Code)
            .ToList();

        while (codes.Any())
        {
            result = result && _.FixAllDailyPrices(codes);

            page++;
            codes = allCodes
                .Skip((page - 1) * Config.FixPageSize)
                .Take(Config.FixPageSize)
                .Select(o => o.Code)
                .ToList();
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="codes"></param>
    /// <returns></returns>
    public static bool FixAllDailyPrices(this ISites _, List<string> codes)
    {
        var result = true;

        try
        {
            var ps = _.GetDailyPrices(codes, new DateRange(Config.FixDailyPrices));
            if (ps != null && ps.Data.Any())
            {
                var gotCodes = ps.Data.Select(o => o.Code)
                    .GroupBy(o => o)
                    .Select(o => o.Key)
                    .ToList();

                foreach (var code in gotCodes)
                {
                    try
                    {
                        var exists = _.LoadOnesDailyPrices(code) ?? new List<StockPrice>();

                        var newList = ps.Data.FindAll(o => o.Code == code);
                        /*
                        newList = newList.Where(x => exists.All(y => y.TradeDate != x.TradeDate)).ToList();

                        exists = exists.Union(newList)
                            .Where(o => o.Close != 0)
                            .Distinct(o => o)
                            .OrderBy(o => o.TradeDate)
                            .ToList();
                        */

                        newList.ForEach(p =>
                        {
                            var r = exists.FindLast(o => o.TradeDate.Equals(p.TradeDate));
                            if (r != null)
                            {
                                r = p;
                            }
                            else
                            {
                                exists.Add(p);
                            }
                        });

                        var savedPath = exists.SetsFile(code)
                            .WriteFile(exists.OrderBy(o => o.TradeDate).ObjToJson());

                        result = result && !string.IsNullOrEmpty(savedPath);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error(code);
                        Logger.Error(ex);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockPrice> LoadOnesDailyPrices(this ISites _, string code)
    {
        return typeof(StockPrice)
            .LocalFile(code)
            .ReadFileAs<List<StockPrice>>();
    }

    #endregion

    #region events

    /// 
    public static bool PrepareOnesEvents(this ISites _, string symbol)
    {
        var result = false;
        var events = new List<StockEvent>();
        var getEvents = new DownloadEvents(symbol).GetResult();
        if (getEvents.Data.Any())
        {
            events = events.Union(getEvents.Data.Select(o => new StockEvent(o))).ToList();
        }

        var getLifts = new DownloadLifts(symbol).GetResult();
        if (getLifts.Data.Any())
        {
            events = events.Union(getLifts.Data.Select(o => new StockEvent(o))).ToList();
        }

        if (events.Any())
        {
            var savedPath = events.SetsFile(symbol)
                .WriteFile(events.OrderBy(o => o.MarkTime).ObjToJson());
            result = !string.IsNullOrEmpty(savedPath);
        }

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static bool PrepareAllEvents(this ISites _, List<Stock> allCodes = null)
    {
        allCodes ??= _.LoadAllCodes();
        var result = true;

        allCodes.ForEach(o =>
        {
            var targetFileInfo = new FileInfo(typeof(StockEvent).LocalFile(o.Symbol));

            if (DateTime.Now.ToYmd().ToInt() - targetFileInfo.LastWriteTime.ToYmd().ToInt() >= 2)
            {
                Console.WriteLine(o.Code);
                result = result && _.PrepareOnesEvents(o.Symbol);
                (3, 7).RandomDelay();
            }
            else
            {
                Console.WriteLine($"{o.Code} Skipped.");
            }
        });

        return result;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="symbol"></param>
    /// <returns></returns>
    public static List<StockEvent> LoadOnesEvents(this ISites _, string symbol)
    {
        return typeof(StockEvent)
            .LocalFile(symbol)
            .ReadFileAs<List<StockEvent>>();
    }


    #endregion

    #region realtime prices
    /*
    /// <summary>
    /// 网易实时接口失效后，暂无合适的实时行情接口
    /// </summary>
    /// <param name="_"></param>
    /// <param name="allCodes"></param>
    /// <returns></returns>
    public static async Task<bool> ReadRealtime(this ISites _, List<Stock> allCodes = null)
    {
        try
        {
            allCodes ??= _.LoadAllCodes();

            var p = 1;
            //var total = allCodes.Count % Config.FixPageSize > 0 ? allCodes.Count / Config.FixPageSize + 1 : allCodes.Count / Config.FixPageSize;
            var codes = allCodes.Take(Config.FixPageSize).ToList();

            while (codes.Any())
            {
                var targets = codes.Select(o => (o.Symbol.GetStockNumPrefix(), o.Symbol)).ToList();
                //Logger.Debug($"{p}/{total} - ; {allCodes.Count}");
                var rs = await Sites.ViaNetease.Helper.ReadRealtimePrices(new ReadRealTime(targets));

                rs.Data.AsParallel()
                    .ForAll(o =>
                    {
                        var c = codes.FindLast(x => x.Symbol == o.Value.Symbol);
                        var prices = _.LoadOnesDailyPrices(c.Code);
                        var existsPrice = prices.FindLast(x => x.TradeDate == o.Value.Time.ToYmd());
                        if (existsPrice == null)
                        {
                            prices.Add(new StockPrice
                            {
                                Code = c.Code,
                                TradeDate = o.Value.Time.ToYmd(),
                                Open = (float)o.Value.Open,
                                High = (float)o.Value.Open,
                                Low = (float)o.Value.Open,
                                Close = (float)o.Value.Open,
                                PreClose = (float)o.Value.Open,
                                Change = (float)o.Value.UpDown,
                                ChangePercent = (float)o.Value.Percent * 100,
                                Vol = (float)o.Value.Volume,
                                Amount = (float)o.Value.TurnOver
                            });
                        }
                        else
                        {
                            existsPrice.Open = (float)o.Value.Open;
                            existsPrice.PreClose = (float)o.Value.YestClose;
                            existsPrice.High = Math.Max(existsPrice.High, (float)o.Value.High);
                            existsPrice.Low = Math.Min(existsPrice.Low, (float)o.Value.Low);
                            existsPrice.Vol = (float)o.Value.Volume;
                            existsPrice.Close = (float)o.Value.Price;
                            existsPrice.Amount = (float)o.Value.TurnOver;
                        }

                        prices.SetsFile(c.Code)
                            .WriteFile(prices.OrderBy(x => x.TradeDate).ObjToJson());

                    });

                new Action(() => StockRealtime.Append(rs.Data)).Invoke();//.ExecuteAndTiming("sync to realtime dic");
                p++;
                codes = allCodes.Skip((p - 1) * Config.FixPageSize).Take(Config.FixPageSize).ToList();
            }

            return true;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return false;
    }
    */
    #endregion
}