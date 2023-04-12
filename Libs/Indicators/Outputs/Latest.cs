/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（最新指标值）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 最新指标值
    /// </summary>
    public class Latest
    {
        /// <summary>
        /// 上一周期指标值
        /// </summary>
        public PointOfTime Prev { get; set; }

        /// <summary>
        /// 当前周期指标值
        /// </summary>
        public PointOfTime Current { get; set; }
    }
}