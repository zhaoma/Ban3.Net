using System.Collections.Generic;
using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class FavoriteRecord
{
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public StockFavoriteType Type { get; set; }

    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; }

    [JsonProperty("markTime", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime MarkTime { get; set; }

    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public float Close { get; set; }

    [JsonProperty("logs", NullValueHandling = NullValueHandling.Ignore)]
    public List<FavoriteLog> Logs { get; set; }
}