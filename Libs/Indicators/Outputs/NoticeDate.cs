/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的提示日期）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 标的提示日期
/// </summary>
public class NoticeDate
{
    /// ctor
    public NoticeDate() { }

    /// <summary>
    /// 日
    /// </summary>
    [JsonProperty("day", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? Day { get; set; }

    /// <summary>
    /// 周
    /// </summary>
    [JsonProperty("week", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? Week { get; set; }

    /// <summary>
    /// 月
    /// </summary>
    [JsonProperty("month", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? Month { get; set; }
}