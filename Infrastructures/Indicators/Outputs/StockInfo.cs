﻿/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 标的
/// </summary>
public class StockInfo:Entries.Stock
{
    public StockInfo() { }

    /// <summary>
    /// 图标
    /// </summary>
    [JsonProperty("stockIcon", NullValueHandling = NullValueHandling.Ignore)]
    public string StockIcon { get; set; } = string.Empty;

    /// <summary>
    /// 当前价
    /// </summary>
    [JsonProperty("Close", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Close { get; set; }

    /// <summary>
    /// 成交额
    /// </summary>
    [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Amount { get; set; }

    /// <summary>
    /// 总股本
    /// </summary>
    [JsonProperty("generalCapital", NullValueHandling = NullValueHandling.Ignore)]
    public long GeneralCapital { get; set; }

    /// <summary>
    /// 流通股本
    /// </summary>
    [JsonProperty("negotiableCapital", NullValueHandling = NullValueHandling.Ignore)]
    public long NegotiableCapital { get; set; }

    /// <summary>
    /// 净资产
    /// </summary>
    [JsonProperty("equity", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Equity { get; set; }

    /// <summary>
    /// 市净率
    /// </summary>
    [JsonProperty("equityRatio", NullValueHandling = NullValueHandling.Ignore)]
    public decimal EquityRatio { get; set; }

    /// <summary>
    /// 市盈率
    /// </summary>
    [JsonProperty("earningsRatio", NullValueHandling = NullValueHandling.Ignore)]
    public decimal EarningsRatio { get; set; }

    /// <summary>
    /// 负债率
    /// </summary>
    [JsonProperty("debtsRatio", NullValueHandling = NullValueHandling.Ignore)]
    public decimal DebtsRatio { get; set; }
}