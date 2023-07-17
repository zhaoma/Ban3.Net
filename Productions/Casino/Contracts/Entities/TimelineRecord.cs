#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Indicators.Outputs;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class TimelineRecord
{
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; } = string.Empty;

    [JsonProperty("dailyRecord", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint DailyRecord { get; set; } = new();

    [JsonProperty("weeklyRecord", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint? WeeklyRecord { get; set; }

    [JsonProperty("monthlyRecord", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint? MonthlyRecord { get; set; }

    [JsonProperty("nearlyRecord", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint NearlyRecord { get; set; } = new();

    [JsonProperty("gcPoints", NullValueHandling = NullValueHandling.Ignore)]
    public List<TimelinePoint>? GcPoints { get; set; }

    [JsonProperty("dcPoints", NullValueHandling = NullValueHandling.Ignore)]
    public List<TimelinePoint>? DcPoints { get; set; }

    [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint High { get; set; } = new();

    [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
    public TimelinePoint Low { get; set; } = new();

    public TimelineRecord() { }

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

    public double Increase()
        => (NearlyRecord.Close - DailyRecord.Close) / DailyRecord.Close * 100D;

    public double Amplitude()
        => (High.Close - Low.Close) / Low.Close * 100D;

    public int DurationDays()
        => DateTime.Now.Subtract(DailyRecord.Date.FromYmd()).TotalDays.ToInt();
}
