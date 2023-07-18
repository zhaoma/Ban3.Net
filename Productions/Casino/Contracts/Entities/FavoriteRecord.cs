using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;

namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 收藏夹记录
/// </summary>
public class FavoriteRecord
{
    /// <summary>
    /// 收藏方式
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public StockFavoriteType Type { get; set; }

    /// <summary>
    /// 名称
    /// </summary>
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    /// <summary>
    /// 代码
    /// </summary>
    [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    /// <summary>
    /// 收藏时间
    /// </summary>
    [JsonProperty("markTime", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public float Close { get; set; }

    /// <summary>
    /// 日志记录
    /// </summary>
    [JsonProperty("logs", NullValueHandling = NullValueHandling.Ignore)]
    public List<FavoriteLog> Logs { get; set; }
}