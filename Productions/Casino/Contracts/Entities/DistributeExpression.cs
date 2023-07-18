using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#nullable enable
namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 分发条件
/// </summary>
public class DistributeExpression
{
    /// 
    public DistributeExpression() { }

    /// <summary>
    /// 代码开始于(002,003,30,68,60)
    /// </summary>
    [JsonProperty("startsWith", NullValueHandling = NullValueHandling.Ignore)]
    public string? StartsWith { get; set; }

    /// <summary>
    /// 指标包含
    /// </summary>
    [JsonProperty("indicatorHas", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndicatorHas IndicatorHas { get; set; }

    /// <summary>
    /// 排序方式
    /// </summary>
    [JsonProperty("sorter", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public RecordsSorter Sorter { get; set; }

    /// <summary>
    /// 最大涨幅
    /// </summary>
    [JsonProperty("maxIncrease", NullValueHandling = NullValueHandling.Ignore)]
    public double? MaxIncrease { get; set; }

    /// <summary>
    /// 最小涨幅
    /// </summary>
    [JsonProperty("minIncrease", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinIncrease { get; set; }

    /// <summary>
    /// 最大振幅
    /// </summary>
    [JsonProperty("maxAmplitude", NullValueHandling = NullValueHandling.Ignore)]
    public double? MaxAmplitude { get; set; }

    /// <summary>
    /// 最小振幅
    /// </summary>
    [JsonProperty("minAmplitude", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinAmplitude { get; set; }

    /// <summary>
    /// 最高价
    /// </summary>
    [JsonProperty("maxPrice", NullValueHandling = NullValueHandling.Ignore)]
    public double? MaxPrice { get; set; }

    /// <summary>
    /// 最低价
    /// </summary>
    [JsonProperty("minPrice", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinPrice { get; set; }

    /// <summary>
    /// 最多上市天数
    /// </summary>
    [JsonProperty("maxDays", NullValueHandling = NullValueHandling.Ignore)]
    public int? MaxDays { get; set; }

    /// <summary>
    /// 页码
    /// </summary>
    [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
    public int? Page { get; set; } = 1;

    /// <summary>
    /// 页尺寸
    /// </summary>
    [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageSize { get; set; } = 10;
}

