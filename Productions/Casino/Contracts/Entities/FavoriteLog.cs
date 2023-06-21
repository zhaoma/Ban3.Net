using System;
using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

public class FavoriteLog
{
    [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public StockFavoriteType Type { get; set; }

    [JsonProperty("markTime", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime  MarkTime { get; set; }

    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public float Close { get; set; }
}