/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的操作）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using Enums = Ban3.Infrastructures.Indicators.Enums;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 标的操作
    /// </summary>
    public class StockOperate
            : StockLog
    {
        /// ctor
        public StockOperate() {}

        /// <summary>
        /// 建议操作
        /// </summary>
        public Enums.StockOperate Operate { get; set; }

        /// <summary>
        /// 操作是否正确
        /// </summary>
        public bool IsRight { get; set; }
    }
}