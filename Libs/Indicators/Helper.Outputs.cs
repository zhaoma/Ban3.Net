using Ban3.Infrastructures.Indicators.Outputs;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Linq;
using Ban3.Infrastructures.Indicators.Formulas;
using Ban3.Infrastructures.Indicators.Inputs;
using Ban3.Infrastructures.Indicators.Enums;
using StockOperate = Ban3.Infrastructures.Indicators.Outputs.StockOperate;
using Ban3.Infrastructures.Indicators.Entries;
using System.Collections;
using Ban3.Infrastructures.Common.Extensions;

namespace Ban3.Infrastructures.Indicators;

public static partial class Helper
{
    #region 买卖点筛选

    public static List<DotInfo>? DotsOfBuyingOrSelling(this List<Price>? prices, FocusFilter filter)
    {
        if (prices == null || !prices.Any()) return null;

        var result = new List<DotInfo>();

        for (var i = 0; i < prices.Count; i++)
        {
            if (prices.GetDayDot(filter, i, out var dotForDay))
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

    static bool GetDayDot(this List<Price> prices, FocusFilter filter, int i, out DotInfo dot)
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
                    TradeDate = current.TradeDate.ToYmd(),
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

    static bool GetWeekDot(this List<Price> prices, FocusFilter filter, int i, out DotInfo dot)
    {
        var current = prices[i];

        dot = null;

        if (prices.Count == i + 1) return false;

        var len = Math.Min(5, prices.Count - i - 1);
        if (len <= 0) return false;
        var week = new Price[len];
        prices.CopyTo(i + 1, week, 0, len);

        if (!week.Any()) return false;

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
                        TradeDate = current.TradeDate.ToYmd(),
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
                        TradeDate = current.TradeDate.ToYmd(),
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

    static bool GetMonthDot(this List<Price> prices, FocusFilter filter, int i, out DotInfo dot)
    {

        var current = prices[i];

        dot = null;

        if (prices.Count == i + 1) return false;

        var len = Math.Min(20, prices.Count - i - 1);
        if (len <= 0) return false;
        var month = new Price[len];
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
                        TradeDate = current.TradeDate.ToYmd(),
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
                        TradeDate = current.TradeDate.ToYmd(),
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

    static bool FindIndexOfValue(this Price[] arr, double? close, bool ge, double? baseline, out int index)
    {
        index = arr.Length;
        for (var i = 0; i < arr.Length; i++)
        {
            if (arr[i].Close.Equals(close))
                index = i + 1;
        }

        var newList = new Price[index];
        Array.Copy(arr, newList, index);

        return newList.All(o => ge ? o.Close >= baseline : o.Close <= baseline);
    }


    #endregion

    /// <summary>
    /// 行情数据集转指标结果线
    /// </summary>
    /// <param name="prices"></param>
    /// <returns></returns>
    public static LineOfPoint? CalculateIndicators(this List<Price> prices)
        => new Full().Calculate(prices);

    /// <summary>
    /// 结果线转特征集
    /// </summary>
    /// <param name="line"></param>
    /// <returns></returns>
    public static List<StockSets>? LineToSets(this LineOfPoint? line,Stock stock)
    {
        var latestList = line.LatestList();
        if (latestList == null) return null;

        return latestList
            .Select(o => new StockSets
            {
                Code=stock.Code,
                Symbol=stock.Symbol,
                MarkTime = o.Current!.TradeDate,
                Close = o.Current.Close,
                SetKeys = o.Features()
            })
            .OrderBy(o => o.MarkTime)
            .ToList();
    }

    /// <summary>
    /// 特征集合并
    /// </summary>
    /// <param name="daily"></param>
    /// <param name="weekly"></param>
    /// <param name="monthly"></param>
    /// <returns></returns>
    public static List<StockSets>? MergeWeeklyAndMonthly(
        this List<StockSets>? daily,
        List<StockSets>? weekly,
        List<StockSets>? monthly)
    {
        if (daily == null || !daily.Any()) return daily;

        for (var index = 0; index < daily.Count; index++)
        {
            var keys = daily[index].SetKeys!.Select(o => $"{o}.{StockAnalysisCycle.DAILY}");

            keys = keys.Union(weekly![index].SetKeys!.Select(o => $"{o}.{StockAnalysisCycle.WEEKLY}"));

            keys = keys.Union(monthly![index].SetKeys!.Select(o => $"{o}.{StockAnalysisCycle.MONTHLY}"));

            daily[index].SetKeys = keys;
        }

        return daily;
    }

    /// <summary>
    /// 最后一个StockSets推送到集合
    /// </summary>
    /// <param name="all"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static List<StockSets>? PushLatest(
        this List<StockSets>? all,
        List<StockSets> target)
    {
        if (all != null && all.Any())
        {
            target.Add(all.Last());
        }

        return all;
    }

    /// <summary>
    /// 指标特征集转换榜单
    /// </summary>
    /// <param name="stockSets"></param>
    /// <returns></returns>
    public static List<ListRecord>? GenerateList(this List<StockSets>? stockSets)
    {
        var result = stockSets?
            .Where(o => o.SetKeys != null && o.SetKeys.Any())
            .Select(o => new ListRecord(o))
            .OrderByDescending(o => o.Value)
            .ToList();

        var rank = 1;
        int? prev = null;

        if (result != null)
        {
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
        }

        return result;
    }

    /// <summary>
    /// 策略+特征集生成操作建议(近一年)
    /// </summary>
    /// <param name="profile"></param>
    /// <param name="everydayKeys"></param>
    /// <returns></returns>
    public static List<StockOperate>? OutputDailyOperates(
        this Profile profile,
        List<StockSets>? everydayKeys)
    {
        if (everydayKeys == null || !everydayKeys.Any()) return null;

        var operates = new List<StockOperate>();

        foreach (var t in everydayKeys)
        {
            if (t.MarkTime.Year <= DateTime.Now.Year - 2 || t.SetKeys == null) continue;

            var latestOperate = operates.Any()
                ? operates.Last().Operate
                : Enums.StockOperate.Left;

            var currentOperate = t.SetKeys!.GetOperate(profile, latestOperate);

            if (latestOperate != currentOperate || !operates.Any())
            {
                operates.Add(new StockOperate
                {
                    Code = t.Code,
                    Symbol = t.Symbol,
                    MarkTime = t.MarkTime,
                    Close = t.Close,
                    Operate = currentOperate
                });
            }
        }

        return operates;
    }

    /// <summary>
    /// 操作建议转操作记录
    /// </summary>
    /// <param name="stockOperates"></param>
    /// <returns></returns>
    public static List<StockOperationRecord>? ConvertToRecords(
        this List<StockOperate>? stockOperates)
    {
        try
        {
            var tradeRecords = new List<StockOperationRecord>();

            if (stockOperates != null && stockOperates.Any())
            {

                foreach (var op in stockOperates)
                {
                    var latest = tradeRecords.Any()
                        ? tradeRecords.Last()
                        : null;

                    if (op.Operate == Enums.StockOperate.Buy)
                    {
                        if (latest == null || latest.SellPrice > 0)
                        {
                            latest = new StockOperationRecord
                            {
                                Code = op.Code,
                                BuyDate = op.MarkTime,
                                BuyPrice = op.Close,

                            };
                            tradeRecords.Add(latest);
                        }
                    }

                    if (op.Operate == Enums.StockOperate.Sell)
                    {
                        if (latest != null)
                        {
                            latest.SellDate = op.MarkTime;
                            latest.SellPrice = op.Close;
                            latest.Ratio = Math.Round((decimal)((op.Close - latest.BuyPrice) / latest.BuyPrice)! * 100M, 2);
                        }
                    }
                }
            }

            return tradeRecords;
        }
        catch (Exception ex)
        {
            Logger.Error(ex);
        }

        return null;
    }

    /// <summary>
    /// 操作记录汇总
    /// </summary>
    /// <param name="records"></param>
    /// <param name="profile"></param>
    /// <returns></returns>
    public static ProfileSummary? RecordsSummary(this List<StockOperationRecord>? records, Profile profile)
    {
        if(records==null||!records.Any()) return null;

        var validRecords = records.Where(o => o.SellDate != null && o.BuyPrice > 0).ToList();
        if (!validRecords.Any()) return null;

            return new ProfileSummary
            {
                Identity = profile.Identity,
                StockCount = 1,
                RecordCount = validRecords.Count(),
                RightCount = validRecords.Count(o => o.SellPrice > o.BuyPrice),
                Best = (decimal)validRecords.Max(o => (o.SellPrice - o.BuyPrice) / o.BuyPrice * 100D)!.Value,
                Worst = (decimal)validRecords.Min(o => (o.SellPrice - o.BuyPrice) / o.BuyPrice * 100D)!.Value,
                Average = validRecords.FinalProfit()
            };
    }

    /// <summary>
    /// 个股汇总成策略统计
    /// </summary>
    /// <param name="evaluateSummary"></param>
    /// <param name="one"></param>
    /// <returns></returns>
    public static Dictionary<string, ProfileSummary> MergeSummary(
        this Dictionary<string, ProfileSummary> evaluateSummary,
        ProfileSummary? one)
    {
        if (one != null)
        {
            if (evaluateSummary.TryGetValue(one.Identity, out var summary))
            {
                summary.Best = Math.Max(summary.Best, one.Best);
                summary.Worst = Math.Min(summary.Worst, one.Worst);
                summary.Average = (summary.StockCount * summary.Average + one.Average) /
                                  (summary.StockCount + 1);
                summary.StockCount += 1;
                summary.RecordCount += one.RecordCount;
                summary.RightCount += one.RightCount;

                evaluateSummary[one.Identity] = summary;
            }
            else
            {
                evaluateSummary.Add(one.Identity, one);
            }
        }

        return evaluateSummary;
    }

}