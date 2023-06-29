/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（指标计算结果）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 指标计算结果
/// </summary>
public class StockOperationRecord
{
    /// <summary>
    /// 股票编码
    /// </summary>
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 买入时间
    /// </summary>
    [JsonProperty("buyDate", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime BuyDate { get; set; }

    /// <summary>
    /// 入选时价格
    /// B选择最高价
    /// </summary>
    [JsonProperty("buyPrice", NullValueHandling = NullValueHandling.Ignore)]
    public decimal BuyPrice { get; set; }

    /// <summary>
    /// 卖出时间
    /// </summary>
    [JsonProperty("sellDate", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? SellDate { get; set; }

    /// <summary>
    /// 入选时价格
    /// S选择最低价
    /// </summary>
    [JsonProperty("sellPrice", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? SellPrice { get; set; }

    /// <summary>
    /// 交易量
    /// </summary>
    [JsonProperty("volume", NullValueHandling = NullValueHandling.Ignore)]
    public int? Volume { get; set; }

    /// <summary>
    /// 涨幅/跌幅
    /// </summary>
    [JsonProperty("ratio", NullValueHandling = NullValueHandling.Ignore)]
    public decimal? Ratio { get; set; }
}