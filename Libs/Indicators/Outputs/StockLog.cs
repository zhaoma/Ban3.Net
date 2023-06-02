/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的日志）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    /// <summary>
    /// 标的日志
    /// </summary>
    public class StockLog
    {
        /// ctor
        public StockLog() {}

        /// <summary>
        /// 标的代码
        /// </summary>
        public string Code { get; set; }

        public string Symbol { get; set; }

        /// <summary>
        /// 标注日期
        /// </summary>
        public DateTime MarkTime { get; set; }

        /// <summary>
        /// 收盘价
        /// </summary>
        public decimal Close { get; set; }
    }
}