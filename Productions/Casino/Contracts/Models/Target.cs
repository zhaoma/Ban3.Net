using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Sites.ViaTushare.Entries;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Models;

/// <summary>
/// 标的
/// </summary>
public class Target
{
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
    [JsonProperty("price", NullValueHandling = NullValueHandling.Ignore)]
    public StockPrice Price { get; set; }
}