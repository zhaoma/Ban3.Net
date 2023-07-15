/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输入价格）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Ban3.Infrastructures.Indicators.Entries;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Inputs;

/// <summary>
/// 股票价格扩展
/// </summary>
public class Price
    : Record
{
    /// <summary>
    /// 编码
    /// </summary>
    [JsonProperty("code", NullValueHandling = NullValueHandling.Ignore)]
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("preClose", NullValueHandling = NullValueHandling.Ignore)]
    public double? PreClose { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("open", NullValueHandling = NullValueHandling.Ignore)]
    public double? Open { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("close", NullValueHandling = NullValueHandling.Ignore)]
    public double? Close { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("high", NullValueHandling = NullValueHandling.Ignore)]
    public double? High { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("low", NullValueHandling = NullValueHandling.Ignore)]
    public double? Low { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("change", NullValueHandling = NullValueHandling.Ignore)]
    public double? Change { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("changePercent", NullValueHandling = NullValueHandling.Ignore)]
    public double? ChangePercent { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("vol", NullValueHandling = NullValueHandling.Ignore)]
    public double? Vol { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("amount", NullValueHandling = NullValueHandling.Ignore)]
    public double? Amount { get; set; }
}