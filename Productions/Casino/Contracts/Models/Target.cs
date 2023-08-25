using System;
using System.Collections.Generic;
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
    public Target(){}

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
}