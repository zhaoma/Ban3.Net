using System;
using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#nullable enable
namespace Ban3.Productions.Casino.Contracts.Entities;

public class DistributeExpression
{
    public DistributeExpression() { }

    [JsonProperty("startsWith", NullValueHandling = NullValueHandling.Ignore)]
    public string? StartsWith { get; set; }

    [JsonProperty("indicatorHas", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndicatorHas IndicatorHas { get; set; }

    [JsonProperty("sorter", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public RecordsSorter Sorter { get; set; }

    [JsonProperty("maxIncrease", NullValueHandling = NullValueHandling.Ignore)]
    public double? MaxIncrease { get; set; }

    [JsonProperty("minIncrease", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinIncrease { get; set; }

    [JsonProperty("maxAmplitude", NullValueHandling = NullValueHandling.Ignore)]
    public double? MaxAmplitude { get; set; }

    [JsonProperty("minAmplitude", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinAmplitude { get; set; }

    [JsonProperty("maxPrice", NullValueHandling = NullValueHandling.Ignore)]
    public double? MaxPrice { get; set; }

    [JsonProperty("minPrice", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinPrice { get; set; }

    [JsonProperty("maxDays", NullValueHandling = NullValueHandling.Ignore)]
    public int? MaxDays { get; set; }

    [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
    public int? Page { get; set; } = 1;

    [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageSize { get; set; } = 10;
}

