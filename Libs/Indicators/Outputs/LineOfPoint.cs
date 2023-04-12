/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出时间线）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 输出时间线
    /// </summary>
    public class LineOfPoint
    {
        //public AnalysisCycle Cycle { set; get; }
        public List<PointOfTime> EndPoints { set; get; }
    }
}