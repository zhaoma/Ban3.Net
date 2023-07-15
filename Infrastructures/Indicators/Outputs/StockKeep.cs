/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的持有记录）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

public class StockKeep : StockLog
{
    /// <summary>
    /// 当前价
    /// </summary>
    [JsonProperty("current", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Current { get; set; }

    /// <summary>
    /// 涨幅
    /// </summary>
    [JsonProperty("increase", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Increase { get; set; }

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
    /// 相关题材
    /// </summary>
    [JsonProperty("notions", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<string>? Notions { get; set; }

    /// <summary>
    /// 所有特征
    /// </summary>
    [JsonProperty("keys", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<string>? Keys { get; set; }
}