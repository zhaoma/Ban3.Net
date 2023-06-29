/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出时间线）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.Indicators.Outputs;

/// <summary>
/// 输出时间线
/// </summary>
public class LineOfPoint
{
    /// <summary>
    /// 时间点集合
    /// </summary>
    [JsonProperty("endPoints", NullValueHandling = NullValueHandling.Ignore)]
    public List<PointOfTime>? EndPoints { set; get; }
}