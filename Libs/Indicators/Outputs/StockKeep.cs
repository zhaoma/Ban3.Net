/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            指标公式（输出标的持有记录）
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System.Collections.Generic;

namespace  Ban3.Infrastructures.Indicators.Outputs
{
    public class StockKeep : StockLog
    {
        /// <summary>
        /// 当前价
        /// </summary>
        public decimal Current { get; set; }

        /// <summary>
        /// 涨幅
        /// </summary>
        public decimal Increase { get; set; }

        /// <summary>
        /// 总股本
        /// </summary>
        public long GeneralCapital { get; set; }

        /// <summary>
        /// 流通股本
        /// </summary>
        public long NegotiableCapital { get; set; }

        /// <summary>
        /// 相关题材
        /// </summary>
        public IEnumerable<string>? Notions { get; set; }

        /// <summary>
        /// 所有特征
        /// </summary>
        public IEnumerable<string>? Keys { get; set; }
    }
}