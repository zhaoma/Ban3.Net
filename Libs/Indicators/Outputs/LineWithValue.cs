/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（带值输出线）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 带值输出线
/// </summary>
public class LineWithValue : Line
{
    /// <summary>
    /// 指标值
    /// </summary>
    [JsonProperty("ref", NullValueHandling = NullValueHandling.Ignore)]
    public double Ref { get; set; }
}