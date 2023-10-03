using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;

namespace Ban3.Productions.Casino.Contracts.Entities;

/// 实时行情记录
public class StockRuntimeRecord
{
    /// 代码
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; }

    /// 名称
    [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
    public string Name { get; set; }

    /// 交易时间
    [JsonProperty("tradeDate", NullValueHandling = NullValueHandling.Ignore)]
    public string TradeDate { get; set; }

    /// 开盘价
    [JsonProperty("open", NullValueHandling = NullValueHandling.Ignore)]
    public float Open { get; set; }

    /// 最高价
    [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
    public float High { get; set; }

    /// 最低价
    [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
    public float Low { get; set; }

    /// 收盘价
    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public float Close { get; set; }

    /// 前收盘价
    [JsonProperty("preClose", NullValueHandling = NullValueHandling.Ignore)]
    public float PreClose { get; set; }

    /// <summary>
    /// 涨幅
    /// </summary>
    [JsonProperty("changePercent", NullValueHandling = NullValueHandling.Ignore)]
    public float ChangePercent { get; set; }

    /// <summary>
    /// 交易量
    /// </summary>
    [JsonProperty("vol", NullValueHandling = NullValueHandling.Ignore)]
    public float Vol { get; set; }

    /// <summary>
    /// 交易额
    /// </summary>
    [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
    public float Amount { get; set; }

    /// 
    public StockRuntimeRecord() { }

}