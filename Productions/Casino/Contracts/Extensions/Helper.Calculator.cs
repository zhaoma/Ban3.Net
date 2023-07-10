using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Productions.Casino.Contracts.Extensions;

/// <summary>
/// ICollector 扩展方法，计算相关
/// </summary>
public static partial class Helper
{
    #region 计算/加载复权因子

    /// <summary>
    /// 计算复权因子
    /// </summary>
    /// <param name="_"></param>
    /// <param name="prices"></param>
    /// <param name="events"></param>
    /// <returns></returns>
    public static List<StockSeed> CalculateSeeds(this ICalculator _, List<StockPrice> prices, List<StockEvent> events)
    {
        var result = new List<StockSeed>();
        try
        {
            if (events.Any())
            {
                foreach (var e in events)
                {
                    var price = prices.Last(o => o.TradeDate.ToDateTimeEx() < e.MarkTime);
                    {
                        var close = (decimal)price.Close;

                        var thisSeed =
                            Math.Round(
                                close * (1 + (Math.Round(e.Sbonus, 0) + Math.Round(e.Zbonus, 0)) / 10M +
                                         Math.Round(e.Pbonus, 0) / 10M) / (close - e.Xmoney / 10M +
                                                                           Math.Round(e.Pbonus, 0) / 10M *
                                                                           Math.Round(e.Pprice, 2)), 4);

                        result.Add(new StockSeed { MarkTime = e.MarkTime, Seed = (float)thisSeed });
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
    
    #endregion

    #region 计算/加载复权价格

    /// <summary>
    /// 计算复权价格
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <param name="symbol"></param>
    /// <param name="prices"></param>
    /// <returns></returns>
    public static bool ReinstatePrices(
        this ICalculator _,
        string code,
        string symbol,
        List<StockPrice> prices)
    {
        if (prices == null || !prices.Any()) return false;

        try
        {
            var seeds = symbol.LoadEntities<StockSeed>();

            prices.Select(seeds.ReinstateOnePrice)
                .ToList()
                .SaveEntities($"{code}.{StockAnalysisCycle.DAILY}");
            
            return true;
        }
        catch (Exception ex)
        {
            Logger.Error($"ReinstatePrices {code}");
            Logger.Error(ex);
        }

        return false;
    }

    static StockPrice ReinstateOnePrice(this List<StockSeed> seeds, StockPrice price)
    {
        var newPrice = new StockPrice
        {
            Code = price.Code,
            TradeDate = price.TradeDate,
            Change = price.Change,
            ChangePercent = price.ChangePercent,
            Vol = price.Vol,
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
                    if (s.MarkTime.Subtract(price.TradeDate.ToDateTimeEx()).TotalDays > 0)
                    {
                        newPrice.Open = (float)Math.Round(price.Open / s.Seed, 2);
                        newPrice.High = (float)Math.Round(price.High / s.Seed, 2);
                        newPrice.Low = (float)Math.Round(price.Low / s.Seed, 2);
                        newPrice.Close = (float)Math.Round(price.Close / s.Seed, 2);
                        newPrice.PreClose = (float)Math.Round(price.PreClose / s.Seed, 2);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return newPrice;
    }

    /// <summary>
    /// 加载复权价格
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public static List<StockPrice> LoadReinstatedPrices(this ICalculator _, string code, StockAnalysisCycle cycle)
        => $"{code}.{cycle}".LoadEntities<StockPrice>();

    public static List<Price> LoadPricesForIndicators(this ICalculator _, string code, StockAnalysisCycle cycle)
        => $"{code}.{cycle}".DataFile<StockPrice>().ReadFileAs<List<Price>>();

    #endregion
    
    /// <summary>
    /// 对dots of buying or selling main table按照RenderView筛选
    /// </summary>
    /// <param name="dots"></param>
    /// <param name="request"></param>
    /// <returns></returns>
    public static List<DotInfo> ExtendedDots(
        this Dictionary<string, List<DotInfo>> dots,
        RenderView request)
    {
        var result = new List<DotInfo>();

        foreach (var keyValuePair in dots)
        {
            keyValuePair.Value.ForEach(o => o.Code = keyValuePair.Key);
            result.AddRange(keyValuePair.Value);
        }

        if (request != null)
        {
            result = result
                .Where(o =>DotFilter(o,request))
                .OrderByDescending(o => o.TradeDate)
                .ThenByDescending(o => o.Code)
                .ToList();
        }

        return result;
    }
    
    public static List<StockSets> LoadAllLatestSets(this ICalculator _)
    {
        var file = $"latest".DataFile<StockSets>();

        return Config.CacheKey<StockSets>("latest")
            .LoadOrSetDefault<List<StockSets>>(file);
    }

    public static List<StockSets> ScopedByRenderView(
        this ICalculator _,
        RenderView request)
    {
        var targets= _.LoadAllLatestSets();
        if (request != null)
        {
            if (!string.IsNullOrEmpty(request.IncludeKeys) || !string.IsNullOrEmpty(request.ExcludeKeys))
            {
                if (!string.IsNullOrEmpty(request.IncludeKeys))
                {
                    targets = targets.Where(o => o.SetKeys.AllFoundIn(request.IncludeKeys.Split(','))).ToList();
                }

                if (!string.IsNullOrEmpty(request.ExcludeKeys))
                {
                    targets = targets.Where(o => o.SetKeys.NotFoundIn(request.ExcludeKeys.Split(','))).ToList();
                }
            }

            targets = targets
                .Where(o => StrFilter(o.Code,request))
                .OrderByDescending(o => o.Code)
                .ThenByDescending(o => o.MarkTime)
                .ToList();
        }

        return targets;
    }
}