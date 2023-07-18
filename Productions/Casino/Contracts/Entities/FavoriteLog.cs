using System;
using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 收藏日志
/// </summary>
public class FavoriteLog
{
    /// <summary>
    /// 收藏类型
    /// </summary>
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public StockFavoriteType Type { get; set; }

    /// <summary>
    /// 收藏时间
    /// </summary>
    [JsonProperty("markTime", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime  MarkTime { get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public float Close { get; set; }
}