/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出线）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 输出线
/// </summary>
public class Line
{
    /// <summary>
    /// 
    /// </summary>
    [JsonIgnore]
    public int ParamId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("days", NullValueHandling = NullValueHandling.Ignore)]
    public int Days { get; set; }
}