/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的里程碑）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 标的里程碑
/// </summary>
public class MileStone
        : StockLog
{
    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("noticeDates", NullValueHandling = NullValueHandling.Ignore)]
    public List<NoticeDate>? NoticeDates { get; set; }
}