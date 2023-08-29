using System;
using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using Ban3.Infrastructures.Indicators.Outputs;
using System.Linq;

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
        
        var subjects=new List<string>();



        if (SetKeys!.Contains("MACD.C0.DAILY"))
        {
            Subject += "日上穿零";
        }
        if (SetKeys!.Contains("MACD.D0.DAILY"))
        {
            Subject += "日下穿零";
        }

        if (SetKeys!.Contains("MACD.DC.DAILY"))
        {
            Subject += "日死叉";
        }

        if (SetKeys!.Contains("MACD.GC.DAILY"))
        {
            Subject += "日金叉";
        }

        if (SetKeys!.Contains("MACD.C0.WEEKLY"))
        {
            Subject += "周上穿零";
        }
        if (SetKeys!.Contains("MACD.D0.WEEKLY"))
        {
            Subject += "周下穿零";
        }

        if (SetKeys!.Contains("MACD.C0.MONTHLY"))
        {
            Subject += "月上穿零";
        }
        if (SetKeys!.Contains("MACD.D0.MONTHLY"))
        {
            Subject += "月下穿零";
        }
    }

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
            result += $"<span class='{className}'>{d} {Close} <span class='badge'>{ratio} %</span></span>";
        }
        else
        {
            result = $" <span>{d} {Close}</span>";
        }

        return result;
    }
}
