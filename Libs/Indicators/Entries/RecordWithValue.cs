/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（指标值）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Entries;

/// <summary>
/// 指标值
/// </summary>
public class RecordWithValue
        : Record
{
    /// <summary>
    /// 指标参数
    /// </summary>
    [JsonProperty("paramId", NullValueHandling = NullValueHandling.Ignore)]
    public virtual int ParamId { get; set; }

    /// <summary>
    /// 计算获值
    /// </summary>
    [JsonProperty("ref", NullValueHandling = NullValueHandling.Ignore)]
    public virtual decimal Ref { get; set; }
}