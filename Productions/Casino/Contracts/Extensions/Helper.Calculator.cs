using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Entries;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Infrastructures.RuntimeCaching;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Enums;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Productions.Casino.Contracts.Request;
using Ban3.Productions.Casino.Contracts.Response;
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

    /// <summary>
    /// 加载复权因子
    /// </summary>
    /// <param name="_"></param>
    /// <param name="symbol"></param>
    /// <returns></returns>
    public static List<StockSeed> LoadSeeds(this ICalculator _, string symbol)
        => typeof(StockSeed)
            .LocalFile(symbol)
            .ReadFileAs<List<StockSeed>>();

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

        var seeds = _.LoadSeeds(symbol);

        // if (seeds == null || !seeds.Any()) return false;

        var newPrices = prices.Select(seeds.ReinstateOnePrice)
            .ToList();

        var savedDaily = newPrices.SetsFile($"{code}.{StockAnalysisCycle.DAILY}")
            .WriteFile(newPrices.ObjToJson());

        var weeklyPrices = newPrices.ConvertCycle(StockAnalysisCycle.WEEKLY);
        var savedWeekly = weeklyPrices.SetsFile($"{code}.{StockAnalysisCycle.WEEKLY}")
            .WriteFile(weeklyPrices.ObjToJson());

        var monthlyPrices = newPrices.ConvertCycle(StockAnalysisCycle.MONTHLY);
        var savedMonthly = monthlyPrices.SetsFile($"{code}.{StockAnalysisCycle.MONTHLY}")
            .WriteFile(monthlyPrices.ObjToJson());

        return !string.IsNullOrEmpty(savedDaily)
               && !string.IsNullOrEmpty(savedWeekly)
               && !string.IsNullOrEmpty(savedMonthly);
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
        => typeof(StockPrice)
            .LocalFile($"{code}.{cycle}")
            .ReadFileAs<List<StockPrice>>();

    #endregion

    #region 计算/加载指标曲线

    /// <summary>
    /// 计算指标曲线 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static bool GenerateIndicatorLine(this ICalculator _, string code)
    {
        return _.GenerateIndicatorLine(code, StockAnalysisCycle.DAILY)
               && _.GenerateIndicatorLine(code, StockAnalysisCycle.WEEKLY)
               && _.GenerateIndicatorLine(code, StockAnalysisCycle.MONTHLY);
    }

    static bool GenerateIndicatorLine(this ICalculator _, string code, StockAnalysisCycle cycle)
    {
        var prices = _.LoadReinstatedPrices(code, cycle);
        if (prices == null || !prices.Any()) return false;

        var inputsPrices = prices.Select(o => new Infrastructures.Indicators.Inputs.Price
        {
            MarkTime = o.TradeDate.ToDateTimeEx(),
            CloseBefore = (decimal)o.PreClose,
            CurrentOpen = (decimal)o.Open,
            CurrentClose = (decimal)o.Close,
            CurrentHigh = (decimal)o.High,
            CurrentLow = (decimal)o.Low,
            Volume = (decimal)o.Vol,
            Amount = (decimal)o.Amount
        }).ToList();

        var indicator = new Infrastructures.Indicators.Formulas.Full();
        indicator.Calculate(inputsPrices, code);

        var line = indicator.Result;
        var saved = typeof(LineOfPoint)
            .LocalFile($"{code}.{cycle}")
            .WriteFile(line.ObjToJson());
        return !string.IsNullOrEmpty(saved);
    }

    /// <summary>
    /// 加载指标曲线 
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    public static LineOfPoint LoadIndicatorLine(this ICalculator _, string code, StockAnalysisCycle cycle)
        => typeof(LineOfPoint)
            .LocalFile($"{code}.{cycle}")
            .ReadFileAs<LineOfPoint>();

    /// <summary>
    /// 指标值线转换点
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static List<Latest> LatestList(this LineOfPoint line)
    {
        if (line is { EndPoints: { } } && !line.EndPoints.Any()) return null;

        var list = line?.EndPoints?.Select(o => new Latest
        {
            Current = o
        }).ToList();

        for (var i = 1; i < list?.Count; i++)
        {
            list[i].Prev = list[i - 1].Current;
        }

        return list;
    }

    #endregion

    #region 计算/加载特征集合

    /// <summary>
    /// 计算特征集合
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stock"></param>
    /// <param name="sets"></param>
    /// <returns></returns>
    public static bool PrepareSets(
        this ICalculator _,
        Stock stock,
        out List<StockSets> sets)
    {
        try
        {
            var prices = _.LoadReinstatedPrices(stock.Code, StockAnalysisCycle.DAILY);
            if (prices != null && prices.Any())
            {
                sets = prices.Select(o => new StockSets
                {
                    Close = (decimal)o.Close,
                    MarkTime = o.TradeDate.ToDateTimeEx(),
                    Code = stock.Code,
                    Symbol = stock.Symbol,
                    SetKeys = new List<string>()
                }).ToList();

                sets = _.Merge(sets, stock.Code);

                var saved = $"{stock.Code}"
                    .DataFile<StockSets>()
                    .WriteFile(sets.ObjToJson());

                return !string.IsNullOrEmpty(saved);
            }
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        sets = new List<StockSets>();
        return false;
    }

    static List<StockSets> Merge(
        this ICalculator _, List<StockSets> sets, string code)
    {
        sets = _.Merge(sets, code, StockAnalysisCycle.DAILY);
        sets = _.Merge(sets, code, StockAnalysisCycle.WEEKLY);
        sets = _.Merge(sets, code, StockAnalysisCycle.MONTHLY);

        return sets;
    }

    static List<StockSets> Merge(
        this ICalculator _, List<StockSets> sets, string code, StockAnalysisCycle cycle)
    {
        return sets.Merge(_.LoadIndicatorLine(code, cycle), cycle);
    }

    /// <summary>
    /// 指标特征集合并日/周/月指标特征集
    /// </summary>
    /// <param name="sets"></param>
    /// <param name="indicatorValue"></param>
    /// <param name="cycle"></param>
    /// <returns></returns>
    static List<StockSets> Merge(
        this List<StockSets> sets,
        LineOfPoint indicatorValue,
        StockAnalysisCycle cycle)
    {
        try
        {
            if (!sets.Any()) return sets;

            var setsList = indicatorValue.LineToSets();

            sets.ForEach(o =>
            {
                var ss = setsList.FirstOrDefault(x => x.MarkTime.Subtract(o.MarkTime).TotalDays >= 0);
                if (ss is { SetKeys: { } } && ss.SetKeys.Any())
                {
                    o.SetKeys = o.SetKeys?.Union(ss.SetKeys.Select(y => $"{y}.{cycle}"));
                }
            });
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return sets;
    }

    public static List<StockSets> LineToSets(this LineOfPoint indicatorValue)
    {
        var latestList = indicatorValue
            .LatestList();

        if (latestList == null || !latestList.Any()) return new List<StockSets>();

        return latestList
             .Select(o => new StockSets
             {
                 MarkTime = o.Current!.MarkTime,
                 Close = o.Current.Close,
                 SetKeys = o.Features()
             })
             .OrderBy(o => o.MarkTime)
             .ToList();
    }

    /// <summary>
    /// 加载特征集合
    /// </summary>
    /// <param name="_"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static List<StockSets> LoadSets(this ICalculator _, string code)
        => code
            .DataFile<StockSets>()
            .ReadFileAs<List<StockSets>>();

    #endregion

    #region 计算/加载个股榜单

    /// <summary>
    /// 指标特征集转换榜单
    /// </summary>
    /// <param name="stockSets"></param>
    /// <param name="listName"></param>
    /// <returns></returns>
    public static bool GenerateList(this List<StockSets> stockSets, string listName)
    {
        var result = stockSets
            .Where(o => o.SetKeys != null && o.SetKeys.Any())
            .Select(o => new ListRecord(o))
            .OrderByDescending(o => o.Value)
            .ToList();

        var rank = 1;
        int? prev = null;
        foreach (var r in result)
        {
            if (prev == null || r.Value == prev.Value)
            {
                r.Rank = rank;
            }
            else
            {
                rank++;
                r.Rank = rank;
            }

            prev = r.Value;
        }
        "latest".DataFile<ListRecord>()
            .WriteFile(result.ObjToJson());

        var saved = listName
            .DataFile<ListRecord>()
            .WriteFile(result.ObjToJson());

        return !string.IsNullOrEmpty(saved);
    }

    /// <summary>
    /// 加载个股榜单
    /// </summary>
    /// <param name="_"></param>
    /// <param name="listName"></param>
    /// <returns></returns>
    public static List<ListRecord> LoadList(this ICalculator _, string listName="latest")
        =>Config.CacheKey<ListRecord>(listName)
            .LoadOrSetDefault<List<ListRecord>>( listName .DataFile<ListRecord>());

    #endregion

    #region 计算/加载特征热力图

    /// <summary>
    /// 计算特征热力图
    /// </summary>
    /// <param name="_"></param>
    /// <param name="stocks"></param>
    /// <param name="filter"></param>
    /// <param name="targetsResult"></param>
    /// <returns></returns>
    public static bool PrepareFocus(
        this ICalculator _,
        List<Stock> stocks,
        FocusFilter filter,
        out FocusFilterResult targetsResult)
    {
        var result = new FocusFilterResult();

        stocks.ParallelExecute((stock) =>
        {
            var target = _.ParseFocusTarget(filter, stock);
            if (target != null)
            {
                result.Append(stock.Code, target);
            }
        }, Config.MaxParallelTasks);

        var saved = filter.Identity.DataFile<FocusTarget>()
            .WriteFile(result.Targets.ObjToJson());

        targetsResult = result;
        return string.IsNullOrEmpty(saved);
    }

    /// <summary>
    /// 计算个股特征热力图
    /// </summary>
    /// <param name="_"></param>
    /// <param name="filter"></param>
    /// <param name="stock"></param>
    /// <returns></returns>
    public static FocusTarget ParseFocusTarget(
        this ICalculator _,
        FocusFilter filter,
        Stock stock)
    {
        var one = new FocusTarget()
        {
            Name = stock.Name,
            Symbol = stock.Symbol,
            Days = _.ParseFocusData(filter, stock, StockAnalysisCycle.DAILY),
            Weeks = _.ParseFocusData(filter, stock, StockAnalysisCycle.WEEKLY),
            Months = _.ParseFocusData(filter, stock, StockAnalysisCycle.MONTHLY)
        };

        if (one.Days != null || one.Weeks != null || one.Months != null)
        {
            return one;
        }

        return null;
    }

    static FocusData ParseFocusData(
        this ICalculator _,
        FocusFilter filter,
        Stock stock,
        StockAnalysisCycle cycle)
    {
        var data = new FocusData();

        var prices = _.LoadReinstatedPrices(stock.Code, cycle);

        if (prices == null || !prices.Any()) return null;

        prices = prices
            .Where(o => DateTime.Now.Subtract(o.TradeDate.ToDateTimeEx()).TotalDays <= 250)
            .ToList();

        var line = _.LoadIndicatorLine(stock.Code, cycle);
        if (line?.EndPoints == null || !line.EndPoints.Any()) return null;

        var sets = line
            .LatestList()
            .Select(o => new StockSets
            {
                MarkTime = o.Current!.MarkTime, Close = o.Current.Close,
                SetKeys = o.Features().Select(y => $"{y}.{cycle}")
            })
            .ToList();

        data.Total = prices.Count;
        for (var i = 0; i < prices.Count; i++)
        {
            try
            {
                if (filter.IsMatch(prices[i].ChangePercent, cycle, out var buying))
                {
                    data.Current.Add(new FocusRecord(prices[i])
                    {
                        SetKeys = sets.GetSets(prices[i].TradeDate)
                    });

                    if (i > 0)
                        data.Previous.Add(new FocusRecord(prices[i - 1])
                        {
                            SetKeys = sets.GetSets(prices[i - 1].TradeDate)
                        });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR:{ex.Message}");
                Console.WriteLine(prices[i].ObjToJson());
                Logger.Error(ex);
            }
        }

        return data;
    }

    /// <summary>
    /// 获取指定日期的特征集合
    /// </summary>
    /// <param name="sets"></param>
    /// <param name="tradeDate"></param>
    /// <returns></returns>
    public static List<string> GetSets(this List<StockSets> sets, string tradeDate)
    {
        var s = sets.Last(o => o.MarkTime.ToYmd() == tradeDate);
        if (s is { SetKeys: { } })
            return s.SetKeys.ToList();

        return null;
    }

    public static Dictionary<string, FocusTarget> LoadFocus(this ICalculator _, FocusFilter filter)
        => filter.Identity
            .DataFile<FocusTarget>()
            .ReadFileAs<Dictionary<string, FocusTarget>>();

    public static Dictionary<string, int> KeysDictionary(this List<FocusRecord> records)
    {
        var result = new Dictionary<string, int>();

        records.ForEach(x => { result.AppendKeys(x.SetKeys); });

        return result;
    }

    static void AppendKeys(this Dictionary<string, int> dic, IEnumerable<string> keys)
    {
        foreach (var o in keys)
        {
            if (dic.ContainsKey(o))
            {
                dic[o] += 1;
            }
            else
            {
                dic.Add(o, 1);
            }
        }
    }

    public static Dictionary<string, int> MergeToDictionary(this IEnumerable<IEnumerable<string>> keys)
    {
        var dic = new Dictionary<string, int>();
        foreach(var list in keys) {
            dic.AppendKeys(list);
	    }

        return dic;
    }

    static Dictionary<string, int> Merge(this Dictionary<string, int> dic, Dictionary<string, int> addDic)
    {
        if (addDic != null)
        {

            foreach (var i in addDic)
            {
                if (dic.ContainsKey(i.Key))
                {
                    dic[i.Key] += 1;
                }
                else
                {
                    dic.Add(i.Key, 1);
                }
            }
        }

        return dic;
    }

    public static Dictionary<string, int> MergePrevious(this IEnumerable<FocusTarget> targets)
    {
        var dic = new Dictionary<string, int>();
        foreach (var focusTarget in targets)
        {
            dic = dic.Merge(focusTarget.Days?.PreviousKeys());
            dic = dic.Merge(focusTarget.Weeks?.PreviousKeys());
            dic = dic.Merge(focusTarget.Months?.PreviousKeys());
        }
        return dic;
    }

    public static Dictionary<string, int> MergeCurrent(this IEnumerable<FocusTarget> targets)
    {
        var dic = new Dictionary<string, int>();
        foreach (var focusTarget in targets)
        {
            dic = dic.Merge(focusTarget.Days?.CurrentKeys());
            dic = dic.Merge(focusTarget.Weeks?.CurrentKeys());
            dic = dic.Merge(focusTarget.Months?.CurrentKeys());
        }

        return dic;
    }

    #endregion

    #region 计算/加载买卖位置

    /// <summary>
    /// 计算买卖位置
    /// </summary>
    /// <param name="_"></param>
    /// <param name="filter"></param>
    /// <param name="stocks"></param>
    /// <param name="dic"></param>
    /// <returns></returns>
    public static bool PrepareDots(
        this ICalculator _,
        FocusFilter filter,
        List<Stock> stocks,
	    out DotOfBuyingOrSelling dic
    )
    {
        var result= new DotOfBuyingOrSelling();

        stocks.ForEach(o =>
        {
            var dots = _.GetOnesDots(filter, o);
            if (dots != null && dots.Any())
                result.Add(o.Code, dots);
        });

        var saved = typeof(DotOfBuyingOrSelling)
            .LocalFile(filter.Identity)
            .WriteFile(result.ObjToJson());

        dic = result;
        return !string.IsNullOrEmpty(saved);
    }

    public static List<DotInfo> GetOnesDots(
        this ICalculator _, 
        FocusFilter filter, 
	    Stock stock)
    {
        var prices = _.LoadReinstatedPrices(stock.Code, StockAnalysisCycle.DAILY);

        if (prices == null || !prices.Any()) return new List<DotInfo>();

        prices = prices
            .Where(o => DateTime.Now.Subtract(o.TradeDate.ToDateTimeEx()).TotalDays <= 250)
            .ToList();

        return prices.DotsOfBuyingOrSelling(filter);
    }


    public static List<DotInfo> DotsOfBuyingOrSelling(this List<StockPrice> prices, FocusFilter filter)
    {
        if (prices == null || !prices.Any()) return new List<DotInfo>();

        var result = new List<DotInfo>();
        for (var i = 0; i < prices.Count; i++)
        {
            if ( prices.GetDayDot(filter, i, out var dotForDay))
            {
                result.Add(dotForDay);
            }

            if (prices.GetWeekDot(filter, i, out var dotForWeek))
            {
                result.Add(dotForWeek);
                i = i + dotForWeek.Days;
            }

            if (prices.GetMonthDot(filter, i, out var dotForMonth))
            {
                result.Add(dotForMonth);
                i = i + dotForMonth.Days;
            }
        }

        return result;
    }

    static bool GetDayDot(this List<StockPrice> prices, FocusFilter filter, int i, out DotInfo dot)
    {
        var current = prices[i];

        if (prices.Count > i + 1)
        {
            var nextDay = prices[i + 1];
            if (filter.IsMatch(nextDay.ChangePercent, StockAnalysisCycle.DAILY, out var isDotOfBuying))
            {
                dot = new DotInfo
                {
                    Cycle = StockAnalysisCycle.DAILY,
                    IsDotOfBuying = isDotOfBuying,
                    TradeDate = current.TradeDate,
                    Days = 1,
                    ChangePercent = nextDay.ChangePercent,
                    Close = nextDay.Close
                };
                return true;
            }
        }

        dot = null;
        return false;
    }

    static bool GetWeekDot(this List<StockPrice> prices, FocusFilter filter, int i, out DotInfo dot)
    {
        var current = prices[i];

        dot = null;

        if (prices.Count == i + 1) return false;

        var len = Math.Min(5, prices.Count - i - 1);
        if (len <= 0) return false;
        var week = new StockPrice[len];
        prices.CopyTo(i + 1, week, 0, len);

        if ( !week.Any()) return false;

        var max = week.Max(o => o.Close);
        var min = week.Min(o => o.Close);

        if (max > current.Close)
        {
            var plus = (max - current.Close) / current.Close * 100F;
            if (filter.IsMatch(plus, StockAnalysisCycle.WEEKLY, out var isDotOfBuying))
            {
                if (week.FindIndexOfValue(max, ge: true, baseline: current.Close, out var index))
                {
                    dot = new DotInfo
                    {
                        Cycle = StockAnalysisCycle.WEEKLY,
                        IsDotOfBuying = isDotOfBuying,
                        TradeDate = current.TradeDate,
                        Days = index,
                        ChangePercent = plus,
                        Close = max
                    };
                    return true;
                }
            }
        }

        if (min < current.Close)
        {
            var minus = (min - current.Close) / current.Close * 100F;
            if (filter.IsMatch(minus, StockAnalysisCycle.WEEKLY, out var isDotOfBuying))
            {
                if (week.FindIndexOfValue(max, ge: false, baseline: current.Close, out var index))
                {
                    dot = new DotInfo
                    {
                        Cycle = StockAnalysisCycle.WEEKLY,
                        IsDotOfBuying = isDotOfBuying,
                        TradeDate = current.TradeDate,
                        Days = index,
                        ChangePercent = minus,
                        Close = max
                    };
                    return true;
                }
            }
        }

        return false;
    }

    static bool GetMonthDot(this List<StockPrice> prices, FocusFilter filter, int i, out DotInfo dot)
    {

        var current = prices[i];

        dot = null;

        if (prices.Count == i + 1) return false;

        var len = Math.Min(20, prices.Count - i - 1);
        if (len <= 0) return false;
        var month = new StockPrice[len];
        prices.CopyTo(i + 1, month, 0, len);

        if (!month.Any()) return false;

        var max = month.Max(o => o.Close);
        var min = month.Min(o => o.Close);

        if (max > current.Close)
        {
            var plus = (max - current.Close) / current.Close * 100F;
            if (filter.IsMatch(plus, StockAnalysisCycle.MONTHLY, out var isDotOfBuying))
            {
                if (month.FindIndexOfValue(max, ge: true, baseline: current.Close, out var index))
                {
                    dot = new DotInfo
                    {
                        Cycle = StockAnalysisCycle.MONTHLY,
                        IsDotOfBuying = isDotOfBuying,
                        TradeDate = current.TradeDate,
                        Days = index,
                        ChangePercent = plus,
                        Close = max
                    };
                    return true;
                }
            }
        }

        if (min < current.Close)
        {
            var minus = (min - current.Close) / current.Close * 100F;
            if (filter.IsMatch(minus, StockAnalysisCycle.MONTHLY, out var isDotOfBuying))
            {
                if (month.FindIndexOfValue(max, ge: false, baseline: current.Close, out var index))
                {
                    dot = new DotInfo
                    {
                        Cycle = StockAnalysisCycle.MONTHLY,
                        IsDotOfBuying = isDotOfBuying,
                        TradeDate = current.TradeDate,
                        Days = index,
                        ChangePercent = minus,
                        Close = max
                    };
                    return true;
                }
            }
        }

        return false;
    }

    static bool FindIndexOfValue(this StockPrice[] arr, float close, bool ge, float baseline, out int index)
    {
        index = arr.Length;
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i].Close.Equals(close))
                index = i + 1;
        }

        var newList = new StockPrice[index];
        Array.Copy(arr, newList, index);

        return newList.All(o => ge ? o.Close >= baseline : o.Close <= baseline);
    }

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
        var result=new List<DotInfo>();
            
        foreach (var keyValuePair in dots)
        {
            keyValuePair.Value.ForEach(o=>o.Code=keyValuePair.Key);
            result.AddRange(keyValuePair.Value);
        }
        
        if (request != null)
        {
            result = result
                .Where(o => request.RedOnly is 0 or null || o.ChangePercent > 0)
                .Where(o=>request.GreenOnly is 0 or null||o.ChangePercent<0)
                .Where(o=>string.IsNullOrEmpty(request.StartsWith)||o.Code.StartsWithIn(request.StartsWith.Split(',')))
                .Where( o=>string.IsNullOrEmpty(request.EndsWith)||o.Code.EndsWith(request.EndsWith))
                .Where( o=>string.IsNullOrEmpty(request.Id)||o.Code==request.Id)
                .OrderByDescending(o=>o.TradeDate)
                .ThenByDescending(o=>o.Code)
                .ToList();
        }

        return result;
    }

    #endregion
}