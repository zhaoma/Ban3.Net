/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的日志）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Newtonsoft.Json;
using System;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 标的日志
/// </summary>
public class StockLog
{
    /// ctor
    public StockLog() { }

    /// <summary>
    /// 标的代码(_SZ/_SH)
    /// </summary>
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 标的代码
    /// </summary>
    [JsonProperty("symbol", NullValueHandling = NullValueHandling.Ignore)]
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// 标注日期
    /// </summary>
    [JsonProperty("markTime", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime MarkTime { get; set; }

    /// <summary>
    /// 收盘价
    /// </summary>
    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public decimal Close { get; set; }
}