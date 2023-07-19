#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Outputs;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 时间线记录
/// </summary>
public class TimelineRecord
{
    /// <summary>
    /// 代码
    /// </summary>
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 日线时间点
    /// </summary>
    [JsonProperty("dailyRecord", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint DailyRecord { get; set; } = new();

    /// <summary>
    /// 周线时间点
    /// </summary>
    [JsonProperty("weeklyRecord", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint? WeeklyRecord { get; set; }

    /// <summary>
    /// 月线时间点
    /// </summary>
    [JsonProperty("monthlyRecord", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint? MonthlyRecord { get; set; }

    /// <summary>
    /// 最新记录
    /// </summary>
    [JsonProperty("nearlyRecord", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint NearlyRecord { get; set; } = new();

    /// <summary>
    /// 金叉记录
    /// </summary>
    [JsonProperty("gcPoints", NullValueHandling = NullValueHandling.Ignore)]
    public List<TimelinePoint>? GcPoints { get; set; }

    /// <summary>
    /// 死叉记录
    /// </summary>
    [JsonProperty("dcPoints", NullValueHandling = NullValueHandling.Ignore)]
    public List<TimelinePoint>? DcPoints { get; set; }

    /// <summary>
    /// 最高点记录
    /// </summary>
    [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint High { get; set; } = new();

    /// <summary>
    /// 最低点记录
    /// </summary>
    [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint Low { get; set; } = new();

    /// 
    public TimelineRecord() { }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sets"></param>
    /// <param name="selected">输出当前标的是否为分析目标</param>
    public TimelineRecord(List<StockSets>? sets, out bool selected)
    {
        selected = false;
        try
        {
            if (sets == null) return;

            var latest = sets.Last();
            if (latest == null || (latest.SetKeys != null && latest.SetKeys.Contains("MACD.N.DAILY")))
            {
                return;
            }

            Code = latest.Code;
            NearlyRecord = new TimelinePoint(latest);

            var d = sets.Last(x => x.SetKeys != null && x.SetKeys.Contains("MACD.C0.DAILY"));
            if (d == null) return;

            DailyRecord = new TimelinePoint(d);
            High = DailyRecord;
            Low = DailyRecord;
            var start = sets.IndexOf(d);

            for (var index = start; index < sets.Count; index++)
            {
                if (sets[index].SetKeys != null)
                {
                    if (sets[index].SetKeys!.Contains("MACD.GC.DAILY"))
                    {
                        GcPoints ??= new();
                        GcPoints.Add(new TimelinePoint(sets[index]));
                    }

                    if (sets[index].SetKeys!.Contains("MACD.DC.DAILY"))
                    {
                        DcPoints ??= new();
                        DcPoints.Add(new TimelinePoint(sets[index]));
                    }

                    if (sets[index].SetKeys!.Contains("MACD.C0.WEEKLY"))
                    {
                        WeeklyRecord = new TimelinePoint(sets[index]);
                    }

                    if (sets[index].SetKeys!.Contains("MACD.C0.MONTHLY"))
                    {
                        MonthlyRecord = new TimelinePoint(sets[index]);
                    }
                }

                if (High.Close < sets[index].Close)
                    High = new TimelinePoint(sets[index]);

                if (Low.Close > sets[index].Close)
                    Low = new TimelinePoint(sets[index]);
            }

            selected = true;
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    /// <summary>
    /// 计算涨幅
    /// </summary>
    /// <returns></returns>
    public double Increase()
        => (NearlyRecord.Close - DailyRecord.Close) / DailyRecord.Close * 100D;

    /// <summary>
    /// 计算振幅
    /// </summary>
    /// <returns></returns>
    public double Amplitude()
        => (High.Close - Low.Close) / Low.Close * 100D;

    /// <summary>
    /// 记录日线时间点距今天数
    /// </summary>
    /// <returns></returns>
    public int DurationDays()
        => (int)DateTime.Now.Subtract(DailyRecord.Date.FromYmd()).TotalDays;
}
