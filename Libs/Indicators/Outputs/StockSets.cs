/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的特征）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 输出标的特征
/// </summary>
public class StockSets
        : StockLog
{
    /// <summary>
    /// 特征
    /// </summary>
    [JsonProperty("setKeys", NullValueHandling = NullValueHandling.Ignore)]
    public IEnumerable<string>? SetKeys { get; set; }
}