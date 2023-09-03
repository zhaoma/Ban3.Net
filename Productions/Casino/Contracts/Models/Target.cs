using System;
using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Indicators.Outputs;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Sites.ViaTushare.Entries;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Models;

/// <summary>
/// 标的
/// </summary>
public class Target
{
    /// 
    public Target() { }

    /// 
    public Target(
        Stock stock,
        List<TimelinePoint> points,
        StockPrice price,
        StockSets sets)
    {
        Stock = stock;
        Points = points;
        LatestPrice = price;
        LatestSets = sets;
        LastAccess = DateTime.Now;

        Ignore = LatestSets?.SetKeys != null;
        Ignore = Ignore && !LatestSets.SetKeys!.Contains("MACD.M.DAILY");
        Ignore = Ignore && !LatestSets.SetKeys!.Contains("MACD.MDI.DAILY");
    }

    /// <summary>
    /// 标的信息
    /// </summary>
    [JsonProperty("stock", NullValueHandling = NullValueHandling.Ignore)]
    public Stock Stock { get; set; }

    /// <summary>
    /// 忽略该标的
    /// </summary>
    [JsonProperty("ignore", NullValueHandling = NullValueHandling.Ignore)]
    public bool Ignore { get; set; }

    /// <summary>
    /// 事件点
    /// </summary>
    [JsonProperty("points", NullValueHandling = NullValueHandling.Ignore)]
    public List<TimelinePoint> Points { get; set; }

    /// <summary>
    /// 价格信息
    /// </summary>
    [JsonProperty("latestPrice", NullValueHandling = NullValueHandling.Ignore)]
    public StockPrice LatestPrice { get; set; }

    /// <summary>
    /// 特征信息
    /// </summary>
    [JsonProperty("latestSets", NullValueHandling = NullValueHandling.Ignore)]
    public StockSets LatestSets { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("lastAccess", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime LastAccess { get; set; }

    /// 
    public double PreClose()
        => Points.Any() ? Points.First().Close : 0D;

    /// 
    public double Change()
        => PreClose() != 0 ? LatestPrice.Close - PreClose() : 0D;

    /// 
    public double ChangePercent()
        => PreClose() != 0 ? Change()/ PreClose() *100D: 0D;

    /// 
    public string Html()
    {
        var className = ChangePercent()>0 ? "red" : "green";
        return $"{Stock.Symbol}-{LatestPrice.TradeDate}:<span class='{className}'>{PreClose()}-{LatestPrice.Close} <span class='badge'>{Math.Round(ChangePercent(),2)} %</span></span>";
    }
}