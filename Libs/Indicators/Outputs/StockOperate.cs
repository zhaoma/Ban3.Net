/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的操作）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 标的操作
/// </summary>
public class StockOperate
        : StockLog
{
    /// ctor
    public StockOperate() { }

    /// <summary>
    /// 建议操作
    /// </summary>
    [JsonProperty("operate", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Enums.StockOperate Operate { get; set; }

    /// <summary>
    /// 操作是否正确
    /// </summary>
    [JsonProperty("isRight", NullValueHandling = NullValueHandling.Ignore)]
    public bool IsRight { get; set; }

    /// <summary>
    /// 特征集合
    /// </summary>
    [JsonProperty("keys", NullValueHandling = NullValueHandling.Ignore)]
    public List<string>? Keys { get; set; }
}