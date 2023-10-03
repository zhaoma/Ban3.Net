using System;
using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Outputs;
using System.Linq;
using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json.Converters;

#nullable enable
namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 时间点
/// </summary>
public class TimelinePoint
{
    /// 
    public TimelinePoint() { }

    /// 
    public TimelinePoint(StockSets sets)
    {
        Date = sets.MarkTime.ToYmd();
        Close = sets.Close;
        SetKeys = sets.SetKeys!.ToList();

        var subjects = new List<string>();

        if (SetKeys!.Contains("MACD.GC.DAILY"))
        {
            subjects.Add("日金叉");
        }

        if (SetKeys!.Contains("MACD.C0.DAILY"))
        {
            subjects.Add("日上穿零");
        }

        if (SetKeys!.Contains("MACD.C0.WEEKLY"))
        {
            subjects.Add("周上穿零");
        }

        if (SetKeys!.Contains("MACD.C0.MONTHLY"))
        {
            subjects.Add("月上穿零");
        }

        Subject = subjects.AggregateToString(" ");
    }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("dailyEvent", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public DailyEvent DailyEvent { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// 日期
    /// </summary>
    [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
    public string Date { get; set; } = string.Empty;

    /// <summary>
    /// 收盘价
    /// </summary>
    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public double Close { get; set; }

    /// <summary>
    /// 特征集
    /// </summary>
    [JsonIgnore]
    public List<string>? SetKeys { get; set; }

    /// <summary>
    /// 简要输出
    /// </summary>
    /// <param name="preClose"></param>
    /// <returns></returns>
    public string Html(double? preClose)
    {
        var result = "";
        var d = Date.FromYmd().ToString("yyMMdd");
        if (preClose != null)
        {
            var className = Close > preClose ? "red" : "green";
            var ratio = Math.Round((Close - preClose.Value) / preClose.Value * 100D, 2);
            result += $"<span class='{className}'>{d} {Subject}:{Math.Round(Close,2)} <span class='badge bg-warning'>{ratio} %</span></span>";
        }
        else
        {
            result = $" <span>{d} {Subject}:{Math.Round(Close,2)}</span>";
        }

        return result;
    }
}
